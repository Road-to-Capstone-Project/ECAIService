using Tensor = TorchSharp.torch.Tensor;

namespace ECAIService.MachineLearning;

public record GraphData2(Tensor NodeFeatures, Tensor AdjacencyMatrix)
{
    public static GraphData2 FromSession(IReadOnlyList<IReadOnlyList<string>> sessions,
        IReadOnlyDictionary<string, int> products)
    {
        int numProducts = products.Count;
        var adjacencyMatrix = torch.zeros([numProducts, numProducts]);
        foreach (var session in sessions)
        {
            for (int i = 0; i < session.Count; i++)
            {
                for (int j = i + 1; j < session.Count; j++)
                {
                    var product1 = products[session[i]];
                    var product2 = products[session[j]];
                    adjacencyMatrix[product1, product2] += 1;
                    adjacencyMatrix[product2, product1] += 1;
                }
            }
        }

        // Normalize adjacency matrix
        var rowSum = adjacencyMatrix.sum(1).unsqueeze(1);
        var normalizedAdjacency = adjacencyMatrix / (rowSum + 1e-6);

        // Node feature matrix (one-hot encoding for simplicity)
        var nodeFeatures = torch.eye(numProducts);

        return new GraphData2(nodeFeatures, normalizedAdjacency);
    }

    public GraphData2 to(Device device)
    {
        return new(NodeFeatures.to(device), AdjacencyMatrix.to(device));
    }
}
