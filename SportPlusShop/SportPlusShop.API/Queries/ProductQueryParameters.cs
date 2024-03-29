﻿namespace SportPlusShop.API.Queries;

public class ProductQueryParameters : QueryParameters
{
    public decimal? MinPrice { get; set; }

    public decimal? MaxPrice { get; set; }

    public string? Sku { get; set; }

    public string? Name { get; set; }

    public string? SearchTerm { get; set; }
}
