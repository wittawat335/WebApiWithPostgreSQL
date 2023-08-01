using System;
using System.Collections.Generic;

namespace Core.Domain.Entities;

public partial class actor
{
    public int actor_id { get; set; }

    public string first_name { get; set; } = null!;

    public string last_name { get; set; } = null!;

    public DateTime last_update { get; set; }
}
