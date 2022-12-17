namespace oEmbedTester.Domain.Exceptions;

public class ProviderNotFoundException : Exception
{
    public string RequestedUrl { get; set; }
}