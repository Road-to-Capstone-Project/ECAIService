namespace ECAIService.MachineLearning;

public class GCNImplementation(
        ILogger<GCNImplementation>? logger = null,
        GCNImplementation? proxy = null
    )
{
    private GCNImplementation Proxy => proxy ?? this;

    public NDArray GraphConvolutionalLayer(NDArray adjacencyMatrix,
                                          NDArray? inputFeatureMatrix = null,
                                          NDArray? weightMatrix = null)
    {
        var degreeMatrix = np.sum(adjacencyMatrix, axis: 0);

        var normalizedAdjacencyMatrix = 
            (adjacencyMatrix + np.eye((int)adjacencyMatrix.shape[0])) 
            / (degreeMatrix.Let(np.sqrt) + 1e-5);

        return normalizedAdjacencyMatrix
            //.Let(i => inputFeatureMatrix?.Let(j => np.dot(i, j)) ?? i)
            //.Let(i => weightMatrix?.Let(j => np.dot(i, j)) ?? i)
            ;
    }

    public NDArray GCN(NDArray adjacencyMatrix,
                    NDArray? inputFeatureMatrix = null,
                    IEnumerable<NDArray>? weightMatrix = null)
    {
        weightMatrix ??= [];

        return weightMatrix.Aggregate(inputFeatureMatrix!, (current, weight) => Proxy.GraphConvolutionalLayer(adjacencyMatrix, current, weight))
            .Apply(it => ArgumentNullException.ThrowIfNull(it))!;
    }
}
