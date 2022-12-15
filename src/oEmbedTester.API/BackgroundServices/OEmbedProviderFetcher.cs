using Newtonsoft.Json;
using oEmbedTester.Domain.oEmbedProvider;

namespace oEmbedTester.BackgroundServices;

public class OEmbedProviderFetcher : BackgroundService
{
    private readonly ILogger<OEmbedProviderFetcher> _logger;
    private readonly string? _providerUrl;
    private readonly string? _fetchingPeriod;
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly OEmbedProviderWrapper _oEmbedProviderWrapper;

    public OEmbedProviderFetcher(IConfiguration config, IHttpClientFactory httpClientFactory, OEmbedProviderWrapper oEmbedProviderWrapper, ILogger<OEmbedProviderFetcher> logger)
    {
        _logger = logger;
        _providerUrl = config
            .GetValue<string>("OEmbedProvider:JsonProviderUrl");
        _fetchingPeriod = config
            .GetValue<string>("OEmbedProvider:FetchingPeriod");
        _httpClientFactory = httpClientFactory;
        _oEmbedProviderWrapper = oEmbedProviderWrapper;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (true)
        {
            var jsonProvider = await _httpClientFactory
                .CreateClient()
                .GetStringAsync(_providerUrl, stoppingToken);
            
            _oEmbedProviderWrapper
                .FetchProviders(JsonConvert
                    .DeserializeObject<IEnumerable<OEmbedProvider>>(jsonProvider));
            
            _logger
                .LogInformation($"Fetching oEmbedProvider from {_providerUrl} is completed.");

            await Task
                .Delay(TimeSpan.Parse(_fetchingPeriod ?? "00:01:00"), stoppingToken);
        }
    }
}