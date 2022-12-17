using System.Net;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using oEmbedTester.Application.Quries;
using oEmbedTester.Data;
using oEmbedTester.Domain.OEmbed;
using oEmbedTester.Filters;

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
  
  [ProviderNotFoundExceptionFilter]
  [ContentNotFoundExceptionFilter]
  [HttpGet(Name = "GetOEmbed")]
  public async Task<OEmbedProviderResponse> GetOEmbed(string url)
  {
    return await _mediator
      .Send(new GetOEmbedFromProviderQuery()
      {
        requestedUrl = url
      });
  }
}
