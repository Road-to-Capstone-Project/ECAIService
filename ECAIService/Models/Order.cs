using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECAIService.Models;

[Table("order")]
[Index("DeletedAt", Name = "IDX_order_deleted_at")]
public partial class Order
{
    [Key]
    [Column("id")]
    public string Id { get; set; } = null!;

    [Column("region_id")]
    public string? RegionId { get; set; }

    [Column("display_id")]
    public int? DisplayId { get; set; }

    [Column("customer_id")]
    public string? CustomerId { get; set; }

    [Column("version")]
    public int Version { get; set; }

    [Column("sales_channel_id")]
    public string? SalesChannelId { get; set; }

    [Column("is_draft_order")]
    public bool IsDraftOrder { get; set; }

    [Column("email")]
    public string? Email { get; set; }

    [Column("currency_code")]
    public string CurrencyCode { get; set; } = null!;

    [Column("shipping_address_id")]
    public string? ShippingAddressId { get; set; }

    [Column("billing_address_id")]
    public string? BillingAddressId { get; set; }

    [Column("no_notification")]
    public bool? NoNotification { get; set; }

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

    [ForeignKey("BillingAddressId")]
    [InverseProperty("OrderBillingAddresses")]
    public virtual OrderAddress? BillingAddress { get; set; }

    [InverseProperty("Order")]
    public virtual ICollection<OrderChange> OrderChanges { get; set; } = new List<OrderChange>();

    [InverseProperty("Order")]
    public virtual ICollection<OrderCreditLine> OrderCreditLines { get; set; } = new List<OrderCreditLine>();

    [InverseProperty("Order")]
    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    [InverseProperty("Order")]
    public virtual ICollection<OrderShipping> OrderShippings { get; set; } = new List<OrderShipping>();

    [InverseProperty("Order")]
    public virtual ICollection<OrderTransaction> OrderTransactions { get; set; } = new List<OrderTransaction>();

    [ForeignKey("ShippingAddressId")]
    [InverseProperty("OrderShippingAddresses")]
    public virtual OrderAddress? ShippingAddress { get; set; }
}
