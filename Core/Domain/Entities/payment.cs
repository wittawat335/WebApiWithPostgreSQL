using System;
using System.Collections.Generic;

namespace Core.Domain.Entities;

public partial class payment
{
    public int payment_id { get; set; }

    public short customer_id { get; set; }

    public short staff_id { get; set; }

    public int rental_id { get; set; }

    public decimal amount { get; set; }

    public DateTime payment_date { get; set; }

    public virtual rental rental { get; set; } = null!;
}
