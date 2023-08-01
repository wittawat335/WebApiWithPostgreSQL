using System;
using System.Collections.Generic;

namespace Core.Domain.Entities;

public partial class customer
{
    public int customer_id { get; set; }

    public short store_id { get; set; }

    public string first_name { get; set; } = null!;

    public string last_name { get; set; } = null!;

    public string? email { get; set; }

    public short address_id { get; set; }

    public bool? activebool { get; set; }

    public DateOnly create_date { get; set; }

    public DateTime? last_update { get; set; }

    public int? active { get; set; }
}
