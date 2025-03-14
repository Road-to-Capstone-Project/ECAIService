﻿
using TorchSharp;
using TorchSharp.Modules;

using static TorchSharp.torch;
using static TorchSharp.torch.nn;

using Tensor = TorchSharp.torch.Tensor;

namespace ECAIService.MachineLearning;
class GCNLayer : Module
{
    private readonly Linear linear;

    public GCNLayer(long inputDim, long outputDim, string name = nameof(GCNLayer)) : base(name)
    {
        linear = Linear(inputDim, outputDim);
        RegisterComponents();
    }

    public Tensor forward(Tensor x, Tensor adjacencyMatrix)
    {
        var aggregated = torch.matmul(adjacencyMatrix, x);
        return torch.nn.ReLU().forward((linear.forward(aggregated)));
    }
}

// Define your GCN model using GCNLayer
