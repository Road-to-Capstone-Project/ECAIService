using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECAIService.Models;

[Table("order_shipping_method_adjustment")]
public partial class OrderShippingMethodAdjustment
{
    [Key]
    [Column("id")]
    public string Id { get; set; } = null!;

    [Column("description")]
    public string? Description { get; set; }

    [Column("promotion_id")]
    public string? PromotionId { get; set; }

    [Column("code")]
    public string? Code { get; set; }

    [Column("amount")]
    public decimal Amount { get; set; }

    [Column("raw_amount", TypeName = "jsonb")]
    public string RawAmount { get; set; } = null!;

    [Column("provider_id")]
    public string? ProviderId { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }

    [Column("shipping_method_id")]
    public string ShippingMethodId { get; set; } = null!;

    [Column("deleted_at")]
    public DateTime? DeletedAt { get; set; }

    [ForeignKey("ShippingMethodId")]
    [InverseProperty("OrderShippingMethodAdjustments")]
    public virtual OrderShippingMethod ShippingMethod { get; set; } = null!;
}
