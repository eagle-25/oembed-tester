using System.Net;
using MediatR;
using Newtonsoft.Json;
using oEmbedTester.Application.Quries;
using oEmbedTester.Data;
using oEmbedTester.Domain.Exceptions;
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
        #region Resolve Provider
        var provider = await _mediator
            .Send(new ResolveProviderQuery()
            {
                RequestedUrl = request.requestedUrl
            }, cancellationToken);

        if (provider is null)
            throw new ProviderNotFoundException();

        var providerUrl = (provider
                .Endpoints ?? throw new InvalidOperationException())
            .First()
            .Url;

        var oEmbedRequestingUrl = $"{providerUrl}?url={request.requestedUrl}";
        #endregion
        #region Get oEmbedResponse from provider
        var httpResponse = await _httpClientFactory
            .CreateClient()
            .GetAsync(oEmbedRequestingUrl, cancellationToken);

        if (httpResponse.StatusCode == HttpStatusCode.BadRequest)
            throw new ContentNotFoundException();

        var responseBody = await httpResponse
            .Content
            .ReadAsStringAsync(cancellationToken);
        #endregion
        
        return JsonConvert
            .DeserializeObject<OEmbedProviderResponse>(responseBody) ?? throw new InvalidOperationException("Provider로부터 OEmbed 데이터를 받아오지 못 했습니다.");
 
    }
}