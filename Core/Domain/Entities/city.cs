using System;
using System.Collections.Generic;

namespace Core.Domain.Entities;

public partial class city
{
    public int city_id { get; set; }

    public string city1 { get; set; } = null!;

    public short country_id { get; set; }

    public DateTime last_update { get; set; }
}
