using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECAIService.Models;

[Table("stock_location")]
public partial class StockLocation
{
    [Key]
    [Column("id")]
    public string Id { get; set; } = null!;

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }

    [Column("deleted_at")]
    public DateTime? DeletedAt { get; set; }

    [Column("name")]
    public string Name { get; set; } = null!;

    [Column("address_id")]
    public string? AddressId { get; set; }

    [Column("metadata", TypeName = "jsonb")]
    public string? Metadata { get; set; }

    [ForeignKey("AddressId")]
    [InverseProperty("StockLocations")]
    public virtual StockLocationAddress? Address { get; set; }
}
