using System;
using System.Collections.Generic;

namespace Core.Domain.Entities;

public partial class category
{
    public int category_id { get; set; }

    public string name { get; set; } = null!;

    public DateTime last_update { get; set; }
}
