using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECAIService.Models;

[PrimaryKey("CartId", "PromotionId")]
[Table("cart_promotion")]
[Index("CartId", Name = "IDX_cart_id_-a9d4a70b")]
[Index("DeletedAt", Name = "IDX_deleted_at_-a9d4a70b")]
[Index("Id", Name = "IDX_id_-a9d4a70b")]
[Index("PromotionId", Name = "IDX_promotion_id_-a9d4a70b")]
public partial class CartPromotion
{
    [Key]
    [Column("cart_id")]
    [StringLength(255)]
    public string CartId { get; set; } = null!;

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
