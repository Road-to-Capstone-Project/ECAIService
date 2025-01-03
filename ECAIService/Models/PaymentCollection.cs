using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECAIService.Models;

[Table("payment_collection")]
public partial class PaymentCollection
{
    [Key]
    [Column("id")]
    public string Id { get; set; } = null!;

    [Column("currency_code")]
    public string CurrencyCode { get; set; } = null!;

    [Column("amount")]
    public decimal Amount { get; set; }

    [Column("raw_amount", TypeName = "jsonb")]
    public string RawAmount { get; set; } = null!;

    [Column("authorized_amount")]
    public decimal? AuthorizedAmount { get; set; }

    [Column("raw_authorized_amount", TypeName = "jsonb")]
    public string? RawAuthorizedAmount { get; set; }

    [Column("captured_amount")]
    public decimal? CapturedAmount { get; set; }

    [Column("raw_captured_amount", TypeName = "jsonb")]
    public string? RawCapturedAmount { get; set; }

    [Column("refunded_amount")]
    public decimal? RefundedAmount { get; set; }

    [Column("raw_refunded_amount", TypeName = "jsonb")]
    public string? RawRefundedAmount { get; set; }

    [Column("region_id")]
    public string RegionId { get; set; } = null!;

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }

    [Column("deleted_at")]
    public DateTime? DeletedAt { get; set; }

    [Column("completed_at")]
    public DateTime? CompletedAt { get; set; }

    [Column("status")]
    public string Status { get; set; } = null!;

    [Column("metadata", TypeName = "jsonb")]
    public string? Metadata { get; set; }

    [InverseProperty("PaymentCollection")]
    public virtual ICollection<PaymentSession> PaymentSessions { get; set; } = new List<PaymentSession>();

    [InverseProperty("PaymentCollection")]
    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    [ForeignKey("PaymentCollectionId")]
    [InverseProperty("PaymentCollections")]
    public virtual ICollection<PaymentProvider> PaymentProviders { get; set; } = new List<PaymentProvider>();
}
