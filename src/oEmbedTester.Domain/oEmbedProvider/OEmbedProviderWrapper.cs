namespace oEmbedTester.Domain.oEmbedProvider;

public class OEmbedProviderWrapper
{
    public IEnumerable<OEmbedProvider>? OEmbedProviders { get; private set; }

    public void FetchProviders(IEnumerable<OEmbedProvider>? providers)
    {
        OEmbedProviders = providers;
    }
}