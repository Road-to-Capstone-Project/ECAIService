using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECAIService.Models;

[Table("order_shipping")]
public partial class OrderShipping
{
    [Key]
    [Column("id")]
    public string Id { get; set; } = null!;

    [Column("order_id")]
    public string OrderId { get; set; } = null!;

    [Column("version")]
    public int Version { get; set; }

    [Column("shipping_method_id")]
    public string ShippingMethodId { get; set; } = null!;

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
    [InverseProperty("OrderShippings")]
    public virtual Order Order { get; set; } = null!;
}
