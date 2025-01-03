using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECAIService.Models;

[Table("payment")]
[Index("PaymentSessionId", Name = "IDX_payment_payment_session_id")]
[Index("PaymentSessionId", Name = "payment_payment_session_id_unique", IsUnique = true)]
public partial class Payment
{
    [Key]
    [Column("id")]
    public string Id { get; set; } = null!;

    [Column("amount")]
    public decimal Amount { get; set; }

    [Column("raw_amount", TypeName = "jsonb")]
    public string RawAmount { get; set; } = null!;

    [Column("currency_code")]
    public string CurrencyCode { get; set; } = null!;

    [Column("provider_id")]
    public string ProviderId { get; set; } = null!;

    [Column("cart_id")]
    public string? CartId { get; set; }

    [Column("order_id")]
    public string? OrderId { get; set; }

    [Column("customer_id")]
    public string? CustomerId { get; set; }

    [Column("data", TypeName = "jsonb")]
    public string? Data { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }

    [Column("deleted_at")]
    public DateTime? DeletedAt { get; set; }

    [Column("captured_at")]
    public DateTime? CapturedAt { get; set; }

    [Column("canceled_at")]
    public DateTime? CanceledAt { get; set; }

    [Column("payment_collection_id")]
    public string PaymentCollectionId { get; set; } = null!;

    [Column("payment_session_id")]
    public string PaymentSessionId { get; set; } = null!;

    [Column("metadata", TypeName = "jsonb")]
    public string? Metadata { get; set; }

    [InverseProperty("Payment")]
    public virtual ICollection<Capture> Captures { get; set; } = new List<Capture>();

    [ForeignKey("PaymentCollectionId")]
    [InverseProperty("Payments")]
    public virtual PaymentCollection PaymentCollection { get; set; } = null!;

    [InverseProperty("Payment")]
    public virtual ICollection<Refund> Refunds { get; set; } = new List<Refund>();
}
