namespace day4;

public readonly record struct Card(int[] Winners, int[] Numbers)
{
    public static Card Parse(string input)
    {
        var card = input.Split(": ");

        var numbers = card[1].Split(" | ")
            .Select(numbers => numbers
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray())
            .ToArray();

        return new Card(numbers[0], numbers[1]);
    }

    public IEnumerable<int> WinningNumbers() => Winners.Intersect(Numbers);
}

public static class Day4
{
    public static int Score(this IEnumerable<int> numbers) =>
        (int)Math.Pow(2, numbers.Count() - 1);
}
