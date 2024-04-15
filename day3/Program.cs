using System.Diagnostics.CodeAnalysis;
using day3;

var schematic = new Schematic(File.ReadLines("day3/input"));

var part1 = schematic.GetNumbers()
    .Where(entry => entry
        .GetBorderPoints(schematic.Boundary)
        .Select(schematic.Get)
        .Any(Day3.IsSymbol))
    .Sum(entry => int.Parse(entry.Contents));

Console.WriteLine(part1);

var part2 = schematic.GetSymbols()
    .Select(symbol => symbol.Location)
    .Select(location => schematic.GetNumbers()
        .Where(number => number
            .GetBorderPoints(schematic.Boundary)
            .Any(point => point == location)))
    .Where(numbers => numbers.Count() == 2)
    .Aggregate(0, (total, numbers) =>
        total + numbers.Aggregate(1, (product, number) => product * int.Parse(number.Contents)));

Console.WriteLine(part2);

[ExcludeFromCodeCoverage]
public partial class Program
{
}
