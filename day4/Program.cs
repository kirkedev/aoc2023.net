using day4;

var part1 = File.ReadLines("day4/input")
    .Select(Card.Parse)
    .Sum(card => card.WinningNumbers().Score());

Console.WriteLine(part1);
