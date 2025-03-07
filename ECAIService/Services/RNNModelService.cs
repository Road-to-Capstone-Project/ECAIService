
using ECAIService.Data;

using Microsoft.EntityFrameworkCore.Metadata.Internal;

using Newtonsoft.Json;

using Tensorflow.Functions;

using IModel = Tensorflow.Keras.Engine.IModel;
using TFModel = Tensorflow.Keras.Engine.IModel;

namespace ECAIService.Services;

public class RNNModelService
{
    public RNNModelService(RNNFactory rNNFactory,
        MemoryManager memoryManager,
        IServiceProvider serviceProvider,
        ILogger<RNNModelService> logger)
    {
        using var scope = serviceProvider.CreateScope();
        var cVOSContext = scope.ServiceProvider.GetRequiredService<CVOSContext>();

        var sessions =
            (File.ReadAllLines("Resources/sessions2.txt"))
            .Select(i => i.Split(';'))
            .Take(10_000)
            .ToArray()
            ;

        var productVariantIds =
            //cVOSContext.ProductVariants.Select(i => i.Id).ToArray();
            sessions.SelectMany().Distinct().ToArray();

        // 0 is used as padded value, use 1-based index for input (sequences) only
        // Output range (labels) is unchanged.
        var productVariantIndices = productVariantIds.Select((i, index) => KeyValuePair.Create(i, index)).ToDictionary();

        const int sequenceLength = 20;

        Encoders = new RNNFactory.Encoders(
                    i => productVariantIndices[i],
                    i => productVariantIds[i],
                    productVariantIds.Length,
                    sequenceLength
                );

        var categoriesCount = cVOSContext.ProductCategories.Select(i => i.Name).Count();

        var dataTable = rNNFactory.ToDataTable(sessions, Encoders);

        var itemFreq = rNNFactory.GetItemFreq(dataTable);

        var (trainArray, testArray) = rNNFactory.Split(dataTable, itemFreq, 0.8m).Select(rNNFactory.PreprocessData);

        Model = rNNFactory.CompileTransformerModel(itemFreq
            , embedDim:
            categoriesCount
            //null
            //128
            );

        rNNFactory.ValidateData(Model, itemFreq);

        if (File.Exists("Resources/RNNWeights.hdf5"))
        {
            Model.load_weights($"Resources/RNNWeights.hdf5");
        }

        var continueTraining = true;

        if (File.Exists("Resources/RNNWeights.hdf5").Not() || continueTraining)
        {
            
            Model = rNNFactory.TrainModel(Model, trainArray, testArray);

            Model.save_weights("Resources/RNNWeights.hdf5");

            logger?.LogInformation("Training done.");

            trainArray = default;
            memoryManager.MayCollectMemory(() => GC.Collect(2, GCCollectionMode.Optimized));

            logger?.LogInformation("Eval result:\n {evalDict}", JsonConvert.SerializeObject(Model.evaluate(testArray.sequences, testArray.labels)));

            //rNNFactory.EvaluateModel(IModel, testArray.sequences, testArray.labels, itemFreq, 5);
        }

        Model.load_weights($"Resources/RNNWeights.hdf5");

        Model.summary();
        rNNFactory.Predict2(Model, [], Encoders);
    }

    public RNNFactory.Encoders Encoders { get; }
    public TFModel Model { get; }
}
