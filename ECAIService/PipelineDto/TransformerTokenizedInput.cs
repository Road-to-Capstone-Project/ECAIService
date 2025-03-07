using Microsoft.ML.Data;

namespace ECAIService.PipelineDto;

public record class TransformerTokenizedInput
{
    [VectorType(1, 128)]
    [ColumnName("input_ids")]
    public long[]? InputIds { get; set; }

    [VectorType(1, 128)]
    [ColumnName("attention_mask")]
    public long[]? AttentionMask { get; set; }
}
