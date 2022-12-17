using MediatR;
using oEmbedTester.Domain.oEmbedProvider;

namespace oEmbedTester.Application.Quries;

public class ResolveProviderQuery : IRequest<OEmbedProvider>
{
    public string? RequestedUrl { get; set; }
}