using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECAIService.Models;

[Table("payment_method_token")]
public partial class PaymentMethodToken
{
    [Key]
    [Column("id")]
    public string Id { get; set; } = null!;

    [Column("provider_id")]
    public string ProviderId { get; set; } = null!;

    [Column("data", TypeName = "jsonb")]
    public string? Data { get; set; }

    [Column("name")]
    public string Name { get; set; } = null!;

    [Column("type_detail")]
    public string? TypeDetail { get; set; }

    [Column("description_detail")]
    public string? DescriptionDetail { get; set; }

    [Column("metadata", TypeName = "jsonb")]
    public string? Metadata { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }

    [Column("deleted_at")]
    public DateTime? DeletedAt { get; set; }
}
