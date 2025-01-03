using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECAIService.Models;

[Table("product_option_value")]
[Index("DeletedAt", Name = "IDX_product_option_value_deleted_at")]
public partial class ProductOptionValue
{
    [Key]
    [Column("id")]
    public string Id { get; set; } = null!;

    [Column("value")]
    public string Value { get; set; } = null!;

    [Column("option_id")]
    public string? OptionId { get; set; }

    [Column("metadata", TypeName = "jsonb")]
    public string? Metadata { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }

    [Column("deleted_at")]
    public DateTime? DeletedAt { get; set; }

    [ForeignKey("OptionId")]
    [InverseProperty("ProductOptionValues")]
    public virtual ProductOption? Option { get; set; }

    [ForeignKey("OptionValueId")]
    [InverseProperty("OptionValues")]
    public virtual ICollection<ProductVariant> Variants { get; set; } = new List<ProductVariant>();
}
