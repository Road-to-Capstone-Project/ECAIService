using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECAIService.Models;

[Table("capture")]
[Index("DeletedAt", Name = "IDX_capture_deleted_at")]
public partial class Capture
{
    [Key]
    [Column("id")]
    public string Id { get; set; } = null!;

    [Column("amount")]
    public decimal Amount { get; set; }

    [Column("raw_amount", TypeName = "jsonb")]
    public string RawAmount { get; set; } = null!;

    [Column("payment_id")]
    public string PaymentId { get; set; } = null!;

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }

    [Column("deleted_at")]
    public DateTime? DeletedAt { get; set; }

    [Column("created_by")]
    public string? CreatedBy { get; set; }

    [Column("metadata", TypeName = "jsonb")]
    public string? Metadata { get; set; }

    [ForeignKey("PaymentId")]
    [InverseProperty("Captures")]
    public virtual Payment Payment { get; set; } = null!;
}
