using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECAIService.Models;

[Table("promotion_rule_value")]
public partial class PromotionRuleValue
{
    [Key]
    [Column("id")]
    public string Id { get; set; } = null!;

    [Column("promotion_rule_id")]
    public string PromotionRuleId { get; set; } = null!;

    [Column("value")]
    public string Value { get; set; } = null!;

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }

    [Column("deleted_at")]
    public DateTime? DeletedAt { get; set; }

    [ForeignKey("PromotionRuleId")]
    [InverseProperty("PromotionRuleValues")]
    public virtual PromotionRule PromotionRule { get; set; } = null!;
}
