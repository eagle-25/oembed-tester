using MediatR;
using oEmbedTester.Domain.OEmbed;
using oEmbedTester.Domain.oEmbedProvider;

namespace oEmbedTester.Application.Quries;

public class GetOEmbedFromProviderQuery : IRequest<OEmbedProviderResponse>
{
    public string requestedUrl { get; set; }
}