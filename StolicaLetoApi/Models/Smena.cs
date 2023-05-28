using System;
using System.Collections.Generic;

namespace StolicaLetoApi.Models;

public partial class Smena
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public string? Dates { get; set; }

    public string? Color { get; set; }

    public bool? IsAvailable { get; set; }

    public int? Number { get; set; }
}
