using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECAIService.Models;

[PrimaryKey("OrderId", "CartId")]
[Table("order_cart")]
[Index("CartId", Name = "IDX_cart_id_-71069c16")]
[Index("DeletedAt", Name = "IDX_deleted_at_-71069c16")]
[Index("Id", Name = "IDX_id_-71069c16")]
[Index("OrderId", Name = "IDX_order_id_-71069c16")]
public partial class OrderCart
{
    [Key]
    [Column("order_id")]
    [StringLength(255)]
    public string OrderId { get; set; } = null!;

    [Key]
    [Column("cart_id")]
    [StringLength(255)]
    public string CartId { get; set; } = null!;

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
