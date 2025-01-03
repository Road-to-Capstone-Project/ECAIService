using Microsoft.ML.Data;

namespace ECAIService.PipelineDto;

public class ContentBasedVBuffer
{
    public string VariantId { get; set; } = null!;
    public VBuffer<double> Embeddings { get; set; }
}
