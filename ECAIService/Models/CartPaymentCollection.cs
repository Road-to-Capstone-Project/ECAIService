using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECAIService.Models;

[PrimaryKey("CartId", "PaymentCollectionId")]
[Table("cart_payment_collection")]
[Index("CartId", Name = "IDX_cart_id_-4a39f6c9")]
[Index("DeletedAt", Name = "IDX_deleted_at_-4a39f6c9")]
[Index("Id", Name = "IDX_id_-4a39f6c9")]
[Index("PaymentCollectionId", Name = "IDX_payment_collection_id_-4a39f6c9")]
public partial class CartPaymentCollection
{
    [Key]
    [Column("cart_id")]
    [StringLength(255)]
    public string CartId { get; set; } = null!;

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
