using System.Diagnostics.CodeAnalysis;

namespace Domain.Exceptions.ArgumentException
{
    [ExcludeFromCodeCoverage]
    public class ArgumentException(string message) : Exception(message);
}
