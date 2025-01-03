using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECAIService.Models;

[Table("notification")]
[Index("ProviderId", Name = "IDX_notification_provider_id")]
[Index("ReceiverId", Name = "IDX_notification_receiver_id")]
public partial class Notification
{
    [Key]
    [Column("id")]
    public string Id { get; set; } = null!;

    [Column("to")]
    public string To { get; set; } = null!;

    [Column("channel")]
    public string Channel { get; set; } = null!;

    [Column("template")]
    public string Template { get; set; } = null!;

    [Column("data", TypeName = "jsonb")]
    public string? Data { get; set; }

    [Column("trigger_type")]
    public string? TriggerType { get; set; }

    [Column("resource_id")]
    public string? ResourceId { get; set; }

    [Column("resource_type")]
    public string? ResourceType { get; set; }

    [Column("receiver_id")]
    public string? ReceiverId { get; set; }

    [Column("original_notification_id")]
    public string? OriginalNotificationId { get; set; }

    [Column("idempotency_key")]
    public string? IdempotencyKey { get; set; }

    [Column("external_id")]
    public string? ExternalId { get; set; }

    [Column("provider_id")]
    public string? ProviderId { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }

    [Column("deleted_at")]
    public DateTime? DeletedAt { get; set; }

    [Column("status")]
    public string Status { get; set; } = null!;

    [ForeignKey("ProviderId")]
    [InverseProperty("Notifications")]
    public virtual NotificationProvider? Provider { get; set; }
}
