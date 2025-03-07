using ECAIService.PipelineDto;

using Tokenizers.DotNet;

namespace ECAIService.Services;

public class ExternalTokenizer
{
    private readonly Tokenizer tokenizer;

    public ExternalTokenizer()
    {
        // Path to your downloaded tokenizer JSON file (from Hugging Face for msmarco‑distilbert‑base‑tas‑b)
        string tokenizerPath = @"Resources\Models\sentence-transformers\msmarco-distilbert-base-tas-b\tokenizer.json";

        // Create the tokenizer instance using Tokenizers.DotNet
        tokenizer = new Tokenizer(tokenizerPath);
    }

    public TransformerTokenizedInput Tokenize(string text)
    {
        // Tokenize the text. The Encode method returns an object with the token IDs and (optionally) offsets.
        var encoding = tokenizer.Encode(text);

        // (Optional) You may want to pad/truncate the sequence to a fixed length – for example, 128 tokens.
        int maxLength = 128;
        List<long> inputIds = encoding.Select(id => (long)id).ToList();
        List<long> attentionMask = [];

        // Create a simple padding routine (assuming 0 is the pad ID)
        if (inputIds.Count > maxLength)
        {
            inputIds = inputIds.Take(maxLength).ToList();
            attentionMask = Enumerable.Repeat(1L, maxLength).ToList();
        }
        else
        {
            attentionMask = Enumerable.Repeat(1L, inputIds.Count).ToList();
            while (inputIds.Count < maxLength)
            {
                inputIds.Add(0);
                attentionMask.Add(0);
            }
        }

        return new TransformerTokenizedInput
        {
            InputIds = inputIds.ToArray(),
            AttentionMask = attentionMask.ToArray()
        };
    }
}
