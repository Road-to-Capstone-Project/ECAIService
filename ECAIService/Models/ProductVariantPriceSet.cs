using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECAIService.Models;

[PrimaryKey("VariantId", "PriceSetId")]
[Table("product_variant_price_set")]
[Index("DeletedAt", Name = "IDX_deleted_at_52b23597")]
[Index("Id", Name = "IDX_id_52b23597")]
[Index("PriceSetId", Name = "IDX_price_set_id_52b23597")]
[Index("VariantId", Name = "IDX_variant_id_52b23597")]
public partial class ProductVariantPriceSet
{
    [Key]
    [Column("variant_id")]
    [StringLength(255)]
    public string VariantId { get; set; } = null!;

    [Key]
    [Column("price_set_id")]
    [StringLength(255)]
    public string PriceSetId { get; set; } = null!;

    [Column("id")]
    [StringLength(255)]
    public string Id { get; set; } = null!;

    [Column("created_at")]
    [Precision(0, 0)]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    [Precision(0, 0)]
    public DateTime UpdatedAt { get; set; }

    [Column("deleted_at")]
    [Precision(0, 0)]
    public DateTime? DeletedAt { get; set; }
}
