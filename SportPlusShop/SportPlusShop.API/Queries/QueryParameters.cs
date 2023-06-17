namespace SportPlusShop.API.Queries;

public class QueryParameters
{
    const int _maxSize = 100;
    private int _size = 50;

    public int Page { get; set; }

    public int Size
    {
        get => _size;

        set => _size = Math.Min(_maxSize, value);
    }
}