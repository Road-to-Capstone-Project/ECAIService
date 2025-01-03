using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECAIService.Models;

[Table("region_country")]
[Index("RegionId", "Iso2", Name = "IDX_region_country_region_id_iso_2_unique", IsUnique = true)]
public partial class RegionCountry
{
    [Key]
    [Column("iso_2")]
    public string Iso2 { get; set; } = null!;

    [Column("iso_3")]
    public string Iso3 { get; set; } = null!;

    [Column("num_code")]
    public string NumCode { get; set; } = null!;

    [Column("name")]
    public string Name { get; set; } = null!;

    [Column("display_name")]
    public string DisplayName { get; set; } = null!;

    [Column("region_id")]
    public string? RegionId { get; set; }

    [Column("metadata", TypeName = "jsonb")]
    public string? Metadata { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }

    [Column("deleted_at")]
    public DateTime? DeletedAt { get; set; }

    [ForeignKey("RegionId")]
    [InverseProperty("RegionCountries")]
    public virtual Region? Region { get; set; }
}
