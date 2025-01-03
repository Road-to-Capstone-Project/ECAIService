using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECAIService.Models;

[Table("product_type")]
[Index("DeletedAt", Name = "IDX_product_type_deleted_at")]
public partial class ProductType
{
    [Key]
    [Column("id")]
    public string Id { get; set; } = null!;

    [Column("value")]
    public string Value { get; set; } = null!;

    [Column("metadata", TypeName = "json")]
    public string? Metadata { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }

    [Column("deleted_at")]
    public DateTime? DeletedAt { get; set; }

    [InverseProperty("Type")]
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
