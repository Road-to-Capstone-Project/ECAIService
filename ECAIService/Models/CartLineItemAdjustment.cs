using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECAIService.Models;

[Table("cart_line_item_adjustment")]
public partial class CartLineItemAdjustment
{
    [Key]
    [Column("id")]
    public string Id { get; set; } = null!;

    [Column("description")]
    public string? Description { get; set; }

    [Column("promotion_id")]
    public string? PromotionId { get; set; }

    [Column("code")]
    public string? Code { get; set; }

    [Column("amount")]
    public decimal Amount { get; set; }

    [Column("raw_amount", TypeName = "jsonb")]
    public string RawAmount { get; set; } = null!;

    [Column("provider_id")]
    public string? ProviderId { get; set; }

    [Column("metadata", TypeName = "jsonb")]
    public string? Metadata { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }

    [Column("deleted_at")]
    public DateTime? DeletedAt { get; set; }

    [Column("item_id")]
    public string? ItemId { get; set; }

    [ForeignKey("ItemId")]
    [InverseProperty("CartLineItemAdjustments")]
    public virtual CartLineItem? Item { get; set; }
}
