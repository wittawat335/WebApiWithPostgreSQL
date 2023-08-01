using System;
using System.Collections.Generic;

namespace Core.Domain.Entities;

public partial class country
{
    public int country_id { get; set; }

    public string country1 { get; set; } = null!;

    public DateTime last_update { get; set; }
}
