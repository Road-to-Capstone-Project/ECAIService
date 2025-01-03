using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECAIService.Models;

[Table("stock_location_address")]
public partial class StockLocationAddress
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

    [Column("address_1")]
    public string Address1 { get; set; } = null!;

    [Column("address_2")]
    public string? Address2 { get; set; }

    [Column("company")]
    public string? Company { get; set; }

    [Column("city")]
    public string? City { get; set; }

    [Column("country_code")]
    public string CountryCode { get; set; } = null!;

    [Column("phone")]
    public string? Phone { get; set; }

    [Column("province")]
    public string? Province { get; set; }

    [Column("postal_code")]
    public string? PostalCode { get; set; }

    [Column("metadata", TypeName = "jsonb")]
    public string? Metadata { get; set; }

    [InverseProperty("Address")]
    public virtual ICollection<StockLocation> StockLocations { get; set; } = new List<StockLocation>();
}
