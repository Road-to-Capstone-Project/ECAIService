using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECAIService.Models;

[Table("product_option")]
[Index("DeletedAt", Name = "IDX_product_option_deleted_at")]
public partial class ProductOption
{
    [Key]
    [Column("id")]
    public string Id { get; set; } = null!;

    [Column("title")]
    public string Title { get; set; } = null!;

    [Column("product_id")]
    public string ProductId { get; set; } = null!;

    [Column("metadata", TypeName = "jsonb")]
    public string? Metadata { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }

    [Column("deleted_at")]
    public DateTime? DeletedAt { get; set; }

    [ForeignKey("ProductId")]
    [InverseProperty("ProductOptions")]
    public virtual Product Product { get; set; } = null!;

    [InverseProperty("Option")]
    public virtual ICollection<ProductOptionValue> ProductOptionValues { get; set; } = new List<ProductOptionValue>();
}
