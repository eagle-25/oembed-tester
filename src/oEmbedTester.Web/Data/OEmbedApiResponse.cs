using oEmbedTester.Domain.OEmbed;

namespace oEmbedTester.Web.Data;

public class OEmbedApiResponse : IOEmbedResponse
{
    public string? Type { get; set; }
    public string? Version { get; set; }
    public string? Title { get; set; }
    public string? AuthorName { get; set; }
    public string? AuthorUrl { get; set; }
    public string? ProviderName { get; set; }
    public string? ProviderUrl { get; set; }
    public long? CacheAge { get; set; }
    public string? ThumbnailUrl { get; set; }
    public int? ThumbnailWidth { get; set; }
    public int? ThumbnailHeight { get; set; }
    public string? Url { get; set; }
    public int? Width { get; set; }
    public int? Height { get; set; }
    public string? HTML { get; set; }
}