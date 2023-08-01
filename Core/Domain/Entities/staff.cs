using System;
using System.Collections.Generic;

namespace Core.Domain.Entities;

public partial class staff
{
    public int staff_id { get; set; }

    public string first_name { get; set; } = null!;

    public string last_name { get; set; } = null!;

    public short address_id { get; set; }

    public string? email { get; set; }

    public short store_id { get; set; }

    public bool? active { get; set; }

    public string username { get; set; } = null!;

    public string? password { get; set; }

    public DateTime last_update { get; set; }

    public byte[]? picture { get; set; }
}
