using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECAIService.Models;

[PrimaryKey("WorkflowId", "TransactionId")]
[Table("workflow_execution")]
public partial class WorkflowExecution
{
    [Column("id", TypeName = "character varying")]
    public string Id { get; set; } = null!;

    [Key]
    [Column("workflow_id", TypeName = "character varying")]
    public string WorkflowId { get; set; } = null!;

    [Key]
    [Column("transaction_id", TypeName = "character varying")]
    public string TransactionId { get; set; } = null!;

    [Column("execution", TypeName = "jsonb")]
    public string? Execution { get; set; }

    [Column("context", TypeName = "jsonb")]
    public string? Context { get; set; }

    [Column("state", TypeName = "character varying")]
    public string State { get; set; } = null!;

    [Column("created_at", TypeName = "timestamp without time zone")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at", TypeName = "timestamp without time zone")]
    public DateTime UpdatedAt { get; set; }

    [Column("deleted_at", TypeName = "timestamp without time zone")]
    public DateTime? DeletedAt { get; set; }
}
