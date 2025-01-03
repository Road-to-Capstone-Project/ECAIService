using Microsoft.ML.Data;

using Pgvector;

namespace ECAIService.PipelineDto;

public record class ContentBasedVectorEncoded
{
    public string VariantId { get; set; }
    public VBuffer<double> Categories { get; set; }
    public int Weight { get; set; }
    public double Price { get; set; }

    public Vector ToVector()
    {
        var buffer = new List<float>();
        buffer.Add(Weight);
        buffer.Add((float)Price);
        buffer.AddRange(Categories.GetValues().ToArray().Select(i => (float)i));
        return new Vector(buffer.ToArray());
    }

    public VBuffer<double> ToVBuffer()
    {
        var buffer = new List<double>
        {
            Weight,
            Price
        };
        buffer.AddRange(Categories.GetValues().ToArray());
        return new VBuffer<double>(Categories.Length, [.. buffer]);
    }
}
