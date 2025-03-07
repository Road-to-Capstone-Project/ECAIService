
using System.Text;

using ECAIService.Data;
using ECAIService.MachineLearning;

using Newtonsoft.Json;

namespace ECAIService.Services.Scripts;

public class GNNService(
    CVOSContext cVOSContext,
    Device device,
    [FromKeyedServices(nameof(GNNService))] ICollection<string> sequence,
    ILogger<GNNService> logger,
    ILogger<GNNModel> modelLogger) : IAsyncScript
{
    public ICollection<string> Sequence { get; set; } = sequence; 

    private readonly record struct MatrixItem(int I, int J, float Val);

    public async Task<object?> ExecuteAsync()
    {
        var sessions = 
            (await File.ReadAllLinesAsync("Resources/sessions.txt"))
            .Select(i => i.Split(';'))
            .Take(10000)
            .ToArray()
            ;

        logger.LogInformation("Loading data...");

        var productKVs = cVOSContext.ProductVariants.AsEnumerable().Zip(Enumerable.Range(0, int.MaxValue));

        //await File.WriteAllTextAsync("Resources/output1.txt",
        //                   cVOSContext.ProductVariants
        //                   .Select(i => i.Id)
        //                   .Let(it => string.Join('\n', it))
        //                   + "\n");

        var products = productKVs.ToDictionary(i => i.First.Id, i => i.Second);

        var inverse = productKVs.ToDictionary(i => i.Second, i => i.First.Id);

        logger.LogInformation("Loading data done.");

        var graphData = GraphData2.FromSession(sessions, products).to(device);

        var adjacencyEnumerable = Enumerable.Range(0, (int)graphData.AdjacencyMatrix.shape[0])
            .Select(i =>
                {
                    return Task.Run(() => Enumerable.Range(0, (int)graphData.AdjacencyMatrix.shape[1])
                    .Select(j =>
                    {
                        var val = graphData.AdjacencyMatrix[i, j].ToSingle();

                        if (val == 0) return default;

                        else
                        {
                            return new MatrixItem(i, j , val);
                        }
                    })
                    .Where(i => i.Val != 0)
                    );
                }
            );

        await File.WriteAllTextAsync("Resources/adjacencyMatrix.csv", "");

        using (var writer = File.AppendText("Resources/adjacencyMatrix.csv"))
        {
            var tasks = new LinkedList<Task<StringBuilder>>();

            foreach (var task in adjacencyEnumerable)
            {
                var stringBuilder = new StringBuilder();
                var next = task.ContinueWith(async it => {
                    var row = (await it);
                    foreach (var item in row)
                    {
                        stringBuilder.Append($"{JsonConvert.SerializeObject(item)} ");
                    }
                    stringBuilder.AppendLine();
                    return stringBuilder;
                }).Unwrap();
                tasks.AddLast(next);
            }

            await foreach (var task in tasks.Let(Task.WhenEach))
            {
                var value = await task;

                if (value[0] != '\n')
                {
                    await writer.WriteAsync(value);
                }
            }
        }
        //await File.WriteAllTextAsync("Resources/adjacencyMatrix.txt", graphData.AdjacencyMatrix.ToString());

        logger.LogInformation("Graph Encoders.");

        int numProducts = products.Count;

        // Define the model
        int inputDim = numProducts, hiddenDim = 8, outputDim = numProducts;

        InitializeDevice(device);

        var model = new GNNModel(inputDim, hiddenDim, outputDim, modelLogger, "GNNRecommender").to(device);

        var output = model.forward(graphData.NodeFeatures, graphData.AdjacencyMatrix);

        Console.WriteLine("Train done.");

        GNNModel.Predict(output, products, inverse,
            Sequence);

        return await GenericExtensions.NullTask;
    }
}
