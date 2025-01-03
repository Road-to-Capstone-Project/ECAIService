﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECAIService.Models;

[Table("cart_shipping_method_tax_line")]
public partial class CartShippingMethodTaxLine
{
    [Key]
    [Column("id")]
    public string Id { get; set; } = null!;

    [Column("description")]
    public string? Description { get; set; }

    [Column("tax_rate_id")]
    public string? TaxRateId { get; set; }

    [Column("code")]
    public string Code { get; set; } = null!;

    [Column("rate")]
    public float Rate { get; set; }

    [Column("provider_id")]
    public string? ProviderId { get; set; }

    [Column("metadata", TypeName = "jsonb")]
    public string? Metadata { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }

    [Column("deleted_at")]
    public DateTime? DeletedAt { get; set; }

    [Column("shipping_method_id")]
    public string? ShippingMethodId { get; set; }

    [ForeignKey("ShippingMethodId")]
    [InverseProperty("CartShippingMethodTaxLines")]
    public virtual CartShippingMethod? ShippingMethod { get; set; }
}
