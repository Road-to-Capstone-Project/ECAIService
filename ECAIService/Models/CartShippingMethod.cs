using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECAIService.Models;

[Table("cart_shipping_method")]
public partial class CartShippingMethod
{
    [Key]
    [Column("id")]
    public string Id { get; set; } = null!;

    [Column("cart_id")]
    public string CartId { get; set; } = null!;

    [Column("name")]
    public string Name { get; set; } = null!;

    [Column("description", TypeName = "jsonb")]
    public string? Description { get; set; }

    [Column("amount")]
    public decimal Amount { get; set; }

    [Column("raw_amount", TypeName = "jsonb")]
    public string RawAmount { get; set; } = null!;

    [Column("is_tax_inclusive")]
    public bool IsTaxInclusive { get; set; }

    [Column("shipping_option_id")]
    public string? ShippingOptionId { get; set; }

    [Column("data", TypeName = "jsonb")]
    public string? Data { get; set; }

    [Column("metadata", TypeName = "jsonb")]
    public string? Metadata { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }

    [Column("deleted_at")]
    public DateTime? DeletedAt { get; set; }

    [ForeignKey("CartId")]
    [InverseProperty("CartShippingMethods")]
    public virtual Cart Cart { get; set; } = null!;

    [InverseProperty("ShippingMethod")]
    public virtual ICollection<CartShippingMethodAdjustment> CartShippingMethodAdjustments { get; set; } = new List<CartShippingMethodAdjustment>();

    [InverseProperty("ShippingMethod")]
    public virtual ICollection<CartShippingMethodTaxLine> CartShippingMethodTaxLines { get; set; } = new List<CartShippingMethodTaxLine>();
}
