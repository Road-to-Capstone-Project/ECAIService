using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECAIService.Models;

[PrimaryKey("OrderId", "PromotionId")]
[Table("order_promotion")]
[Index("DeletedAt", Name = "IDX_deleted_at_-71518339")]
[Index("Id", Name = "IDX_id_-71518339")]
[Index("OrderId", Name = "IDX_order_id_-71518339")]
[Index("PromotionId", Name = "IDX_promotion_id_-71518339")]
public partial class OrderPromotion
{
    [Key]
    [Column("order_id")]
    [StringLength(255)]
    public string OrderId { get; set; } = null!;

    [Key]
    [Column("promotion_id")]
    [StringLength(255)]
    public string PromotionId { get; set; } = null!;

    [Column("id")]
    [StringLength(255)]
    public string Id { get; set; } = null!;

    [Column("created_at")]
    [Precision(0, 0)]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    [Precision(0, 0)]
    public DateTime UpdatedAt { get; set; }

    [Column("deleted_at")]
    [Precision(0, 0)]
    public DateTime? DeletedAt { get; set; }
}
