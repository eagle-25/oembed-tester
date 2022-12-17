namespace oEmbedTester.Domain.Exceptions;

public class ContentNotFoundException : Exception
{
    public string RequestedUrl { get; set; }
}