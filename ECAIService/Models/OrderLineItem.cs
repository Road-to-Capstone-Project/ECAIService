using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECAIService.Models;

[Table("order_line_item")]
public partial class OrderLineItem
{
    [Key]
    [Column("id")]
    public string Id { get; set; } = null!;

    [Column("totals_id")]
    public string? TotalsId { get; set; }

    [Column("title")]
    public string Title { get; set; } = null!;

    [Column("subtitle")]
    public string? Subtitle { get; set; }

    [Column("thumbnail")]
    public string? Thumbnail { get; set; }

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

    [Column("is_custom_price")]
    public bool IsCustomPrice { get; set; }

    [Column("product_type_id")]
    public string? ProductTypeId { get; set; }

    [InverseProperty("Item")]
    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    [InverseProperty("Item")]
    public virtual ICollection<OrderLineItemAdjustment> OrderLineItemAdjustments { get; set; } = new List<OrderLineItemAdjustment>();

    [InverseProperty("Item")]
    public virtual ICollection<OrderLineItemTaxLine> OrderLineItemTaxLines { get; set; } = new List<OrderLineItemTaxLine>();

    [ForeignKey("TotalsId")]
    [InverseProperty("OrderLineItems")]
    public virtual OrderItem? Totals { get; set; }
}
