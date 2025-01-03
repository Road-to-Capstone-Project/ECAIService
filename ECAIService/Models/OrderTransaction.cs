using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECAIService.Models;

[Table("order_transaction")]
public partial class OrderTransaction
{
    [Key]
    [Column("id")]
    public string Id { get; set; } = null!;

    [Column("order_id")]
    public string OrderId { get; set; } = null!;

    [Column("version")]
    public int Version { get; set; }

    [Column("amount")]
    public decimal Amount { get; set; }

    [Column("raw_amount", TypeName = "jsonb")]
    public string RawAmount { get; set; } = null!;

    [Column("currency_code")]
    public string CurrencyCode { get; set; } = null!;

    [Column("reference")]
    public string? Reference { get; set; }

    [Column("reference_id")]
    public string? ReferenceId { get; set; }

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

    [ForeignKey("OrderId")]
    [InverseProperty("OrderTransactions")]
    public virtual Order Order { get; set; } = null!;
}
