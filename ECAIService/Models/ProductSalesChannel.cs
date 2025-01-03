using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECAIService.Models;

[PrimaryKey("ProductId", "SalesChannelId")]
[Table("product_sales_channel")]
[Index("DeletedAt", Name = "IDX_deleted_at_20b454295")]
[Index("Id", Name = "IDX_id_20b454295")]
[Index("ProductId", Name = "IDX_product_id_20b454295")]
[Index("SalesChannelId", Name = "IDX_sales_channel_id_20b454295")]
public partial class ProductSalesChannel
{
    [Key]
    [Column("product_id")]
    [StringLength(255)]
    public string ProductId { get; set; } = null!;

    [Key]
    [Column("sales_channel_id")]
    [StringLength(255)]
    public string SalesChannelId { get; set; } = null!;

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
