using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECAIService.Models;

[Table("price")]
public partial class Price
{
    [Key]
    [Column("id")]
    public string Id { get; set; } = null!;

    [Column("title")]
    public string? Title { get; set; }

    [Column("price_set_id")]
    public string PriceSetId { get; set; } = null!;

    [Column("currency_code")]
    public string CurrencyCode { get; set; } = null!;

    [Column("raw_amount", TypeName = "jsonb")]
    public string RawAmount { get; set; } = "";

    [Column("rules_count")]
    public int? RulesCount { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }

    [Column("deleted_at")]
    public DateTime? DeletedAt { get; set; }

    [Column("price_list_id")]
    public string? PriceListId { get; set; }

    [Column("amount")]
    public decimal Amount { get; set; }

    [Column("min_quantity")]
    public int? MinQuantity { get; set; }

    [Column("max_quantity")]
    public int? MaxQuantity { get; set; }

    [ForeignKey("PriceListId")]
    [InverseProperty("Prices")]
    public virtual PriceList? PriceList { get; set; }

    [InverseProperty("Price")]
    public virtual ICollection<PriceRule> PriceRules { get; set; } = new List<PriceRule>();

    [ForeignKey("PriceSetId")]
    [InverseProperty("Prices")]
    public virtual PriceSet PriceSet { get; set; } = null!;
}
