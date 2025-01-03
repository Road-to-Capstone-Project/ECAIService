using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECAIService.Models;

[Table("order_change")]
[Index("ChangeType", Name = "IDX_order_change_change_type")]
[Index("DeletedAt", Name = "IDX_order_change_deleted_at")]
[Index("OrderId", Name = "IDX_order_change_order_id")]
[Index("OrderId", "Version", Name = "IDX_order_change_order_id_version")]
[Index("Status", Name = "IDX_order_change_status")]
public partial class OrderChange
{
    [Key]
    [Column("id")]
    public string Id { get; set; } = null!;

    [Column("order_id")]
    public string OrderId { get; set; } = null!;

    [Column("version")]
    public int Version { get; set; }

    [Column("description")]
    public string? Description { get; set; }

    [Column("status")]
    public string Status { get; set; } = null!;

    [Column("internal_note")]
    public string? InternalNote { get; set; }

    [Column("created_by")]
    public string? CreatedBy { get; set; }

    [Column("requested_by")]
    public string? RequestedBy { get; set; }

    [Column("requested_at")]
    public DateTime? RequestedAt { get; set; }

    [Column("confirmed_by")]
    public string? ConfirmedBy { get; set; }

    [Column("confirmed_at")]
    public DateTime? ConfirmedAt { get; set; }

    [Column("declined_by")]
    public string? DeclinedBy { get; set; }

    [Column("declined_reason")]
    public string? DeclinedReason { get; set; }

    [Column("metadata", TypeName = "jsonb")]
    public string? Metadata { get; set; }

    [Column("declined_at")]
    public DateTime? DeclinedAt { get; set; }

    [Column("canceled_by")]
    public string? CanceledBy { get; set; }

    [Column("canceled_at")]
    public DateTime? CanceledAt { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }

    [Column("change_type")]
    public string? ChangeType { get; set; }

    [Column("deleted_at")]
    public DateTime? DeletedAt { get; set; }

    [Column("return_id")]
    public string? ReturnId { get; set; }

    [Column("claim_id")]
    public string? ClaimId { get; set; }

    [Column("exchange_id")]
    public string? ExchangeId { get; set; }

    [ForeignKey("OrderId")]
    [InverseProperty("OrderChanges")]
    public virtual Order Order { get; set; } = null!;

    [InverseProperty("OrderChange")]
    public virtual ICollection<OrderChangeAction> OrderChangeActions { get; set; } = new List<OrderChangeAction>();
}
