using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECAIService.Models;

[Table("product")]
[Index("DeletedAt", Name = "IDX_product_deleted_at")]
public partial class Product
{
    [Key]
    [Column("id")]
    public string Id { get; set; } = null!;

    [Column("title")]
    public string Title { get; set; } = null!;

    [Column("handle")]
    public string Handle { get; set; } = null!;

    [Column("subtitle")]
    public string? Subtitle { get; set; }

    [Column("description")]
    public string? Description { get; set; }

    [Column("is_giftcard")]
    public bool IsGiftcard { get; set; }

    [Column("status")]
    public string Status { get; set; } = null!;

    [Column("thumbnail")]
    public string? Thumbnail { get; set; }

    [Column("weight")]
    public string? Weight { get; set; }

    [Column("length")]
    public string? Length { get; set; }

    [Column("height")]
    public string? Height { get; set; }

    [Column("width")]
    public string? Width { get; set; }

    [Column("origin_country")]
    public string? OriginCountry { get; set; }

    [Column("hs_code")]
    public string? HsCode { get; set; }

    [Column("mid_code")]
    public string? MidCode { get; set; }

    [Column("material")]
    public string? Material { get; set; }

    [Column("collection_id")]
    public string? CollectionId { get; set; }

    [Column("type_id")]
    public string? TypeId { get; set; }

    [Column("discountable")]
    public bool Discountable { get; set; }

    [Column("external_id")]
    public string? ExternalId { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }

    [Column("deleted_at")]
    public DateTime? DeletedAt { get; set; }

    [Column("metadata", TypeName = "jsonb")]
    public string? Metadata { get; set; }

    [ForeignKey("CollectionId")]
    [InverseProperty("Products")]
    public virtual ProductCollection? Collection { get; set; }

    [InverseProperty("Product")]
    public virtual ICollection<Image> Images { get; set; } = new List<Image>();

    [InverseProperty("Product")]
    public virtual ICollection<ProductOption> ProductOptions { get; set; } = new List<ProductOption>();

    [InverseProperty("Product")]
    public virtual ICollection<ProductVariant> ProductVariants { get; set; } = new List<ProductVariant>();

    [ForeignKey("TypeId")]
    [InverseProperty("Products")]
    public virtual ProductType? Type { get; set; }

    [ForeignKey("ProductId")]
    [InverseProperty("Products")]
    public virtual ICollection<ProductCategory> ProductCategories { get; set; } = new List<ProductCategory>();

    [ForeignKey("ProductId")]
    [InverseProperty("Products")]
    public virtual ICollection<ProductTag1> ProductTags { get; set; } = new List<ProductTag1>();
}
