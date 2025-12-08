using System.Globalization;

namespace CleanTemplate.Application.Common.Exceptions;

public class ApplicationException : Exception
{
    public ApplicationException() : base() { }
    public ApplicationException(string message) : base(message) { }
    public ApplicationException(string message, object args) : base(string.Format(CultureInfo.CurrentCulture, message, args)) { }

}
