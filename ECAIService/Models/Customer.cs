using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECAIService.Models;

[Table("customer")]
public partial class Customer
{
    [Key]
    [Column("id")]
    public string Id { get; set; } = null!;

    [Column("company_name")]
    public string? CompanyName { get; set; }

    [Column("first_name")]
    public string? FirstName { get; set; }

    [Column("last_name")]
    public string? LastName { get; set; }

    [Column("email")]
    public string? Email { get; set; }

    [Column("phone")]
    public string? Phone { get; set; }

    [Column("has_account")]
    public bool HasAccount { get; set; }

    [Column("metadata", TypeName = "jsonb")]
    public string? Metadata { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }

    [Column("deleted_at")]
    public DateTime? DeletedAt { get; set; }

    [Column("created_by")]
    public string? CreatedBy { get; set; }

    [InverseProperty("Customer")]
    public virtual CustomerAddress? CustomerAddress { get; set; }

    [InverseProperty("Customer")]
    public virtual ICollection<CustomerGroupCustomer> CustomerGroupCustomers { get; set; } = new List<CustomerGroupCustomer>();
}
