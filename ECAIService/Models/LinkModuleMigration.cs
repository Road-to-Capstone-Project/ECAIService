using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECAIService.Models;

[Table("link_module_migrations")]
[Index("TableName", Name = "link_module_migrations_table_name_key", IsUnique = true)]
public partial class LinkModuleMigration
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("table_name")]
    [StringLength(255)]
    public string TableName { get; set; } = null!;

    [Column("link_descriptor", TypeName = "jsonb")]
    public string LinkDescriptor { get; set; } = null!;

    [Column("created_at", TypeName = "timestamp without time zone")]
    public DateTime? CreatedAt { get; set; }
}
