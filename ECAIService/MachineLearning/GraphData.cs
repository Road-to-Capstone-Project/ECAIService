using System.Numerics;

using TorchSharp;

namespace ECAIService.MachineLearning;

public record GraphData()
{
    public float[,] AdjacencyMatrix { get; set; }
    public float[,] NodeFeatures { get; set; }
    public Dictionary<string, int> ProductToId { get; set; }
    public Dictionary<int, string> IdToProduct { get; set; }

    public static GraphData CreateGraphFromSessions(string[] sessions)
    {
        var productToId = new Dictionary<string, int>();
        var edges = new List<(int, int)>();
        int productCounter = 0;

        // Parse sessions and construct edges
        foreach (var session in sessions)
        {
            var products = session.Split(' ');
            for (int i = 0; i < products.Length; i++)
            {
                if (!productToId.ContainsKey(products[i]))
                {
                    productToId[products[i]] = productCounter++;
                }
                if (i > 0)
                {
                    edges.Add((productToId[products[i - 1]], productToId[products[i]]));
                }
            }
        }

        int numNodes = productToId.Count;
        var adjacencyMatrix = new float[numNodes, numNodes];
        foreach (var (src, dst) in edges)
        {
            adjacencyMatrix[src, dst] += 1.0f; // Add edge weight (frequency)
        }

        // Normalize adjacency matrix
        for (int i = 0; i < numNodes; i++)
        {
            float rowSum = 0;
            for (int j = 0; j < numNodes; j++) rowSum += adjacencyMatrix[i, j];
            if (rowSum > 0)
            {
                for (int j = 0; j < numNodes; j++) adjacencyMatrix[i, j] /= rowSum;
            }
        }

        // Create node features (identity matrix as default)
        var nodeFeatures = new float[numNodes, numNodes];
        for (int i = 0; i < numNodes; i++) nodeFeatures[i, i] = 1.0f;

        var idToProduct = new Dictionary<int, string>();
        foreach (var kvp in productToId) idToProduct[kvp.Value] = kvp.Key;

        return new GraphData
        {
            AdjacencyMatrix = adjacencyMatrix,
            NodeFeatures = nodeFeatures,
            ProductToId = productToId,
            IdToProduct = idToProduct
        };
    }

    public static List<(int, int)> GetTargets(string[] sessions, Dictionary<string, int> productToId)
    {
        var targets = new List<(int, int)>();
        foreach (var session in sessions)
        {
            var products = session.Split(' ');
            for (int i = 1; i < products.Length; i++)
            {
                targets.Add((productToId[products[i - 1]], productToId[products[i]]));
            }
        }
        return targets;
    }

    public static string PredictNextProduct(GNNRecommender model, GraphData graphData, string[] session)
    {
        model.eval();

        var adjacencyMatrix = torch.tensor(graphData.AdjacencyMatrix);
        var nodeFeatures = torch.tensor(graphData.NodeFeatures);

        // Get embeddings for all nodes
        var outputs = model.forward(nodeFeatures, adjacencyMatrix);

        // Get the embedding for the last item in the session
        int lastItemId = graphData.ProductToId[session[^1]];
        var lastItemEmbedding = outputs[lastItemId];

        // Compute similarity scores
        var scores = outputs.matmul(lastItemEmbedding.unsqueeze(1)).squeeze();
        var predictedId = scores.argmax().item<int>();

        return graphData.IdToProduct[predictedId];
    }
}