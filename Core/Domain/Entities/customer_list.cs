using System;
using System.Collections.Generic;

namespace Core.Domain.Entities;

public partial class customer_list
{
    public int? id { get; set; }

    public string? name { get; set; }

    public string? address { get; set; }

    public string? zip_code { get; set; }

    public string? phone { get; set; }

    public string? city { get; set; }

    public string? country { get; set; }

    public string? notes { get; set; }

    public short? sid { get; set; }
}
