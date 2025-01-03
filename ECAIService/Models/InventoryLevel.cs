using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECAIService.Models;

[Table("inventory_level")]
public partial class InventoryLevel
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

    [Column("inventory_item_id")]
    public string InventoryItemId { get; set; } = null!;

    [Column("location_id")]
    public string LocationId { get; set; } = null!;

    [Column("stocked_quantity")]
    public decimal StockedQuantity { get; set; }

    [Column("reserved_quantity")]
    public decimal ReservedQuantity { get; set; }

    [Column("incoming_quantity")]
    public decimal IncomingQuantity { get; set; }

    [Column("metadata", TypeName = "jsonb")]
    public string? Metadata { get; set; }

    [Column("raw_stocked_quantity", TypeName = "jsonb")]
    public string? RawStockedQuantity { get; set; }

    [Column("raw_reserved_quantity", TypeName = "jsonb")]
    public string? RawReservedQuantity { get; set; }

    [Column("raw_incoming_quantity", TypeName = "jsonb")]
    public string? RawIncomingQuantity { get; set; }

    [ForeignKey("InventoryItemId")]
    [InverseProperty("InventoryLevels")]
    public virtual InventoryItem InventoryItem { get; set; } = null!;
}
