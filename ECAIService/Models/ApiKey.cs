using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECAIService.Models;

[Table("api_key")]
[Index("Token", Name = "IDX_api_key_token_unique", IsUnique = true)]
[Index("Type", Name = "IDX_api_key_type")]
public partial class ApiKey
{
    [Key]
    [Column("id")]
    public string Id { get; set; } = null!;

    [Column("token")]
    public string Token { get; set; } = null!;

    [Column("salt")]
    public string Salt { get; set; } = null!;

    [Column("redacted")]
    public string Redacted { get; set; } = null!;

    [Column("title")]
    public string Title { get; set; } = null!;

    [Column("type")]
    public string Type { get; set; } = null!;

    [Column("last_used_at")]
    public DateTime? LastUsedAt { get; set; }

    [Column("created_by")]
    public string CreatedBy { get; set; } = null!;

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("revoked_by")]
    public string? RevokedBy { get; set; }

    [Column("revoked_at")]
    public DateTime? RevokedAt { get; set; }

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }

    [Column("deleted_at")]
    public DateTime? DeletedAt { get; set; }
}
