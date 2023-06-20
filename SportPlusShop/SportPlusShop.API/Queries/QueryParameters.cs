namespace SportPlusShop.API.Queries;

public class QueryParameters
{
    const int _maxSize = 100;
    private int _size = 50;
    private string _sortOrder = "asc";

    public int Page { get; set; }

    public int Size
    {
        get => _size;

        set => _size = Math.Min(_maxSize, value);
    }

    public string? SortBy { get; set; }

    public string SortOrder
    {
        get => _sortOrder;

        set => _sortOrder = (value is "asc" or "desc") ? value : "asc";
    }
}