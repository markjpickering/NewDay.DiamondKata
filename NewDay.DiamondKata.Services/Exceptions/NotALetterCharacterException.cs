using System.Globalization;

namespace NewDay.DiamondKata.Services.Exceptions;

public class NotALetterCharacterException : Exception
{
    public NotALetterCharacterException(char errorChar, string message= "", Exception? innerException = null)
        : base($"Character '{errorChar}' \\U {errorChar:D} must be a letter but is instead of category {CharUnicodeInfo.GetUnicodeCategory(errorChar)} ", innerException)
    {
    }
}
