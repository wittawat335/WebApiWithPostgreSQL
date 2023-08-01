using System;
using System.Collections.Generic;

namespace Core.Domain.Entities;

public partial class inventory
{
    public int inventory_id { get; set; }

    public short film_id { get; set; }

    public short store_id { get; set; }

    public DateTime last_update { get; set; }

    public virtual ICollection<rental> rental { get; set; } = new List<rental>();
}
