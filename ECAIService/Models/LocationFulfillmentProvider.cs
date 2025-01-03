using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECAIService.Models;

[PrimaryKey("StockLocationId", "FulfillmentProviderId")]
[Table("location_fulfillment_provider")]
[Index("DeletedAt", Name = "IDX_deleted_at_-1e5992737")]
[Index("FulfillmentProviderId", Name = "IDX_fulfillment_provider_id_-1e5992737")]
[Index("Id", Name = "IDX_id_-1e5992737")]
[Index("StockLocationId", Name = "IDX_stock_location_id_-1e5992737")]
public partial class LocationFulfillmentProvider
{
    [Key]
    [Column("stock_location_id")]
    [StringLength(255)]
    public string StockLocationId { get; set; } = null!;

    [Key]
    [Column("fulfillment_provider_id")]
    [StringLength(255)]
    public string FulfillmentProviderId { get; set; } = null!;

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
