namespace NewDay.DiamondKata.Services.HelperMethods;

public static class CharHelpers
{
    static public IEnumerable<char> Range(char startChar, char? endChar)
    {
        var c = startChar;

        while(endChar == null || c <= endChar.Value )
            yield return c++;
    }
}
