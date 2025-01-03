using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECAIService.Models;

[Table("price_list_rule")]
public partial class PriceListRule
{
    [Key]
    [Column("id")]
    public string Id { get; set; } = null!;

    [Column("price_list_id")]
    public string PriceListId { get; set; } = null!;

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }

    [Column("deleted_at")]
    public DateTime? DeletedAt { get; set; }

    [Column("value", TypeName = "jsonb")]
    public string? Value { get; set; }

    [Column("attribute")]
    public string Attribute { get; set; } = null!;

    [ForeignKey("PriceListId")]
    [InverseProperty("PriceListRules")]
    public virtual PriceList PriceList { get; set; } = null!;
}
