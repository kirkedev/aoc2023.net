using day4;

var part1 = File.ReadLines("day4/input")
    .Select(Card.Parse)
    .Sum(card => card.WinningNumbers().Score());

Console.WriteLine(part1);

var cards = File.ReadLines("day4/input").Select(Card.Parse).ToArray();
var counts = Enumerable.Repeat(1, cards.Length).ToArray();

foreach (var (card, count) in cards.Zip(counts))
{
    for (var id = card.Id; id < card.Id + card.WinningNumbers().Count(); id++)
    {
        counts[id] += count;
    }
}

var part2 = counts.Sum();

Console.WriteLine(part2);
