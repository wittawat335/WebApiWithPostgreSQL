using System;
using System.Collections.Generic;

namespace Core.Domain.Entities;

public partial class rental
{
    public int rental_id { get; set; }

    public DateTime rental_date { get; set; }

    public int inventory_id { get; set; }

    public short customer_id { get; set; }

    public DateTime? return_date { get; set; }

    public short staff_id { get; set; }

    public DateTime last_update { get; set; }

    public virtual inventory inventory { get; set; } = null!;

    public virtual ICollection<payment> payment { get; set; } = new List<payment>();
}
