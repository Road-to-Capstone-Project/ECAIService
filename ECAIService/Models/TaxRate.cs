using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECAIService.Models;

[Table("tax_rate")]
public partial class TaxRate
{
    [Key]
    [Column("id")]
    public string Id { get; set; } = null!;

    [Column("rate")]
    public float? Rate { get; set; }

    [Column("code")]
    public string Code { get; set; } = null!;

    [Column("name")]
    public string Name { get; set; } = null!;

    [Column("is_default")]
    public bool IsDefault { get; set; }

    [Column("is_combinable")]
    public bool IsCombinable { get; set; }

    [Column("tax_region_id")]
    public string TaxRegionId { get; set; } = null!;

    [Column("metadata", TypeName = "jsonb")]
    public string? Metadata { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }

    [Column("created_by")]
    public string? CreatedBy { get; set; }

    [Column("deleted_at")]
    public DateTime? DeletedAt { get; set; }

    [InverseProperty("TaxRate")]
    public virtual ICollection<TaxRateRule> TaxRateRules { get; set; } = new List<TaxRateRule>();

    [ForeignKey("TaxRegionId")]
    [InverseProperty("TaxRate")]
    public virtual TaxRegion TaxRegion { get; set; } = null!;
}
