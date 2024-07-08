namespace NewDay.DiamondKata.Services.Implementations;

public class DiamondGenerator : IDiamondGenerator
{
    public IEnumerable<string> GenerateDiamondLines(char seperator, char endCharacter) =>
        GenerateDiamondLinesTop(seperator, endCharacter)
        .Concat(GenerateDiamondLinesBottom(seperator, endCharacter));

    public IEnumerable<string> GenerateDiamondLinesTop(char seperator, char endCharacter) =>
          CharHelpers.Range(StartingCharacter(endCharacter), endCharacter)
           .Select(c => BuildRow(
               strBuilder: new StringBuilder(),
               seperator: seperator,
               character: c,
               startingCharacter : StartingCharacter(endCharacter),
               endCharacter: endCharacter)
           .ToString());

    public IEnumerable<string> GenerateDiamondLinesBottom(char seperator, char endCharacter) =>
        GenerateDiamondLinesTop(seperator, endCharacter).Reverse().Skip(1);

    public StringBuilder BuildRow(StringBuilder strBuilder, char seperator, char character, char startingCharacter, char endCharacter) =>
            character == startingCharacter
                ? BuildFirstRow(strBuilder, seperator, character, endCharacter)
                : BuildOtherRow(strBuilder, seperator, character, endCharacter);

    private StringBuilder BuildFirstRow(StringBuilder strBuilder, char seperator, char character, char endCharacter) =>
        strBuilder.
            AppendRepeat($"{seperator}", RowCharacterPadding(character, endCharacter))
            .Append(character)
            .AppendRepeat($"{seperator}", RowCharacterPadding(character, endCharacter));

    private StringBuilder BuildOtherRow(StringBuilder strBuilder, char seperator, char character, char endCharacter) =>
        strBuilder.
            AppendRepeat($"{seperator}", RowCharacterPadding(character, endCharacter))
            .Append(character)
            .AppendRepeat($"{seperator}", RowCharacterGap(character, endCharacter))
            .Append(character)
            .AppendRepeat($"{seperator}", RowCharacterPadding(character, endCharacter));

    private int RowCharacterGap(char character, char endCharacter) =>
         (CharacterPosition(character) * 2) -1;

    private int CharacterPosition(char character) =>
        character - StartingCharacter(character);

    private int RowCharacterPadding(char character, char endCharacter) =>
        CharacterPosition(endCharacter) - CharacterPosition(character);

    private char StartingCharacter(char endCharacter) =>
        CharUnicodeInfo.GetUnicodeCategory(endCharacter) switch
        {
            UnicodeCategory.UppercaseLetter => 'A',
            UnicodeCategory.LowercaseLetter => 'a',
            _ => throw new NotALetterCharacterException(endCharacter)
        };
}
