using NewDay.DiamondKata.Services.ExtensionMethods;

namespace NewDay.DiamondKata.Console;

internal class Application
{
    private readonly IDiamondGenerator _diamondGenerator;

    public Application(IDiamondGenerator diamondGenerator)
    {
        _diamondGenerator = diamondGenerator;
    }

    public void Run(string[] args)
    {
        var commandName = Path.GetFileNameWithoutExtension(Environment.CommandLine.Split(' ')[0]);

        if (args.Length != 1 || args[0].Length != 1)
        {
            HelpText(commandName);
            return;
        }

        _diamondGenerator
            .GenerateDiamondLines(' ', args[0].Trim()[0])
            .ForEach(WriteLine);
    }

    public void HelpText(string commandName)
    {
        WriteLine($"Diamond Generator");
        WriteLine($"Usage: {commandName} letter");
        WriteLine($"where letter is single letter");
        WriteLine($"Example: {commandName} a");
    }
}
