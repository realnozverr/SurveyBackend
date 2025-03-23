using System.Diagnostics.CodeAnalysis;

namespace Domain.Exceptions.ArgumentException
{
    [ExcludeFromCodeCoverage]
    public class ValueIsNullException(string message = "Value is null") : ArgumentException(message);
}
