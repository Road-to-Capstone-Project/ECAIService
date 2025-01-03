using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECAIService.Models;

[Table("currency")]
public partial class Currency
{
    [Key]
    [Column("code")]
    public string Code { get; set; } = null!;

    [Column("symbol")]
    public string Symbol { get; set; } = null!;

    [Column("symbol_native")]
    public string SymbolNative { get; set; } = null!;

    [Column("decimal_digits")]
    public int DecimalDigits { get; set; }

    [Column("rounding")]
    public decimal Rounding { get; set; }

    [Column("raw_rounding", TypeName = "jsonb")]
    public string RawRounding { get; set; } = null!;

    [Column("name")]
    public string Name { get; set; } = null!;

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }

    [Column("deleted_at")]
    public DateTime? DeletedAt { get; set; }
}
