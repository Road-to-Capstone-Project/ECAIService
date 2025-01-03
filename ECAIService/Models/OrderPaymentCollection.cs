using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECAIService.Models;

[PrimaryKey("OrderId", "PaymentCollectionId")]
[Table("order_payment_collection")]
[Index("DeletedAt", Name = "IDX_deleted_at_f42b9949")]
[Index("Id", Name = "IDX_id_f42b9949")]
[Index("OrderId", Name = "IDX_order_id_f42b9949")]
[Index("PaymentCollectionId", Name = "IDX_payment_collection_id_f42b9949")]
public partial class OrderPaymentCollection
{
    [Key]
    [Column("order_id")]
    [StringLength(255)]
    public string OrderId { get; set; } = null!;

    [Key]
    [Column("payment_collection_id")]
    [StringLength(255)]
    public string PaymentCollectionId { get; set; } = null!;

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
