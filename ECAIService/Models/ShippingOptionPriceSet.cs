using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECAIService.Models;

[PrimaryKey("ShippingOptionId", "PriceSetId")]
[Table("shipping_option_price_set")]
[Index("DeletedAt", Name = "IDX_deleted_at_ba32fa9c")]
[Index("Id", Name = "IDX_id_ba32fa9c")]
[Index("PriceSetId", Name = "IDX_price_set_id_ba32fa9c")]
[Index("ShippingOptionId", Name = "IDX_shipping_option_id_ba32fa9c")]
public partial class ShippingOptionPriceSet
{
    [Key]
    [Column("shipping_option_id")]
    [StringLength(255)]
    public string ShippingOptionId { get; set; } = null!;

    [Key]
    [Column("price_set_id")]
    [StringLength(255)]
    public string PriceSetId { get; set; } = null!;

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
