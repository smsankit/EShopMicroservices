

namespace BuildingBlocks.Exceptions;

public class BadRequestException : Exception
{
    public BadRequestException(string message) : base(message)
    {

    }

    public BadRequestException(string msg, string details) : base(msg)
    {
        Details = details;
    }

    public string? Details { get; }
}
