using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

using ECAIService.Models;

using Microsoft.EntityFrameworkCore;

using Pgvector;

namespace ECAIService.MLModelTables;

public class VariantTextEmbedding
{
    [Key]
    [Length(minimumLength:0, maximumLength: 255)]
    public required string VariantId { get; set; } = null!;

    public ProductVariant Variant { get; set; } = null!;

    [Column(TypeName = "vector(768)")]
    public required Vector Embeddings { get; set; } = null!;
}
