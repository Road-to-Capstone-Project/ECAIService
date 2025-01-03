﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECAIService.Models;

[Table("tax_rate_rule")]
public partial class TaxRateRule
{
    [Key]
    [Column("id")]
    public string Id { get; set; } = null!;

    [Column("tax_rate_id")]
    public string TaxRateId { get; set; } = null!;

    [Column("reference_id")]
    public string ReferenceId { get; set; } = null!;

    [Column("reference")]
    public string Reference { get; set; } = null!;

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

    [ForeignKey("TaxRateId")]
    [InverseProperty("TaxRateRules")]
    public virtual TaxRate TaxRate { get; set; } = null!;
}
