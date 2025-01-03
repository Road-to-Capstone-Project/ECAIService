using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECAIService.Models;

[Table("return_item")]
public partial class ReturnItem
{
    [Key]
    [Column("id")]
    public string Id { get; set; } = null!;

    [Column("return_id")]
    public string ReturnId { get; set; } = null!;

    [Column("reason_id")]
    public string? ReasonId { get; set; }

    [Column("item_id")]
    public string ItemId { get; set; } = null!;

    [Column("quantity")]
    public decimal Quantity { get; set; }

    [Column("raw_quantity", TypeName = "jsonb")]
    public string RawQuantity { get; set; } = null!;

    [Column("received_quantity")]
    public decimal ReceivedQuantity { get; set; }

    [Column("raw_received_quantity", TypeName = "jsonb")]
    public string RawReceivedQuantity { get; set; } = null!;

    [Column("note")]
    public string? Note { get; set; }

    [Column("metadata", TypeName = "jsonb")]
    public string? Metadata { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }

    [Column("deleted_at")]
    public DateTime? DeletedAt { get; set; }

    [Column("damaged_quantity")]
    public decimal DamagedQuantity { get; set; }

    [Column("raw_damaged_quantity", TypeName = "jsonb")]
    public string RawDamagedQuantity { get; set; } = null!;
}
