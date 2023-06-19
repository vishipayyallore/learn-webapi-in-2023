namespace SportPlusShop.API.Queries;

public class ProductQueryParameters : QueryParameters
{
    public decimal? MinPrice { get; set; }

    public decimal? MaxPrice { get; set; }
}
