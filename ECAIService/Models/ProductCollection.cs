using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECAIService.Models;

[Table("product_collection")]
[Index("DeletedAt", Name = "IDX_product_category_deleted_at")]
[Index("DeletedAt", Name = "IDX_product_collection_deleted_at")]
public partial class ProductCollection
{
    [Key]
    [Column("id")]
    public string Id { get; set; } = null!;

    [Column("title")]
    public string Title { get; set; } = null!;

    [Column("handle")]
    public string Handle { get; set; } = null!;

    [Column("metadata", TypeName = "jsonb")]
    public string? Metadata { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }

    [Column("deleted_at")]
    public DateTime? DeletedAt { get; set; }

    [InverseProperty("Collection")]
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
