using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECAIService.Models;

[Table("notification_provider")]
public partial class NotificationProvider
{
    [Key]
    [Column("id")]
    public string Id { get; set; } = null!;

    [Column("handle")]
    public string Handle { get; set; } = null!;

    [Column("name")]
    public string Name { get; set; } = null!;

    [Column("is_enabled")]
    public bool IsEnabled { get; set; }

    [Column("channels")]
    public List<string> Channels { get; set; } = null!;

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }

    [Column("deleted_at")]
    public DateTime? DeletedAt { get; set; }

    [InverseProperty("Provider")]
    public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();
}
