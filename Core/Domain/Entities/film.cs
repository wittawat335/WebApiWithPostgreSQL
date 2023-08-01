using System;
using System.Collections.Generic;
using NpgsqlTypes;

namespace Core.Domain.Entities;

public partial class film
{
    public int film_id { get; set; }

    public string title { get; set; } = null!;

    public string? description { get; set; }

    public int? release_year { get; set; }

    public short language_id { get; set; }

    public short rental_duration { get; set; }

    public decimal rental_rate { get; set; }

    public short? length { get; set; }

    public decimal replacement_cost { get; set; }

    public DateTime last_update { get; set; }

    public string[]? special_features { get; set; }

    public NpgsqlTsVector fulltext { get; set; } = null!;
}
