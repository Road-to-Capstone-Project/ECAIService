using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECAIService.Models;

[Table("provider_identity")]
[Index("AuthIdentityId", Name = "IDX_provider_identity_auth_identity_id")]
[Index("EntityId", "Provider", Name = "IDX_provider_identity_provider_entity_id", IsUnique = true)]
public partial class ProviderIdentity
{
    [Key]
    [Column("id")]
    public string Id { get; set; } = null!;

    [Column("entity_id")]
    public string EntityId { get; set; } = null!;

    [Column("provider")]
    public string Provider { get; set; } = null!;

    [Column("auth_identity_id")]
    public string AuthIdentityId { get; set; } = null!;

    [Column("user_metadata", TypeName = "jsonb")]
    public string? UserMetadata { get; set; }

    [Column("provider_metadata", TypeName = "jsonb")]
    public string? ProviderMetadata { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }

    [Column("deleted_at")]
    public DateTime? DeletedAt { get; set; }

    [ForeignKey("AuthIdentityId")]
    [InverseProperty("ProviderIdentities")]
    public virtual AuthIdentity AuthIdentity { get; set; } = null!;
}
