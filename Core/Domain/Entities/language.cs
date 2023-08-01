using System;
using System.Collections.Generic;

namespace Core.Domain.Entities;

public partial class language
{
    public int language_id { get; set; }

    public string name { get; set; } = null!;

    public DateTime last_update { get; set; }
}
