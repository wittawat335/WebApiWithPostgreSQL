using System;
using System.Collections.Generic;

namespace Core.Domain.Entities;

public partial class film_category
{
    public short film_id { get; set; }

    public short category_id { get; set; }

    public DateTime last_update { get; set; }
}
