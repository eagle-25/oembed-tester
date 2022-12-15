using MediatR;
using Microsoft.AspNetCore.Mvc;
using oEmbedTester.Application.Quries;
using oEmbedTester.Domain.OEmbed;
using oEmbedTester.Domain.oEmbedProvider;

namespace oEmbedTester.Controllers;

[Route("[controller]")]
[ApiController]
public class OEmbedTesterController
{
  private readonly ILogger<OEmbedTesterController> _logger;
  private readonly IMediator _mediator;

  public OEmbedTesterController(ILogger<OEmbedTesterController> logger, IMediator mediator)
  {
    _logger = logger;
    _mediator = mediator;
  }
  
  [HttpGet(Name = "GetOEmbed")]
  public async Task<OEmbed> GetOEmbed(string url)
  {
    return await _mediator
      .Send(new GetOEmbedFromProviderQuery()
      {
        requestedUrl = url
      });
  }
}