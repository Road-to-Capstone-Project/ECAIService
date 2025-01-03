using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECAIService.Models;

[Table("auth_identity")]
public partial class AuthIdentity
{
    [Key]
    [Column("id")]
    public string Id { get; set; } = null!;

    [Column("app_metadata", TypeName = "jsonb")]
    public string? AppMetadata { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }

    [Column("deleted_at")]
    public DateTime? DeletedAt { get; set; }

    [InverseProperty("AuthIdentity")]
    public virtual ICollection<ProviderIdentity> ProviderIdentities { get; set; } = new List<ProviderIdentity>();
}
