using System;
using System.Collections.Generic;

namespace Core.Domain.Entities;

public partial class film_actor
{
    public short actor_id { get; set; }

    public short film_id { get; set; }

    public DateTime last_update { get; set; }
}
