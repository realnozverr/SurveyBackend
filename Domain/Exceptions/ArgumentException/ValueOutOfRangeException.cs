using System.Diagnostics.CodeAnalysis;

namespace Domain.Exceptions.ArgumentException
{
    [ExcludeFromCodeCoverage]
    public class ValueOutOfRangeException(string message = "Value out of range") : ArgumentException(message);
}
