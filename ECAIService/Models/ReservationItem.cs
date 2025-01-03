using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECAIService.Models;

[Table("reservation_item")]
public partial class ReservationItem
{
    [Key]
    [Column("id")]
    public string Id { get; set; } = null!;

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }

    [Column("deleted_at")]
    public DateTime? DeletedAt { get; set; }

    [Column("line_item_id")]
    public string? LineItemId { get; set; }

    [Column("location_id")]
    public string LocationId { get; set; } = null!;

    [Column("quantity")]
    public decimal Quantity { get; set; }

    [Column("external_id")]
    public string? ExternalId { get; set; }

    [Column("description")]
    public string? Description { get; set; }

    [Column("created_by")]
    public string? CreatedBy { get; set; }

    [Column("metadata", TypeName = "jsonb")]
    public string? Metadata { get; set; }

    [Column("inventory_item_id")]
    public string InventoryItemId { get; set; } = null!;

    [Column("allow_backorder")]
    public bool? AllowBackorder { get; set; }

    [Column("raw_quantity", TypeName = "jsonb")]
    public string? RawQuantity { get; set; }

    [ForeignKey("InventoryItemId")]
    [InverseProperty("ReservationItems")]
    public virtual InventoryItem InventoryItem { get; set; } = null!;
}
