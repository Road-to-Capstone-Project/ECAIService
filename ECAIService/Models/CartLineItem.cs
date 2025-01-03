using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECAIService.Models;

[Table("cart_line_item")]
public partial class CartLineItem
{
    [Key]
    [Column("id")]
    public string Id { get; set; } = null!;

    [Column("cart_id")]
    public string CartId { get; set; } = null!;

    [Column("title")]
    public string Title { get; set; } = null!;

    [Column("subtitle")]
    public string? Subtitle { get; set; }

    [Column("thumbnail")]
    public string? Thumbnail { get; set; }

    [Column("quantity")]
    public int Quantity { get; set; }

    [Column("variant_id")]
    public string? VariantId { get; set; }

    [Column("product_id")]
    public string? ProductId { get; set; }

    [Column("product_title")]
    public string? ProductTitle { get; set; }

    [Column("product_description")]
    public string? ProductDescription { get; set; }

    [Column("product_subtitle")]
    public string? ProductSubtitle { get; set; }

    [Column("product_type")]
    public string? ProductType { get; set; }

    [Column("product_collection")]
    public string? ProductCollection { get; set; }

    [Column("product_handle")]
    public string? ProductHandle { get; set; }

    [Column("variant_sku")]
    public string? VariantSku { get; set; }

    [Column("variant_barcode")]
    public string? VariantBarcode { get; set; }

    [Column("variant_title")]
    public string? VariantTitle { get; set; }

    [Column("variant_option_values", TypeName = "jsonb")]
    public string? VariantOptionValues { get; set; }

    [Column("requires_shipping")]
    public bool RequiresShipping { get; set; }

    [Column("is_discountable")]
    public bool IsDiscountable { get; set; }

    [Column("is_tax_inclusive")]
    public bool IsTaxInclusive { get; set; }

    [Column("compare_at_unit_price")]
    public decimal? CompareAtUnitPrice { get; set; }

    [Column("raw_compare_at_unit_price", TypeName = "jsonb")]
    public string? RawCompareAtUnitPrice { get; set; }

    [Column("unit_price")]
    public decimal UnitPrice { get; set; }

    [Column("raw_unit_price", TypeName = "jsonb")]
    public string RawUnitPrice { get; set; } = null!;

    [Column("metadata", TypeName = "jsonb")]
    public string? Metadata { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }

    [Column("deleted_at")]
    public DateTime? DeletedAt { get; set; }

    [Column("product_type_id")]
    public string? ProductTypeId { get; set; }

    [Column("is_custom_price")]
    public bool IsCustomPrice { get; set; }

    [ForeignKey("CartId")]
    [InverseProperty("CartLineItems")]
    public virtual Cart Cart { get; set; } = null!;

    [InverseProperty("Item")]
    public virtual ICollection<CartLineItemAdjustment> CartLineItemAdjustments { get; set; } = new List<CartLineItemAdjustment>();

    [InverseProperty("Item")]
    public virtual ICollection<CartLineItemTaxLine> CartLineItemTaxLines { get; set; } = new List<CartLineItemTaxLine>();
}
