using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECAIService.Models;

[Table("customer_address")]
[Index("CustomerId", Name = "IDX_customer_address_customer_id")]
public partial class CustomerAddress
{
    [Key]
    [Column("id")]
    public string Id { get; set; } = null!;

    [Column("customer_id")]
    public string CustomerId { get; set; } = null!;

    [Column("address_name")]
    public string? AddressName { get; set; }

    [Column("is_default_shipping")]
    public bool IsDefaultShipping { get; set; }

    [Column("is_default_billing")]
    public bool IsDefaultBilling { get; set; }

    [Column("company")]
    public string? Company { get; set; }

    [Column("first_name")]
    public string? FirstName { get; set; }

    [Column("last_name")]
    public string? LastName { get; set; }

    [Column("address_1")]
    public string? Address1 { get; set; }

    [Column("address_2")]
    public string? Address2 { get; set; }

    [Column("city")]
    public string? City { get; set; }

    [Column("country_code")]
    public string? CountryCode { get; set; }

    [Column("province")]
    public string? Province { get; set; }

    [Column("postal_code")]
    public string? PostalCode { get; set; }

    [Column("phone")]
    public string? Phone { get; set; }

    [Column("metadata", TypeName = "jsonb")]
    public string? Metadata { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }

    [Column("deleted_at")]
    public DateTime? DeletedAt { get; set; }

    [ForeignKey("CustomerId")]
    [InverseProperty("CustomerAddress")]
    public virtual Customer Customer { get; set; } = null!;
}
