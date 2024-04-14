using System.Diagnostics.CodeAnalysis;
using day3;

var schematic = new Schematic(File.ReadLines("day3/input"));

var part1 = schematic.GetNumbers()
    .Where(entry =>
        entry.GetBorderPoints(schematic.Boundary)
            .Select(schematic.Get)
            .Any(Day3.IsSymbol))
    .Sum(entry => int.Parse(entry.Contents));

Console.WriteLine(part1);

[ExcludeFromCodeCoverage]
public partial class Program
{
}
