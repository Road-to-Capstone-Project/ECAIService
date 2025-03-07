using System.Text;
using System.Linq;
using Tensor = TorchSharp.torch.Tensor;

namespace ECAIService.MachineLearning;

public class GNNModel : Module
{
    private readonly Linear _conv1;
    private readonly Linear _conv2;
    private readonly ILogger<GNNModel> _logger;

    public GNNModel(
        long inputDim,
        long hiddenDim,
        long outputDim,
        ILogger<GNNModel> logger,
        string name = nameof(GNNModel)
        ) : base(name)
    {
        _logger = logger;
        _conv1 = Linear(inputDim, hiddenDim);
        _conv2 = Linear(hiddenDim, outputDim);
        RegisterComponents();
    }

    public Tensor forward(Tensor nodeFeatures, Tensor adjacencyMatrix)
    {
        Tensor Mul(Tensor x) => torch.mm(adjacencyMatrix, x);

        return nodeFeatures
            .Let(Mul)
            .Let(it => _conv1.forward(it).relu())
            .Let(Mul)
            .Let(it => _conv2.forward(it).softmax(1));
    }

    public static void Predict(Tensor output, IReadOnlyDictionary<string, int> products, IReadOnlyDictionary<int, string> inverses, IEnumerable<string> inputSequence)
    {
        var buffer = new StringBuilder();

        int numProducts = products.Count;
        var inputMask = torch.zeros([numProducts]).to(output.device);
        foreach (var product in inputSequence)
        {
            inputMask[products[product]] = 1;
        }

        // Aggregate embeddings for input sequence
        var sequenceEmbedding = torch.mm(inputMask.unsqueeze(0), output)
            .Let(it => it / it.norm());

        var normalizedOutput = output / output.norm(1, keepdim: true);

        var scores = torch.mm(sequenceEmbedding, normalizedOutput.T);

        // Find top predictions
        var topPredictions = scores.argsort(descending: true).flatten();
        foreach (var idx in topPredictions.data<long>().Select(v => (int)v).Where(idx => !inputSequence.Contains(inverses[idx]))
        //buffer.AppendLine("Top Predictions:");
        )
        {
            buffer.AppendLine(inverses[idx]);
        }

        File.WriteAllText("Resources/output2.txt", buffer.ToString());
    }
}
