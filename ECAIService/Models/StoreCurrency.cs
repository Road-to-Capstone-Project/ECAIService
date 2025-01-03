using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECAIService.Models;

[Table("store_currency")]
public partial class StoreCurrency
{
    [Key]
    [Column("id")]
    public string Id { get; set; } = null!;

    [Column("currency_code")]
    public string CurrencyCode { get; set; } = null!;

    [Column("is_default")]
    public bool IsDefault { get; set; }

    [Column("store_id")]
    public string? StoreId { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }

    [Column("deleted_at")]
    public DateTime? DeletedAt { get; set; }

    [ForeignKey("StoreId")]
    [InverseProperty("StoreCurrencies")]
    public virtual Store? Store { get; set; }
}
