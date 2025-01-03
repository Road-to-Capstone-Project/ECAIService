using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECAIService.Models;

[Table("fulfillment_label")]
public partial class FulfillmentLabel
{
    [Key]
    [Column("id")]
    public string Id { get; set; } = null!;

    [Column("tracking_number")]
    public string TrackingNumber { get; set; } = null!;

    [Column("tracking_url")]
    public string TrackingUrl { get; set; } = null!;

    [Column("label_url")]
    public string LabelUrl { get; set; } = null!;

    [Column("fulfillment_id")]
    public string FulfillmentId { get; set; } = null!;

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }

    [Column("deleted_at")]
    public DateTime? DeletedAt { get; set; }

    [ForeignKey("FulfillmentId")]
    [InverseProperty("FulfillmentLabels")]
    public virtual Fulfillment Fulfillment { get; set; } = null!;
}
