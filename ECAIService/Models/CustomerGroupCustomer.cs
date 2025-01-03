using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECAIService.Models;

[Table("customer_group_customer")]
[Index("CustomerId", Name = "IDX_customer_group_customer_customer_id")]
public partial class CustomerGroupCustomer
{
    [Key]
    [Column("id")]
    public string Id { get; set; } = null!;

    [Column("customer_id")]
    public string CustomerId { get; set; } = null!;

    [Column("customer_group_id")]
    public string CustomerGroupId { get; set; } = null!;

    [Column("metadata", TypeName = "jsonb")]
    public string? Metadata { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }

    [Column("created_by")]
    public string? CreatedBy { get; set; }

    [Column("deleted_at")]
    public DateTime? DeletedAt { get; set; }

    [ForeignKey("CustomerId")]
    [InverseProperty("CustomerGroupCustomers")]
    public virtual Customer Customer { get; set; } = null!;

    [ForeignKey("CustomerGroupId")]
    [InverseProperty("CustomerGroupCustomers")]
    public virtual CustomerGroup CustomerGroup { get; set; } = null!;
}
