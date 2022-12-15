using System.Text.RegularExpressions;
using MediatR;
using oEmbedTester.Application.Quries;
using oEmbedTester.Domain.oEmbedProvider;

namespace oEmbedTester.Application.Handlers;

public class ResolveProviderHandler : IRequestHandler<ResolveProviderQuery, OEmbedProvider>
{
    private readonly OEmbedProviderWrapper _oEmbedProviderWrapper;

    public ResolveProviderHandler(OEmbedProviderWrapper oEmbedProviderWrapper)
    {
        _oEmbedProviderWrapper = oEmbedProviderWrapper;
    }
    
    public Task<OEmbedProvider> Handle(ResolveProviderQuery request, CancellationToken cancellationToken)
    {
        var uri = new Uri(request.RequestedUrl);
        var providerUrl = $"{uri.Scheme}://{uri.Host}";

        return Task
            .FromResult(_oEmbedProviderWrapper
                .OEmbedProviders
                .SingleOrDefault(x => 
                    providerUrl
                        .ToLower()
                    .Contains(x.ProviderName
                            .ToLower())));
    }
}