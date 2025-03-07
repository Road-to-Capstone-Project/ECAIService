
using System.Linq;

using ECAIService.Data;

using Tensorflow.Keras;
using Tensorflow.Keras.ArgsDefinition;
using Tensorflow.Keras.Engine;
using Tensorflow.Keras.Layers;
using Tensorflow.Keras.Utils;
using Tensorflow.Operations.Activation;

using Sequential = Tensorflow.Keras.Engine.Sequential;
using Tensor = Tensorflow.Tensor;

namespace ECAIService.Services.Scripts;

public class RNNScript(CVOSContext cVOSContext, RNNFactory rNNFactory, ILogger<RNNScript> logger) : IAsyncScript
{
    public async Task<object?> ExecuteAsync()
    {
        var sessions =
            (await File.ReadAllLinesAsync("Resources/sessions.txt"))
            .Select(i => i.Split(';'))
            .Take(10000)
            .ToArray()
            ;

        var productVariantIds = 
            //cVOSContext.ProductVariants.Select(i => i.Id).ToArray();
            sessions.SelectMany().Distinct().ToArray();

        var productVariantIndices = productVariantIds.Select((i, index) => KeyValuePair.Create(i, index)).ToDictionary();

        const int sequenceLength = 3;

        var arguments = new RNNFactory.Encoders(
                    i => productVariantIndices[i],
                    i => productVariantIds[i],
                    productVariantIds.Length,
                    sequenceLength
                );

        var model = rNNFactory.CreateModel2(
            sessions,
            arguments,
            0.8m);

        //var prediction = model.Let(rNNFactory.Predict,
        //    "adventure-time-run;modern-strike-online;temple-run-2".Split(";"),
        //    encoders);

        //logger.LogInformation("Prediction: {prediction}", prediction);

        

        return model;
        //rNNFactory.Run();

        //return null;
    }
}
