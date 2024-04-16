namespace day4;

public readonly record struct Card(int Id, int[] Winners, int[] Numbers)
{
    public static Card Parse(string input)
    {
        var card = input.Split(": ");
        var id = int.Parse(card[0].Substring(5).TrimStart());

        var numbers = card[1].Split(" | ")
            .Select(numbers => numbers
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray())
            .ToArray();

        return new Card(id, numbers[0], numbers[1]);
    }

    public override int GetHashCode() => Id;

    public IEnumerable<int> WinningNumbers() => Winners.Intersect(Numbers);
}

public static class Day4
{
    public static int Score(this IEnumerable<int> numbers) =>
        (int)Math.Pow(2, numbers.Count() - 1);
}
