using System;
using System.Collections.Generic;

namespace Core.Domain.Entities;

public partial class store
{
    public int store_id { get; set; }

    public short manager_staff_id { get; set; }

    public short address_id { get; set; }

    public DateTime last_update { get; set; }
}
