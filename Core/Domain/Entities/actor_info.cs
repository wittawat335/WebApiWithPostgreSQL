using System;
using System.Collections.Generic;

namespace Core.Domain.Entities;

public partial class actor_info
{
    public int? actor_id { get; set; }

    public string? first_name { get; set; }

    public string? last_name { get; set; }

    public string? film_info { get; set; }
}
