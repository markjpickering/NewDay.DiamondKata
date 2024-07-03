namespace NewDay.DiamondKata.Services.ExtensionMethods;

public static class StringBuilderExtensions
{
    public static StringBuilder AppendRepeat(this StringBuilder stringBuilder, string repeatedString, int numberOfRepeats)
    {
        for (var i = 0; i < numberOfRepeats; i++)
            stringBuilder.Append(repeatedString);

        return stringBuilder;
    }
}
