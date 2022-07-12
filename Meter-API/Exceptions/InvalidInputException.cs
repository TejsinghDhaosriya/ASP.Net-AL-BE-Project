namespace Meter_API.Exceptions;

public class InvalidInputException : ApplicationException
{
    public InvalidInputException(string name)
        : base(name)
    {
    }
}