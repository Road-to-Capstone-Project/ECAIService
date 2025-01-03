using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECAIService.Models;

[Table("product_variant")]
[Index("DeletedAt", Name = "IDX_product_variant_deleted_at")]
public partial class ProductVariant
{
    [Key]
    [Column("id")]
    public string Id { get; set; } = null!;

    [Column("title")]
    public string Title { get; set; } = null!;

    [Column("sku")]
    public string? Sku { get; set; }

    [Column("barcode")]
    public string? Barcode { get; set; }

    [Column("ean")]
    public string? Ean { get; set; }

    [Column("upc")]
    public string? Upc { get; set; }

    [Column("allow_backorder")]
    public bool AllowBackorder { get; set; }

    [Column("manage_inventory")]
    public bool ManageInventory { get; set; }

    [Column("hs_code")]
    public string? HsCode { get; set; }

    [Column("origin_country")]
    public string? OriginCountry { get; set; }

    [Column("mid_code")]
    public string? MidCode { get; set; }

    [Column("material")]
    public string? Material { get; set; }

    [Column("weight")]
    public int? Weight { get; set; }

    [Column("length")]
    public int? Length { get; set; }

    [Column("height")]
    public int? Height { get; set; }

    [Column("width")]
    public int? Width { get; set; }

    [Column("metadata", TypeName = "jsonb")]
    public string? Metadata { get; set; }

    [Column("variant_rank")]
    public int? VariantRank { get; set; }

    [Column("product_id")]
    public string? ProductId { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }

    [Column("deleted_at")]
    public DateTime? DeletedAt { get; set; }

    [ForeignKey("ProductId")]
    [InverseProperty("ProductVariants")]
    public virtual Product? Product { get; set; }

    [ForeignKey("VariantId")]
    [InverseProperty("Variants")]
    public virtual ICollection<ProductOptionValue> OptionValues { get; set; } = new List<ProductOptionValue>();
}
