using MediatR;
using Newtonsoft.Json;
using oEmbedTester.Application.Quries;
using oEmbedTester.Domain.OEmbed;

namespace oEmbedTester.Application.Handlers;

public class GetOEmbedFromProviderHandler:  IRequestHandler<GetOEmbedFromProviderQuery, OEmbedProviderResponse>
{
    private readonly IMediator _mediator;
    private readonly IHttpClientFactory _httpClientFactory;

    public GetOEmbedFromProviderHandler(IMediator mediator, IHttpClientFactory httpClientFactory)
    {
        _mediator = mediator;
        _httpClientFactory = httpClientFactory;
    }

    public async Task<OEmbedProviderResponse> Handle(GetOEmbedFromProviderQuery request, CancellationToken cancellationToken)
    {
        var provider = await _mediator
            .Send(new ResolveProviderQuery()
            {
                RequestedUrl = request.requestedUrl
            }, cancellationToken);

        using var httpClient = _httpClientFactory
            .CreateClient();

        var providerUrl = provider
            .Endpoints
            .First()
            .Url
            .Replace("{format}","json");

        var oEmbedRequestingUrl = $"{providerUrl}?url={request.requestedUrl}";

        var httpResponse = await httpClient
            .GetStringAsync(oEmbedRequestingUrl, cancellationToken);

        return JsonConvert
            .DeserializeObject<OEmbedProviderResponse>(httpResponse) ?? throw new InvalidOperationException("Provider로부터 OEmbed 데이터를 받아오지 못 했습니다.");
    }
}