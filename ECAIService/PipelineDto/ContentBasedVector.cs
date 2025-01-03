using Pgvector;

namespace ECAIService.PipelineDto;

public class ContentBasedVector
{
    public string VariantId { get; set; } = null!;
    public Vector Embeddings { get; set; }
}
