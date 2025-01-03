using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECAIService.Models;

[Table("order_exchange_item")]
public partial class OrderExchangeItem
{
    [Key]
    [Column("id")]
    public string Id { get; set; } = null!;

    [Column("exchange_id")]
    public string ExchangeId { get; set; } = null!;

    [Column("item_id")]
    public string ItemId { get; set; } = null!;

    [Column("quantity")]
    public decimal Quantity { get; set; }

    [Column("raw_quantity", TypeName = "jsonb")]
    public string RawQuantity { get; set; } = null!;

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
}
