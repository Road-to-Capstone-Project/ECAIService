using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECAIService.Models;

[Table("shipping_option_rule")]
public partial class ShippingOptionRule
{
    [Key]
    [Column("id")]
    public string Id { get; set; } = null!;

    [Column("attribute")]
    public string Attribute { get; set; } = null!;

    [Column("operator")]
    public string Operator { get; set; } = null!;

    [Column("value", TypeName = "jsonb")]
    public string? Value { get; set; }

    [Column("shipping_option_id")]
    public string ShippingOptionId { get; set; } = null!;

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }

    [Column("deleted_at")]
    public DateTime? DeletedAt { get; set; }

    [ForeignKey("ShippingOptionId")]
    [InverseProperty("ShippingOptionRules")]
    public virtual ShippingOption ShippingOption { get; set; } = null!;
}
