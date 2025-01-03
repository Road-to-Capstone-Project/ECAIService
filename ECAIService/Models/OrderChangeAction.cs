using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECAIService.Models;

[Table("order_change_action")]
[Index("DeletedAt", Name = "IDX_order_change_action_deleted_at")]
[Index("OrderChangeId", Name = "IDX_order_change_action_order_change_id")]
[Index("OrderId", Name = "IDX_order_change_action_order_id")]
[Index("Ordering", Name = "IDX_order_change_action_ordering")]
public partial class OrderChangeAction
{
    [Key]
    [Column("id")]
    public string Id { get; set; } = null!;

    [Column("order_id")]
    public string? OrderId { get; set; }

    [Column("version")]
    public int? Version { get; set; }

    [Column("ordering")]
    public long Ordering { get; set; }

    [Column("order_change_id")]
    public string? OrderChangeId { get; set; }

    [Column("reference")]
    public string? Reference { get; set; }

    [Column("reference_id")]
    public string? ReferenceId { get; set; }

    [Column("action")]
    public string Action { get; set; } = null!;

    [Column("details", TypeName = "jsonb")]
    public string? Details { get; set; }

    [Column("amount")]
    public decimal? Amount { get; set; }

    [Column("raw_amount", TypeName = "jsonb")]
    public string? RawAmount { get; set; }

    [Column("internal_note")]
    public string? InternalNote { get; set; }

    [Column("applied")]
    public bool Applied { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }

    [Column("deleted_at")]
    public DateTime? DeletedAt { get; set; }

    [Column("return_id")]
    public string? ReturnId { get; set; }

    [Column("claim_id")]
    public string? ClaimId { get; set; }

    [Column("exchange_id")]
    public string? ExchangeId { get; set; }

    [ForeignKey("OrderChangeId")]
    [InverseProperty("OrderChangeActions")]
    public virtual OrderChange? OrderChange { get; set; }
}
