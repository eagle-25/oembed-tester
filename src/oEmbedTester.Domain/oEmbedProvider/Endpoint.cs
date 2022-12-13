namespace oEmbedTester.Domain.oEmbedProvider;

public class EndPoint
{
    public IEnumerable<string>? Schemes { get; set; }
    public string? Url { get; set; }
    public bool Discovery { get; set; }
    public IEnumerable<string>? Formats { get; set; }
}