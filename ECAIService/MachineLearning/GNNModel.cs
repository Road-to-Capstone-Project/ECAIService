using System.Text;

namespace ECAIService.MachineLearning;

public class GNNModel : Module
{
    private readonly Linear _conv1;
    private readonly Linear _conv2;

    public GNNModel(
        long inputDim,
        long hiddenDim,
        long outputDim,
        string name = nameof(GNNModel)) : base(name)
    {
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

        GC.Collect();

        // Aggregate embeddings for input sequence
        var sequenceEmbedding = torch.mm(inputMask.unsqueeze(0), output)
            .Let(it => it / it.norm());

        GC.Collect();

        var normalizedOutput = output / output.norm(1, keepdim: true);

        GC.Collect();

        var scores = torch.mm(sequenceEmbedding, normalizedOutput.T);

        GC.Collect();

        // Find top predictions
        var topPredictions = scores.argsort(descending: true).flatten();
        //buffer.AppendLine("Top Predictions:");
        foreach (int idx in topPredictions.data<long>())
        {
            if (!inputSequence.Contains(inverses[idx]))
            {
                buffer.AppendLine(inverses[idx]);
            }
        }

        File.WriteAllText("Resources/output2.txt", buffer.ToString());
    }
}
