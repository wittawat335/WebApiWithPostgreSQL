using System;
using System.Collections.Generic;

namespace Core.Domain.Entities;

public partial class film_list
{
    public int? fid { get; set; }

    public string? title { get; set; }

    public string? description { get; set; }

    public string? category { get; set; }

    public decimal? price { get; set; }

    public short? length { get; set; }

    public string? actors { get; set; }
}
