using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECAIService.Models;

[Table("fulfillment_item")]
public partial class FulfillmentItem
{
    [Key]
    [Column("id")]
    public string Id { get; set; } = null!;

    [Column("title")]
    public string Title { get; set; } = null!;

    [Column("sku")]
    public string Sku { get; set; } = null!;

    [Column("barcode")]
    public string Barcode { get; set; } = null!;

    [Column("quantity")]
    public decimal Quantity { get; set; }

    [Column("raw_quantity", TypeName = "jsonb")]
    public string RawQuantity { get; set; } = null!;

    [Column("line_item_id")]
    public string? LineItemId { get; set; }

    [Column("inventory_item_id")]
    public string? InventoryItemId { get; set; }

    [Column("fulfillment_id")]
    public string FulfillmentId { get; set; } = null!;

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }

    [Column("deleted_at")]
    public DateTime? DeletedAt { get; set; }

    [ForeignKey("FulfillmentId")]
    [InverseProperty("FulfillmentItems")]
    public virtual Fulfillment Fulfillment { get; set; } = null!;
}
