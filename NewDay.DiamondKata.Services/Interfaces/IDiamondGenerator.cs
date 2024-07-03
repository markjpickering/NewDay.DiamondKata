namespace NewDay.DiamondKata.Services.Interfaces;

public interface IDiamondGenerator
{
    IEnumerable<string> GenerateDiamondLines(char seperator, char character);
}
