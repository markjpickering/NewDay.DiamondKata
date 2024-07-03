namespace NewDay.DiamondKata.ServicesTests.UnitTests;

public class DiamondGeneratorTests
{
    public DiamondGenerator _sut;

    public DiamondGeneratorTests()
    {
        _sut = new DiamondGenerator(); 
    }

    [Theory, ClassData(typeof(DiamondGeneratorTestData))]
    public void WhenGiven_Valid_Letter_Should_Output_Correct_Diamond_Lines(char inputLetter, string[] expectedOutputLines)
    {
        // Arrange
        // Act
        var outputLines = _sut.GenerateDiamondLines('-', inputLetter).ToArray();

        // Assert
        outputLines.Should().NotBeNullOrEmpty();
        outputLines.Should().HaveCount(expectedOutputLines.Count());

        // Iterating rather than usiong BeEquivalentTo for clearer output and to allow breakpoints
        for (int i = 0; i < expectedOutputLines.Length; i++)
        {
            outputLines[i].Should().Be(expectedOutputLines[i] , $"Input letter: '{inputLetter}' Line {i} incorrect");
        }        
    }

    [Theory]
    [InlineData('@')]
    [InlineData('[')]
    [InlineData('`')]
    [InlineData('{')]
    public void WhenGiven_Invalid_Letter_Throw(char inputLetter)
    {
        // Arrange
        // Act
        var ex = Record.Exception(
            () => _sut.GenerateDiamondLines('-', inputLetter)
        );

        // Assert
        ex.Should().NotBeNull();
        ex.Should().BeOfType<NotALetterCharacterException>();
    }
}