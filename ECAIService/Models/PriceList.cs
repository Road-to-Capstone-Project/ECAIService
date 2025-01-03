using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECAIService.Models;

[Table("price_list")]
public partial class PriceList
{
    [Key]
    [Column("id")]
    public string Id { get; set; } = null!;

    [Column("status")]
    public string Status { get; set; } = null!;

    [Column("starts_at")]
    public DateTime? StartsAt { get; set; }

    [Column("ends_at")]
    public DateTime? EndsAt { get; set; }

    [Column("rules_count")]
    public int? RulesCount { get; set; }

    [Column("title")]
    public string Title { get; set; } = null!;

    [Column("description")]
    public string Description { get; set; } = null!;

    [Column("type")]
    public string Type { get; set; } = null!;

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }

    [Column("deleted_at")]
    public DateTime? DeletedAt { get; set; }

    [InverseProperty("PriceList")]
    public virtual ICollection<PriceListRule> PriceListRules { get; set; } = new List<PriceListRule>();

    [InverseProperty("PriceList")]
    public virtual ICollection<Price> Prices { get; set; } = new List<Price>();
}
