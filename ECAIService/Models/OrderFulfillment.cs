using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECAIService.Models;

[PrimaryKey("OrderId", "FulfillmentId")]
[Table("order_fulfillment")]
[Index("DeletedAt", Name = "IDX_deleted_at_-e8d2543e")]
[Index("FulfillmentId", Name = "IDX_fulfillment_id_-e8d2543e")]
[Index("Id", Name = "IDX_id_-e8d2543e")]
[Index("OrderId", Name = "IDX_order_id_-e8d2543e")]
public partial class OrderFulfillment
{
    [Key]
    [Column("order_id")]
    [StringLength(255)]
    public string OrderId { get; set; } = null!;

    [Key]
    [Column("fulfillment_id")]
    [StringLength(255)]
    public string FulfillmentId { get; set; } = null!;

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
