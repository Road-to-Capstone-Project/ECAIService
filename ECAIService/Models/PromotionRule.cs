using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECAIService.Models;

[Table("promotion_rule")]
[Index("Attribute", Name = "IDX_promotion_rule_attribute")]
[Index("Operator", Name = "IDX_promotion_rule_operator")]
public partial class PromotionRule
{
    [Key]
    [Column("id")]
    public string Id { get; set; } = null!;

    [Column("description")]
    public string? Description { get; set; }

    [Column("attribute")]
    public string Attribute { get; set; } = null!;

    [Column("operator")]
    public string Operator { get; set; } = null!;

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }

    [Column("deleted_at")]
    public DateTime? DeletedAt { get; set; }

    [InverseProperty("PromotionRule")]
    public virtual ICollection<PromotionRuleValue> PromotionRuleValues { get; set; } = new List<PromotionRuleValue>();

    [ForeignKey("PromotionRuleId")]
    [InverseProperty("PromotionRules")]
    public virtual ICollection<PromotionApplicationMethod> ApplicationMethods { get; set; } = new List<PromotionApplicationMethod>();

    [ForeignKey("PromotionRuleId")]
    [InverseProperty("PromotionRulesNavigation")]
    public virtual ICollection<PromotionApplicationMethod> ApplicationMethodsNavigation { get; set; } = new List<PromotionApplicationMethod>();

    [ForeignKey("PromotionRuleId")]
    [InverseProperty("PromotionRules")]
    public virtual ICollection<Promotion> Promotions { get; set; } = new List<Promotion>();
}
