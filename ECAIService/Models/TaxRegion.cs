using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECAIService.Models;

[Table("tax_region")]
[Index("ParentId", Name = "IDX_tax_region_parent_id")]
public partial class TaxRegion
{
    [Key]
    [Column("id")]
    public string Id { get; set; } = null!;

    [Column("provider_id")]
    public string? ProviderId { get; set; }

    [Column("country_code")]
    public string CountryCode { get; set; } = null!;

    [Column("province_code")]
    public string? ProvinceCode { get; set; }

    [Column("parent_id")]
    public string? ParentId { get; set; }

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

    [InverseProperty("Parent")]
    public virtual ICollection<TaxRegion> InverseParent { get; set; } = new List<TaxRegion>();

    [ForeignKey("ParentId")]
    [InverseProperty("InverseParent")]
    public virtual TaxRegion? Parent { get; set; }

    [ForeignKey("ProviderId")]
    [InverseProperty("TaxRegions")]
    public virtual TaxProvider? Provider { get; set; }

    [InverseProperty("TaxRegion")]
    public virtual TaxRate? TaxRate { get; set; }
}
