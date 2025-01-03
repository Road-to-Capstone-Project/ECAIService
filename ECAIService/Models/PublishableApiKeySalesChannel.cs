using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECAIService.Models;

[PrimaryKey("PublishableKeyId", "SalesChannelId")]
[Table("publishable_api_key_sales_channel")]
[Index("DeletedAt", Name = "IDX_deleted_at_-1d67bae40")]
[Index("Id", Name = "IDX_id_-1d67bae40")]
[Index("PublishableKeyId", Name = "IDX_publishable_key_id_-1d67bae40")]
[Index("SalesChannelId", Name = "IDX_sales_channel_id_-1d67bae40")]
public partial class PublishableApiKeySalesChannel
{
    [Key]
    [Column("publishable_key_id")]
    [StringLength(255)]
    public string PublishableKeyId { get; set; } = null!;

    [Key]
    [Column("sales_channel_id")]
    [StringLength(255)]
    public string SalesChannelId { get; set; } = null!;

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
