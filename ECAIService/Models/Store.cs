using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECAIService.Models;

[Table("store")]
public partial class Store
{
    [Key]
    [Column("id")]
    public string Id { get; set; } = null!;

    [Column("name")]
    public string Name { get; set; } = null!;

    [Column("default_sales_channel_id")]
    public string? DefaultSalesChannelId { get; set; }

    [Column("default_region_id")]
    public string? DefaultRegionId { get; set; }

    [Column("default_location_id")]
    public string? DefaultLocationId { get; set; }

    [Column("metadata", TypeName = "jsonb")]
    public string? Metadata { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }

    [Column("deleted_at")]
    public DateTime? DeletedAt { get; set; }

    [InverseProperty("Store")]
    public virtual ICollection<StoreCurrency> StoreCurrencies { get; set; } = new List<StoreCurrency>();
}
