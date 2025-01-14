namespace ECAIService.MachineLearning;

public class SequenceAggregator : Module
{
    private readonly GRU _gru;

    public SequenceAggregator(long inputDim, long hiddenDim, string name = nameof(SequenceAggregator))
        : base(name)
    {
        _gru = GRU(inputDim, hiddenDim, 1, batchFirst: true);
        RegisterComponents();
    }

    public Tensor forward(Tensor x)
    {
        return _gru.forward(x.unsqueeze(0)).Item2.squeeze(0);
    }
}
