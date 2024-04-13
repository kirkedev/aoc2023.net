using System.Diagnostics.CodeAnalysis;
using day1;

var part1 = File.ReadLines("day1/input")
    .Select(Day1.GetNumbers)
    .Sum();

Console.WriteLine(part1);

var part2 = File.ReadLines("day1/input")
    .Select(Day1.GetTextNumbers)
    .Sum();

Console.WriteLine(part2);

return 0;

[ExcludeFromCodeCoverage]
public partial class Program
{
}
