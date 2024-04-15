

namespace BuildingBlocks.Exceptions;

public class InternalServerException : Exception
{
    public InternalServerException(string message) : base(message) { 
    
    }

    public InternalServerException(string msg, string details) : base(msg) 
    {
        Details = details;
    }

    public string? Details { get; }
}
