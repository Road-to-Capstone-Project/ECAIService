using Microsoft.ML.Data;

namespace ECAIService.PipelineDto;

public record SentenceEmbeddingOutput
{
    [VectorType(1, 768)]
    [ColumnName("last_hidden_state")]
    public float[]? SentenceEmbedding { get; set; }
}
