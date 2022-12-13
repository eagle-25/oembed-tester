using Newtonsoft.Json;

namespace oEmbedTester.Domain.oEmbedProvider;

public class OEmbedProvider
{
    [JsonProperty("provider_name")]
    public string? ProviderName { get; set; }
    [JsonProperty("provider_url")]
    public string? ProviderUrl { get; set; }
    public IEnumerable<EndPoint>? Endpoints { get; set; }
}