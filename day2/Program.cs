using System.Diagnostics.CodeAnalysis;
using day2;

var part1 = File.ReadLines("day2/input")
    .Select(Day2.ParseGame)
    .Where(Day2.IsValid(new Round(12, 13, 14)))
    .Sum(game => game.Id);

Console.WriteLine(part1);

var part2 = File.ReadLines("day2/input")
    .Select(Day2.ParseGame)
    .Select(Day2.Minimums)
    .Sum(Day2.Power);

Console.WriteLine(part2);

return 0;

[ExcludeFromCodeCoverage]
public partial class Program
{
}
