using ECAIService.Data;
using ECAIService.MachineLearning;

namespace ECAIService.Services.Scripts;

public class GNNService
{
    public GNNService(CVOSContext cVOSContext, Device device)
    {
        var sessions = File.ReadAllLines("Resources/sessions.txt").Select(i => i.Split(';')).ToArray();

        Console.WriteLine("Loading data...");

        var productKVs = cVOSContext.ProductVariants.AsEnumerable().Zip(Enumerable.Range(0, int.MaxValue));

        File.WriteAllText("Resources/output1.txt",
                           cVOSContext.ProductVariants
                           .Select(i => i.Id)
                           .Let(it => string.Join('\n', it))
                           + "\n");

        var products = productKVs.ToDictionary(i => i.First.Id, i => i.Second);

        var inverse = productKVs.ToDictionary(i => i.Second, i => i.First.Id);

        Console.WriteLine("Loading data done.");

        var graphData = GraphData2.FromSession(sessions, products).to(device);

        File.WriteAllText("Resources/adjacencyMatrix.txt", graphData.AdjacencyMatrix.ToString());

        Console.WriteLine("Graph Data.");

        int numProducts = products.Count;

        // Define the model
        int inputDim = numProducts, hiddenDim = 8, outputDim = numProducts;

        InitializeDevice(device);

        var model = new GNNModel(inputDim, hiddenDim, outputDim, "GNNRecommender").to(device);

        var output = model.forward(graphData.NodeFeatures, graphData.AdjacencyMatrix);

        Console.WriteLine("Train done.");

        GNNModel.Predict(output, products, inverse,
            ["【Miku AR Camera】Mikuture"]);
    }
}
