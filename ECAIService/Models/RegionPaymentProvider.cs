using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECAIService.Models;

[PrimaryKey("RegionId", "PaymentProviderId")]
[Table("region_payment_provider")]
[Index("DeletedAt", Name = "IDX_deleted_at_1c934dab0")]
[Index("Id", Name = "IDX_id_1c934dab0")]
[Index("PaymentProviderId", Name = "IDX_payment_provider_id_1c934dab0")]
[Index("RegionId", Name = "IDX_region_id_1c934dab0")]
public partial class RegionPaymentProvider
{
    [Key]
    [Column("region_id")]
    [StringLength(255)]
    public string RegionId { get; set; } = null!;

    [Key]
    [Column("payment_provider_id")]
    [StringLength(255)]
    public string PaymentProviderId { get; set; } = null!;

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
