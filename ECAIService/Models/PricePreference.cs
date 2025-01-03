using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECAIService.Models;

[Table("price_preference")]
public partial class PricePreference
{
    [Key]
    [Column("id")]
    public string Id { get; set; } = null!;

    [Column("attribute")]
    public string Attribute { get; set; } = null!;

    [Column("value")]
    public string? Value { get; set; }

    [Column("is_tax_inclusive")]
    public bool IsTaxInclusive { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }

    [Column("deleted_at")]
    public DateTime? DeletedAt { get; set; }
}
