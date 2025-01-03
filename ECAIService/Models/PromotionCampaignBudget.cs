using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECAIService.Models;

[Table("promotion_campaign_budget")]
[Index("Type", Name = "IDX_campaign_budget_type")]
[Index("CampaignId", Name = "promotion_campaign_budget_campaign_id_unique", IsUnique = true)]
public partial class PromotionCampaignBudget
{
    [Key]
    [Column("id")]
    public string Id { get; set; } = null!;

    [Column("type")]
    public string Type { get; set; } = null!;

    [Column("campaign_id")]
    public string CampaignId { get; set; } = null!;

    [Column("limit")]
    public decimal? Limit { get; set; }

    [Column("raw_limit", TypeName = "jsonb")]
    public string? RawLimit { get; set; }

    [Column("used")]
    public decimal Used { get; set; }

    [Column("raw_used", TypeName = "jsonb")]
    public string RawUsed { get; set; } = null!;

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }

    [Column("deleted_at")]
    public DateTime? DeletedAt { get; set; }

    [Column("currency_code")]
    public string? CurrencyCode { get; set; }

    [ForeignKey("CampaignId")]
    [InverseProperty("PromotionCampaignBudget")]
    public virtual PromotionCampaign Campaign { get; set; } = null!;
}
