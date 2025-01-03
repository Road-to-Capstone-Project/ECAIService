using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECAIService.Models;

[Table("promotion")]
[Index("Code", Name = "IDX_promotion_code")]
[Index("Code", Name = "IDX_promotion_code_unique", IsUnique = true)]
[Index("Type", Name = "IDX_promotion_type")]
public partial class Promotion
{
    [Key]
    [Column("id")]
    public string Id { get; set; } = null!;

    [Column("code")]
    public string Code { get; set; } = null!;

    [Column("campaign_id")]
    public string? CampaignId { get; set; }

    [Column("is_automatic")]
    public bool IsAutomatic { get; set; }

    [Column("type")]
    public string Type { get; set; } = null!;

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }

    [Column("deleted_at")]
    public DateTime? DeletedAt { get; set; }

    [ForeignKey("CampaignId")]
    [InverseProperty("Promotions")]
    public virtual PromotionCampaign? Campaign { get; set; }

    [InverseProperty("Promotion")]
    public virtual PromotionApplicationMethod? PromotionApplicationMethod { get; set; }

    [ForeignKey("PromotionId")]
    [InverseProperty("Promotions")]
    public virtual ICollection<PromotionRule> PromotionRules { get; set; } = new List<PromotionRule>();
}
