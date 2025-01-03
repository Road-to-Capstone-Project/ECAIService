using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECAIService.Models;

[PrimaryKey("VariantId", "InventoryItemId")]
[Table("product_variant_inventory_item")]
[Index("DeletedAt", Name = "IDX_deleted_at_17b4c4e35")]
[Index("Id", Name = "IDX_id_17b4c4e35")]
[Index("InventoryItemId", Name = "IDX_inventory_item_id_17b4c4e35")]
[Index("VariantId", Name = "IDX_variant_id_17b4c4e35")]
public partial class ProductVariantInventoryItem
{
    [Key]
    [Column("variant_id")]
    [StringLength(255)]
    public string VariantId { get; set; } = null!;

    [Key]
    [Column("inventory_item_id")]
    [StringLength(255)]
    public string InventoryItemId { get; set; } = null!;

    [Column("id")]
    [StringLength(255)]
    public string Id { get; set; } = null!;

    [Column("required_quantity")]
    public int RequiredQuantity { get; set; }

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
