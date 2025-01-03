using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECAIService.Models;

[Table("order_item")]
public partial class OrderItem
{
    [Key]
    [Column("id")]
    public string Id { get; set; } = null!;

    [Column("order_id")]
    public string OrderId { get; set; } = null!;

    [Column("version")]
    public int Version { get; set; }

    [Column("item_id")]
    public string ItemId { get; set; } = null!;

    [Column("quantity")]
    public decimal Quantity { get; set; }

    [Column("raw_quantity", TypeName = "jsonb")]
    public string RawQuantity { get; set; } = null!;

    [Column("fulfilled_quantity")]
    public decimal FulfilledQuantity { get; set; }

    [Column("raw_fulfilled_quantity", TypeName = "jsonb")]
    public string RawFulfilledQuantity { get; set; } = null!;

    [Column("shipped_quantity")]
    public decimal ShippedQuantity { get; set; }

    [Column("raw_shipped_quantity", TypeName = "jsonb")]
    public string RawShippedQuantity { get; set; } = null!;

    [Column("return_requested_quantity")]
    public decimal ReturnRequestedQuantity { get; set; }

    [Column("raw_return_requested_quantity", TypeName = "jsonb")]
    public string RawReturnRequestedQuantity { get; set; } = null!;

    [Column("return_received_quantity")]
    public decimal ReturnReceivedQuantity { get; set; }

    [Column("raw_return_received_quantity", TypeName = "jsonb")]
    public string RawReturnReceivedQuantity { get; set; } = null!;

    [Column("return_dismissed_quantity")]
    public decimal ReturnDismissedQuantity { get; set; }

    [Column("raw_return_dismissed_quantity", TypeName = "jsonb")]
    public string RawReturnDismissedQuantity { get; set; } = null!;

    [Column("written_off_quantity")]
    public decimal WrittenOffQuantity { get; set; }

    [Column("raw_written_off_quantity", TypeName = "jsonb")]
    public string RawWrittenOffQuantity { get; set; } = null!;

    [Column("metadata", TypeName = "jsonb")]
    public string? Metadata { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }

    [Column("deleted_at")]
    public DateTime? DeletedAt { get; set; }

    [Column("delivered_quantity")]
    public decimal DeliveredQuantity { get; set; }

    [Column("raw_delivered_quantity", TypeName = "jsonb")]
    public string RawDeliveredQuantity { get; set; } = null!;

    [Column("unit_price")]
    public decimal? UnitPrice { get; set; }

    [Column("raw_unit_price", TypeName = "jsonb")]
    public string? RawUnitPrice { get; set; }

    [Column("compare_at_unit_price")]
    public decimal? CompareAtUnitPrice { get; set; }

    [Column("raw_compare_at_unit_price", TypeName = "jsonb")]
    public string? RawCompareAtUnitPrice { get; set; }

    [ForeignKey("ItemId")]
    [InverseProperty("OrderItems")]
    public virtual OrderLineItem Item { get; set; } = null!;

    [ForeignKey("OrderId")]
    [InverseProperty("OrderItems")]
    public virtual Order Order { get; set; } = null!;

    [InverseProperty("Totals")]
    public virtual ICollection<OrderLineItem> OrderLineItems { get; set; } = new List<OrderLineItem>();
}
