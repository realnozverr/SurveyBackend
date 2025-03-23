using System.Diagnostics.CodeAnalysis;

namespace Domain.Exceptions.ArgumentException
{
    [ExcludeFromCodeCoverage]
    public class ValueIsInvalidException(string message) : Exception(message);
}
