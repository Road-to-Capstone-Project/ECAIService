using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECAIService.Models;

[PrimaryKey("StockLocationId", "FulfillmentSetId")]
[Table("location_fulfillment_set")]
[Index("DeletedAt", Name = "IDX_deleted_at_-e88adb96")]
[Index("FulfillmentSetId", Name = "IDX_fulfillment_set_id_-e88adb96")]
[Index("Id", Name = "IDX_id_-e88adb96")]
[Index("StockLocationId", Name = "IDX_stock_location_id_-e88adb96")]
public partial class LocationFulfillmentSet
{
    [Key]
    [Column("stock_location_id")]
    [StringLength(255)]
    public string StockLocationId { get; set; } = null!;

    [Key]
    [Column("fulfillment_set_id")]
    [StringLength(255)]
    public string FulfillmentSetId { get; set; } = null!;

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
