using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECAIService.Models;

[Table("order_line_item_tax_line")]
public partial class OrderLineItemTaxLine
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
    public decimal Rate { get; set; }

    [Column("raw_rate", TypeName = "jsonb")]
    public string RawRate { get; set; } = null!;

    [Column("provider_id")]
    public string? ProviderId { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }

    [Column("item_id")]
    public string ItemId { get; set; } = null!;

    [Column("deleted_at")]
    public DateTime? DeletedAt { get; set; }

    [ForeignKey("ItemId")]
    [InverseProperty("OrderLineItemTaxLines")]
    public virtual OrderLineItem Item { get; set; } = null!;
}
