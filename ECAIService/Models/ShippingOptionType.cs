﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECAIService.Models;

[Table("shipping_option_type")]
public partial class ShippingOptionType
{
    [Key]
    [Column("id")]
    public string Id { get; set; } = null!;

    [Column("label")]
    public string Label { get; set; } = null!;

    [Column("description")]
    public string? Description { get; set; }

    [Column("code")]
    public string Code { get; set; } = null!;

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }

    [Column("deleted_at")]
    public DateTime? DeletedAt { get; set; }
}
