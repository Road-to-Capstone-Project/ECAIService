using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECAIService.Models;

[Table("geo_zone")]
public partial class GeoZone
{
    [Key]
    [Column("id")]
    public string Id { get; set; } = null!;

    [Column("type")]
    public string Type { get; set; } = null!;

    [Column("country_code")]
    public string CountryCode { get; set; } = null!;

    [Column("province_code")]
    public string? ProvinceCode { get; set; }

    [Column("city")]
    public string? City { get; set; }

    [Column("service_zone_id")]
    public string ServiceZoneId { get; set; } = null!;

    [Column("postal_expression", TypeName = "jsonb")]
    public string? PostalExpression { get; set; }

    [Column("metadata", TypeName = "jsonb")]
    public string? Metadata { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }

    [Column("deleted_at")]
    public DateTime? DeletedAt { get; set; }

    [ForeignKey("ServiceZoneId")]
    [InverseProperty("GeoZones")]
    public virtual ServiceZone ServiceZone { get; set; } = null!;
}
