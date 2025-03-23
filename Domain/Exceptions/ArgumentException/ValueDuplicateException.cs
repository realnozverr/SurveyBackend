using System.Diagnostics.CodeAnalysis;

namespace Domain.Exceptions.ArgumentException
{
    [ExcludeFromCodeCoverage]
    public class ValueDuplicateException(string message = "Value is duplicate") : ArgumentException(message);
}
