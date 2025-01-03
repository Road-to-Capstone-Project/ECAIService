using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECAIService.Models;

[PrimaryKey("ReturnId", "FulfillmentId")]
[Table("return_fulfillment")]
[Index("DeletedAt", Name = "IDX_deleted_at_-31ea43a")]
[Index("FulfillmentId", Name = "IDX_fulfillment_id_-31ea43a")]
[Index("Id", Name = "IDX_id_-31ea43a")]
[Index("ReturnId", Name = "IDX_return_id_-31ea43a")]
public partial class ReturnFulfillment
{
    [Key]
    [Column("return_id")]
    [StringLength(255)]
    public string ReturnId { get; set; } = null!;

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
