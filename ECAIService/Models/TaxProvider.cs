using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECAIService.Models;

[Table("tax_provider")]
public partial class TaxProvider
{
    [Key]
    [Column("id")]
    public string Id { get; set; } = null!;

    [Column("is_enabled")]
    public bool IsEnabled { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }

    [Column("deleted_at")]
    public DateTime? DeletedAt { get; set; }

    [InverseProperty("Provider")]
    public virtual ICollection<TaxRegion> TaxRegions { get; set; } = new List<TaxRegion>();
}
