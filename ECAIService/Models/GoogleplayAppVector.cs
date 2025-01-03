using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECAIService.Models;

[Table("googleplay_app_vectors")]
public partial class GoogleplayAppVector
{
    [Key]
    [Column("id")]
    public long Id { get; set; }
}
