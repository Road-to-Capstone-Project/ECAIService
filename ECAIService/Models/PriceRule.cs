using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECAIService.Models;

[Table("price_rule")]
[Index("Operator", Name = "IDX_price_rule_operator")]
public partial class PriceRule
{
    [Key]
    [Column("id")]
    public string Id { get; set; } = null!;

    [Column("value")]
    public string Value { get; set; } = null!;

    [Column("priority")]
    public int Priority { get; set; }

    [Column("price_id")]
    public string PriceId { get; set; } = null!;

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }

    [Column("deleted_at")]
    public DateTime? DeletedAt { get; set; }

    [Column("attribute")]
    public string Attribute { get; set; } = null!;

    [Column("operator")]
    public string Operator { get; set; } = null!;

    [ForeignKey("PriceId")]
    [InverseProperty("PriceRules")]
    public virtual Price Price { get; set; } = null!;
}
