using System;
using System.Collections.Generic;

namespace Core.Domain.Entities;

public partial class sales_by_film_category
{
    public string? category { get; set; }

    public decimal? total_sales { get; set; }
}
