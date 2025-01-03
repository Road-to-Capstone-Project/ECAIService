using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECAIService.Models;

[PrimaryKey("SalesChannelId", "StockLocationId")]
[Table("sales_channel_stock_location")]
[Index("DeletedAt", Name = "IDX_deleted_at_26d06f470")]
[Index("Id", Name = "IDX_id_26d06f470")]
[Index("SalesChannelId", Name = "IDX_sales_channel_id_26d06f470")]
[Index("StockLocationId", Name = "IDX_stock_location_id_26d06f470")]
public partial class SalesChannelStockLocation
{
    [Key]
    [Column("sales_channel_id")]
    [StringLength(255)]
    public string SalesChannelId { get; set; } = null!;

    [Key]
    [Column("stock_location_id")]
    [StringLength(255)]
    public string StockLocationId { get; set; } = null!;

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
