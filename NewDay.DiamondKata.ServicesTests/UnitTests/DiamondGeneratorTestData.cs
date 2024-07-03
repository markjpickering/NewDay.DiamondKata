using System.Collections;

namespace NewDay.DiamondKata.ServicesTests.UnitTests;

public class DiamondGeneratorTestData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return ['a', DiamondA().Select(line => line.ToLower()).ToList()];
        yield return ['b', DiamondB().Select(line => line.ToLower()).ToList()];
        yield return ['c', DiamondC().Select(line => line.ToLower()).ToList()];
        yield return ['d', DiamondD().Select(line => line.ToLower()).ToList()];
        yield return ['e', DiamondE().Select(line => line.ToLower()).ToList()];

        yield return ['A', DiamondA().ToList()];
        yield return ['B', DiamondB().ToList()];
        yield return ['C', DiamondC().ToList()];
        yield return ['D', DiamondD().ToList()];
        yield return ['E', DiamondE().ToList()];
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();  

    public IEnumerable<string> DiamondA()
    {
        yield return "A";
    }

    public IEnumerable<string> DiamondB()
    {
        yield return "-A-";
        yield return "B-B";
        yield return "-A-";
    }

    public IEnumerable<string> DiamondC()
    {
        yield return "--A--";
        yield return "-B-B-";
        yield return "C---C";
        yield return "-B-B-";
        yield return "--A--";
    }

    public IEnumerable<string> DiamondD()
    {
        yield return "---A---";
        yield return "--B-B--";
        yield return "-C---C-";
        yield return "D-----D";
        yield return "-C---C-";
        yield return "--B-B--";
        yield return "---A---";
    }

    public IEnumerable<string> DiamondE()
    {
        yield return "----A----";
        yield return "---B-B---";
        yield return "--C---C--";
        yield return "-D-----D-";
        yield return "E-------E";
        yield return "-D-----D-";
        yield return "--C---C--";
        yield return "---B-B---";
        yield return "----A----";
    }
}
