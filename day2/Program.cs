﻿using System.Diagnostics.CodeAnalysis;
using day2;

var part1 = File.ReadLines("day2/input")
    .Select(Game.Parse)
    .Where(Day2.IsValid(new Round(Red: 12, Green: 13, Blue: 14)))
    .Sum(game => game.Id);

Console.WriteLine(part1);

var part2 = File.ReadLines("day2/input")
    .Select(Game.Parse)
    .Select(Day2.Minimums)
    .Sum(Day2.Power);

Console.WriteLine(part2);

return 0;

[ExcludeFromCodeCoverage]
public partial class Program
{
}
