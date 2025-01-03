using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECAIService.Models;

[Table("service_zone")]
public partial class ServiceZone
{
    [Key]
    [Column("id")]
    public string Id { get; set; } = null!;

    [Column("name")]
    public string Name { get; set; } = null!;

    [Column("metadata", TypeName = "jsonb")]
    public string? Metadata { get; set; }

    [Column("fulfillment_set_id")]
    public string FulfillmentSetId { get; set; } = null!;

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }

    [Column("deleted_at")]
    public DateTime? DeletedAt { get; set; }

    [ForeignKey("FulfillmentSetId")]
    [InverseProperty("ServiceZones")]
    public virtual FulfillmentSet FulfillmentSet { get; set; } = null!;

    [InverseProperty("ServiceZone")]
    public virtual ICollection<GeoZone> GeoZones { get; set; } = new List<GeoZone>();

    [InverseProperty("ServiceZone")]
    public virtual ICollection<ShippingOption> ShippingOptions { get; set; } = new List<ShippingOption>();
}
