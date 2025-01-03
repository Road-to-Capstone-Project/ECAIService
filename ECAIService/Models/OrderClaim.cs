using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECAIService.Models;

[Table("order_claim")]
public partial class OrderClaim
{
    [Key]
    [Column("id")]
    public string Id { get; set; } = null!;

    [Column("order_id")]
    public string OrderId { get; set; } = null!;

    [Column("return_id")]
    public string? ReturnId { get; set; }

    [Column("order_version")]
    public int OrderVersion { get; set; }

    [Column("display_id")]
    public int DisplayId { get; set; }

    [Column("no_notification")]
    public bool? NoNotification { get; set; }

    [Column("refund_amount")]
    public decimal? RefundAmount { get; set; }

    [Column("raw_refund_amount", TypeName = "jsonb")]
    public string? RawRefundAmount { get; set; }

    [Column("metadata", TypeName = "jsonb")]
    public string? Metadata { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }

    [Column("deleted_at")]
    public DateTime? DeletedAt { get; set; }

    [Column("canceled_at")]
    public DateTime? CanceledAt { get; set; }

    [Column("created_by")]
    public string? CreatedBy { get; set; }
}
