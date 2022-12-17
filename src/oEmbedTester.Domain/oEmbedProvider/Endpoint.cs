namespace oEmbedTester.Domain.oEmbedProvider;

public class EndPoint
{
    private readonly string? _url;
    
    public IEnumerable<string>? Schemes { get; set; }
    public string? Url
    {
        get => _url;
        init => _url = value
            .Replace("{format}","json");
    }
    public bool Discovery { get; set; }
    public IEnumerable<string>? Formats { get; set; }
}