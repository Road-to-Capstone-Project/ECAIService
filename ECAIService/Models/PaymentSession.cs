using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECAIService.Models;

[Table("payment_session")]
[Index("DeletedAt", Name = "IDX_payment_session_deleted_at")]
public partial class PaymentSession
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

    [Column("provider_id")]
    public string ProviderId { get; set; } = null!;

    [Column("data", TypeName = "jsonb")]
    public string Data { get; set; } = null!;

    [Column("context", TypeName = "jsonb")]
    public string? Context { get; set; }

    [Column("status")]
    public string Status { get; set; } = null!;

    [Column("authorized_at")]
    public DateTime? AuthorizedAt { get; set; }

    [Column("payment_collection_id")]
    public string PaymentCollectionId { get; set; } = null!;

    [Column("metadata", TypeName = "jsonb")]
    public string? Metadata { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }

    [Column("deleted_at")]
    public DateTime? DeletedAt { get; set; }

    [ForeignKey("PaymentCollectionId")]
    [InverseProperty("PaymentSessions")]
    public virtual PaymentCollection PaymentCollection { get; set; } = null!;
}
