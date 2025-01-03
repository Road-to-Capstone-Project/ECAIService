using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECAIService.Models;

[Table("image")]
public partial class Image
{
    [Key]
    [Column("id")]
    public string Id { get; set; } = null!;

    [Column("url")]
    public string Url { get; set; } = null!;

    [Column("metadata", TypeName = "jsonb")]
    public string? Metadata { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }

    [Column("deleted_at")]
    public DateTime? DeletedAt { get; set; }

    [Column("rank")]
    public int Rank { get; set; }

    [Column("product_id")]
    public string ProductId { get; set; } = null!;

    [ForeignKey("ProductId")]
    [InverseProperty("Images")]
    public virtual Product Product { get; set; } = null!;
}
