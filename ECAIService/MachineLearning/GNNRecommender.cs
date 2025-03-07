using TorchSharp;
using TorchSharp.Modules;

using static TorchSharp.torch;
using static TorchSharp.torch.nn;

using Tensor = TorchSharp.torch.Tensor;

namespace ECAIService.MachineLearning;

public class GNNRecommender : Module
{
    private readonly GCNLayer _gCNA;
    private readonly GCNLayer _gCNB;
    private readonly ReLU _relu;

    public GNNRecommender(
        long inputDim,
        long hiddenDim,
        long outputDim,
        string name = nameof(GNNRecommender)) : base(name)
    {
        _gCNA = new GCNLayer(inputDim, hiddenDim, name: $"{name}_gCNA");
        _gCNB = new GCNLayer(hiddenDim, outputDim, name: $"{name}_gCNB");
        _relu = torch.nn.ReLU();
        RegisterComponents();
    }

    public Tensor forward(Tensor x, Tensor adjacencyMatrix)
    {
        return x
            .Let(it => _gCNA.forward(it, adjacencyMatrix))
            .Let(_relu.forward)
            .Let(it => _gCNB.forward(it, adjacencyMatrix));
    }

    public static GNNRecommender FromGraphData(GraphData graphData, long hiddenDim = 16)
    {
        return new GNNRecommender(graphData.NodeFeatures.GetLength(1), hiddenDim, graphData.NodeFeatures.GetLength(0));
    }

    public static void TrainModel(GNNRecommender model, GraphData graphData, List<(int, int)> targets, int epochs, float learningRate)
    {
        var optimizer = torch.optim.Adam(model.parameters(), learningRate);
        var lossFn = torch.nn.CrossEntropyLoss();

        var adjacencyMatrix = torch.tensor(graphData.AdjacencyMatrix);
        var nodeFeatures = torch.tensor(graphData.NodeFeatures);

        for (int epoch = 0; epoch < epochs; epoch++)
        {
            model.train();

            optimizer.zero_grad();

            // Forward pass
            var outputs = model.forward(nodeFeatures, adjacencyMatrix);

            // Compute loss
            Tensor loss = torch.zeros(1);
            foreach (var (src, target) in targets)
            {
                loss += lossFn.forward(outputs[src].unsqueeze(0), torch.tensor(new long[] { target }));
            }
            loss /= targets.Count;

            // Backpropagation
            loss.backward();
            optimizer.step();

            if (epoch % 10 == 0)
            {
                Console.WriteLine($"Epoch {epoch}, Loss: {loss.item<float>()}");
            }
        }
    }
}
