using Newtonsoft.Json;
using oEmbedTester.Domain.OEmbed;

namespace oEmbedTester.Data;

public class OEmbedProviderResponse : IOEmbedResponse
{
    [JsonProperty("type")]
    public string? Type { get; set; }
    [JsonProperty("version")]
    public string? Version { get; set; }
    [JsonProperty("title")]
    public string? Title { get; set; }
    [JsonProperty("author_name")]
    public string? AuthorName { get; set; }
    [JsonProperty("author_url")]
    public string? AuthorUrl { get; set; }
    [JsonProperty("provider_name")]
    public string? ProviderName { get; set; }
    [JsonProperty("provider_url")]
    public string? ProviderUrl { get; set; }
    [JsonProperty("cache_age")]
    public long? CacheAge { get; set; }
    [JsonProperty("thumbnail_url")]
    public string? ThumbnailUrl { get; set; }
    [JsonProperty("thumbnail_width")]
    public int? ThumbnailWidth { get; set; }
    [JsonProperty("thumbnail_height")]
    public int? ThumbnailHeight { get; set; }
    [JsonProperty("url")]
    public string? Url { get; set; }
    [JsonProperty("width")]
    public int? Width { get; set; }
    [JsonProperty("height")]
    public int? Height { get; set; }
    [JsonProperty("html")]
    public string? HTML { get; set; }
}