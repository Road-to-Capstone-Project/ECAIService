using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECAIService.Models;

[Table("product_category")]
public partial class ProductCategory
{
    [Key]
    [Column("id")]
    public string Id { get; set; } = null!;

    [Column("name")]
    public string Name { get; set; } = null!;

    [Column("description")]
    public string Description { get; set; } = null!;

    [Column("handle")]
    public string Handle { get; set; } = null!;

    [Column("mpath")]
    public string Mpath { get; set; } = null!;

    [Column("is_active")]
    public bool IsActive { get; set; }

    [Column("is_internal")]
    public bool IsInternal { get; set; }

    [Column("rank")]
    public int Rank { get; set; }

    [Column("parent_category_id")]
    public string? ParentCategoryId { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }

    [Column("deleted_at")]
    public DateTime? DeletedAt { get; set; }

    [Column("metadata", TypeName = "jsonb")]
    public string? Metadata { get; set; }

    [InverseProperty("ParentCategory")]
    public virtual ICollection<ProductCategory> InverseParentCategory { get; set; } = new List<ProductCategory>();

    [ForeignKey("ParentCategoryId")]
    [InverseProperty("InverseParentCategory")]
    public virtual ProductCategory? ParentCategory { get; set; }

    [ForeignKey("ProductCategoryId")]
    [InverseProperty("ProductCategories")]
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
