using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace StolicaLetoApi.Models;

public partial class Number
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public string? Dates { get; set; }

    public string? Color { get; set; }

    public bool? IsAvailable { get; set; }
}
