using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECAIService.Models;

[Table("shipping_option")]
public partial class ShippingOption
{
    [Key]
    [Column("id")]
    public string Id { get; set; } = null!;

    [Column("name")]
    public string Name { get; set; } = null!;

    [Column("price_type")]
    public string PriceType { get; set; } = null!;

    [Column("service_zone_id")]
    public string ServiceZoneId { get; set; } = null!;

    [Column("shipping_profile_id")]
    public string? ShippingProfileId { get; set; }

    [Column("provider_id")]
    public string? ProviderId { get; set; }

    [Column("data", TypeName = "jsonb")]
    public string? Data { get; set; }

    [Column("metadata", TypeName = "jsonb")]
    public string? Metadata { get; set; }

    [Column("shipping_option_type_id")]
    public string ShippingOptionTypeId { get; set; } = null!;

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }

    [Column("deleted_at")]
    public DateTime? DeletedAt { get; set; }

    [InverseProperty("ShippingOption")]
    public virtual ICollection<Fulfillment> Fulfillments { get; set; } = new List<Fulfillment>();

    [ForeignKey("ServiceZoneId")]
    [InverseProperty("ShippingOptions")]
    public virtual ServiceZone ServiceZone { get; set; } = null!;

    [InverseProperty("ShippingOption")]
    public virtual ICollection<ShippingOptionRule> ShippingOptionRules { get; set; } = new List<ShippingOptionRule>();

    [ForeignKey("ShippingProfileId")]
    [InverseProperty("ShippingOptions")]
    public virtual ShippingProfile? ShippingProfile { get; set; }
}
