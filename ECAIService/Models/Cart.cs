using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECAIService.Models;

[Table("cart")]
[Index("CurrencyCode", Name = "IDX_cart_currency_code")]
public partial class Cart
{
    [Key]
    [Column("id")]
    public string Id { get; set; } = null!;

    [Column("region_id")]
    public string? RegionId { get; set; }

    [Column("customer_id")]
    public string? CustomerId { get; set; }

    [Column("sales_channel_id")]
    public string? SalesChannelId { get; set; }

    [Column("email")]
    public string? Email { get; set; }

    [Column("currency_code")]
    public string CurrencyCode { get; set; } = null!;

    [Column("shipping_address_id")]
    public string? ShippingAddressId { get; set; }

    [Column("billing_address_id")]
    public string? BillingAddressId { get; set; }

    [Column("metadata", TypeName = "jsonb")]
    public string? Metadata { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }

    [Column("deleted_at")]
    public DateTime? DeletedAt { get; set; }

    [Column("completed_at")]
    public DateTime? CompletedAt { get; set; }

    [ForeignKey("BillingAddressId")]
    [InverseProperty("CartBillingAddresses")]
    public virtual CartAddress? BillingAddress { get; set; }

    [InverseProperty("Cart")]
    public virtual ICollection<CartLineItem> CartLineItems { get; set; } = new List<CartLineItem>();

    [InverseProperty("Cart")]
    public virtual ICollection<CartShippingMethod> CartShippingMethods { get; set; } = new List<CartShippingMethod>();

    [ForeignKey("ShippingAddressId")]
    [InverseProperty("CartShippingAddresses")]
    public virtual CartAddress? ShippingAddress { get; set; }
}
