using System.Diagnostics.CodeAnalysis;
using day3;

var schematic = Schematic.Parse(File.ReadLines("day3/input"));

var part1 = schematic.Numbers()
    .Where(entry => entry
        .GetBorderPoints(schematic.Boundary)
        .Select(point => schematic[point])
        .Any(Day3.IsSymbol))
    .Sum(entry => int.Parse(entry.Contents));

Console.WriteLine(part1);

var part2 = schematic.Symbols()
    .Select(symbol => symbol.Location())
    .Select(location => schematic.Numbers()
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
