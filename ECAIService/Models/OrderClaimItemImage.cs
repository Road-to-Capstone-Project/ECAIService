using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECAIService.Models;

[Table("order_claim_item_image")]
public partial class OrderClaimItemImage
{
    [Key]
    [Column("id")]
    public string Id { get; set; } = null!;

    [Column("claim_item_id")]
    public string ClaimItemId { get; set; } = null!;

    [Column("url")]
    public string Url { get; set; } = null!;

    [Column("metadata", TypeName = "jsonb")]
    public string? Metadata { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }

    [Column("deleted_at")]
    public DateTime? DeletedAt { get; set; }
}
