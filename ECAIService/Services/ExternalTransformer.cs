using ECAIService.PipelineDto;

using Microsoft.ML;
using Microsoft.ML.Transforms.Onnx;

using static ECAIService.RatingMLModel;

namespace ECAIService.Services;

public class ExternalTransformer
{
    private readonly ExternalTokenizer tokenizer;
    private readonly MLContext mlContext;
    private readonly OnnxScoringEstimator pipeline;

    public ExternalTransformer(ExternalTokenizer tokenizer,
        MLContext mlContext)
    {
        this.tokenizer = tokenizer;
        this.mlContext = mlContext;

        // Path to your exported ONNX model for msmarco‑distilbert‑base‑tas‑b.
        string onnxModelPath = @"Resources\Models\sentence-transformers\msmarco-distilbert-base-tas-b\model.onnx";

        // Create the pipeline. Ensure that input and output column names exactly match those in the model.
        pipeline = mlContext.Transforms.ApplyOnnxModel(
            modelFile: onnxModelPath,
            inputColumnNames: ["input_ids", "attention_mask"],
            outputColumnNames: ["last_hidden_state"],
            shapeDictionary: new Dictionary<string, int[]>
            {
        { "input_ids", [ 1, 128 ] },
        { "attention_mask", [ 1, 128 ] },
                // Add token_type_ids if your model requires them.
            },
            gpuDeviceId: null,
            fallbackToCpu: true
            );
    }

    public IEnumerable<SentenceEmbeddingOutput> Transform(string text)
    {

        // Create an instance of ModelInput with token IDs and attention mask from step 2.
        var modelInput = tokenizer.Tokenize(text);
        // Load the input data into an IDataView.
        IDataView dataView = mlContext.Data.LoadFromEnumerable([ modelInput ]);

        // Run the pipeline to perform inference.
        var transformedData = pipeline.Fit(dataView).Transform(dataView);

        // (Assuming the ONNX model produces an output column named "...")
        var results = mlContext.Data.CreateEnumerable<SentenceEmbeddingOutput>(transformedData, reuseRowObject: false);

        return results;
    }
}
