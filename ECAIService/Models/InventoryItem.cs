using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECAIService.Models;

[Table("inventory_item")]
public partial class InventoryItem
{
    [Key]
    [Column("id")]
    public string Id { get; set; } = null!;

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }

    [Column("deleted_at")]
    public DateTime? DeletedAt { get; set; }

    [Column("sku")]
    public string? Sku { get; set; }

    [Column("origin_country")]
    public string? OriginCountry { get; set; }

    [Column("hs_code")]
    public string? HsCode { get; set; }

    [Column("mid_code")]
    public string? MidCode { get; set; }

    [Column("material")]
    public string? Material { get; set; }

    [Column("weight")]
    public int? Weight { get; set; }

    [Column("length")]
    public int? Length { get; set; }

    [Column("height")]
    public int? Height { get; set; }

    [Column("width")]
    public int? Width { get; set; }

    [Column("requires_shipping")]
    public bool RequiresShipping { get; set; }

    [Column("description")]
    public string? Description { get; set; }

    [Column("title")]
    public string? Title { get; set; }

    [Column("thumbnail")]
    public string? Thumbnail { get; set; }

    [Column("metadata", TypeName = "jsonb")]
    public string? Metadata { get; set; }

    [InverseProperty("InventoryItem")]
    public virtual ICollection<InventoryLevel> InventoryLevels { get; set; } = new List<InventoryLevel>();

    [InverseProperty("InventoryItem")]
    public virtual ICollection<ReservationItem> ReservationItems { get; set; } = new List<ReservationItem>();
}
