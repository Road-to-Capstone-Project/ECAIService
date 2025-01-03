using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECAIService.Models;

[Table("fulfillment")]
public partial class Fulfillment
{
    [Key]
    [Column("id")]
    public string Id { get; set; } = null!;

    [Column("location_id")]
    public string LocationId { get; set; } = null!;

    [Column("packed_at")]
    public DateTime? PackedAt { get; set; }

    [Column("shipped_at")]
    public DateTime? ShippedAt { get; set; }

    [Column("delivered_at")]
    public DateTime? DeliveredAt { get; set; }

    [Column("canceled_at")]
    public DateTime? CanceledAt { get; set; }

    [Column("data", TypeName = "jsonb")]
    public string? Data { get; set; }

    [Column("provider_id")]
    public string? ProviderId { get; set; }

    [Column("shipping_option_id")]
    public string? ShippingOptionId { get; set; }

    [Column("metadata", TypeName = "jsonb")]
    public string? Metadata { get; set; }

    [Column("delivery_address_id")]
    public string? DeliveryAddressId { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }

    [Column("deleted_at")]
    public DateTime? DeletedAt { get; set; }

    [Column("marked_shipped_by")]
    public string? MarkedShippedBy { get; set; }

    [Column("created_by")]
    public string? CreatedBy { get; set; }

    [Column("requires_shipping")]
    public bool RequiresShipping { get; set; }

    [InverseProperty("Fulfillment")]
    public virtual ICollection<FulfillmentItem> FulfillmentItems { get; set; } = new List<FulfillmentItem>();

    [InverseProperty("Fulfillment")]
    public virtual ICollection<FulfillmentLabel> FulfillmentLabels { get; set; } = new List<FulfillmentLabel>();

    [ForeignKey("ShippingOptionId")]
    [InverseProperty("Fulfillments")]
    public virtual ShippingOption? ShippingOption { get; set; }
}
