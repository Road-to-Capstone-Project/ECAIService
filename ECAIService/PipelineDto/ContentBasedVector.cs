using Pgvector;

namespace ECAIService.PipelineDto;

public class ContentBasedVector
{
    public string? VariantId { get; set; }
    public Vector? Embeddings { get; set; }
}
