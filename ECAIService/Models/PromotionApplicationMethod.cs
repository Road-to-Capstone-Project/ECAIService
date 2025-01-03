using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECAIService.Models;

[Table("promotion_application_method")]
[Index("Allocation", Name = "IDX_application_method_allocation")]
[Index("TargetType", Name = "IDX_application_method_target_type")]
[Index("Type", Name = "IDX_application_method_type")]
[Index("PromotionId", Name = "promotion_application_method_promotion_id_unique", IsUnique = true)]
public partial class PromotionApplicationMethod
{
    [Key]
    [Column("id")]
    public string Id { get; set; } = null!;

    [Column("value")]
    public decimal? Value { get; set; }

    [Column("raw_value", TypeName = "jsonb")]
    public string? RawValue { get; set; }

    [Column("max_quantity")]
    public int? MaxQuantity { get; set; }

    [Column("apply_to_quantity")]
    public int? ApplyToQuantity { get; set; }

    [Column("buy_rules_min_quantity")]
    public int? BuyRulesMinQuantity { get; set; }

    [Column("type")]
    public string Type { get; set; } = null!;

    [Column("target_type")]
    public string TargetType { get; set; } = null!;

    [Column("allocation")]
    public string? Allocation { get; set; }

    [Column("promotion_id")]
    public string PromotionId { get; set; } = null!;

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }

    [Column("deleted_at")]
    public DateTime? DeletedAt { get; set; }

    [Column("currency_code")]
    public string? CurrencyCode { get; set; }

    [ForeignKey("PromotionId")]
    [InverseProperty("PromotionApplicationMethod")]
    public virtual Promotion Promotion { get; set; } = null!;

    [ForeignKey("ApplicationMethodId")]
    [InverseProperty("ApplicationMethods")]
    public virtual ICollection<PromotionRule> PromotionRules { get; set; } = new List<PromotionRule>();

    [ForeignKey("ApplicationMethodId")]
    [InverseProperty("ApplicationMethodsNavigation")]
    public virtual ICollection<PromotionRule> PromotionRulesNavigation { get; set; } = new List<PromotionRule>();
}
