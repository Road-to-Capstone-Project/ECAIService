using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECAIService.Models;

[Table("return_reason")]
public partial class ReturnReason
{
    [Key]
    [Column("id", TypeName = "character varying")]
    public string Id { get; set; } = null!;

    [Column("value", TypeName = "character varying")]
    public string Value { get; set; } = null!;

    [Column("label", TypeName = "character varying")]
    public string Label { get; set; } = null!;

    [Column("description", TypeName = "character varying")]
    public string? Description { get; set; }

    [Column("metadata", TypeName = "jsonb")]
    public string? Metadata { get; set; }

    [Column("parent_return_reason_id", TypeName = "character varying")]
    public string? ParentReturnReasonId { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }

    [Column("deleted_at")]
    public DateTime? DeletedAt { get; set; }

    [InverseProperty("ParentReturnReason")]
    public virtual ICollection<ReturnReason> InverseParentReturnReason { get; set; } = new List<ReturnReason>();

    [ForeignKey("ParentReturnReasonId")]
    [InverseProperty("InverseParentReturnReason")]
    public virtual ReturnReason? ParentReturnReason { get; set; }
}
