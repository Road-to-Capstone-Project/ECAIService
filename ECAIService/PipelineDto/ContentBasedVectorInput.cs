namespace ECAIService.PipelineDto;

public record class ContentBasedVectorInput
{
    public string VariantId { get; set; }
    public string[] Categories { get; set; }
    public int Weight { get; set; }
    public double Price { get; set; }
}
