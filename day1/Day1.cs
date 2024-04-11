using DotNext;

namespace day1;

public static class Day1
{
    private static readonly Dictionary<string, int> Numbers = new()
    {
        { "one", 1 },
        { "two", 2 },
        { "three", 3 },
        { "four", 4 },
        { "five", 5 },
        { "six", 6 },
        { "seven", 7 },
        { "eight", 8 },
        { "nine", 9 }
    };

    public static (int, int) GetNumbers(string line)
    {
        var values = line
            .Select(input => int.TryParse(input.ToString(), out var value) ? value : Optional<int>.None)
            .Where(value => value.HasValue)
            .Select(value => value.Value)
            .ToList();

        return (values.First(), values.Last());
    }

    public static (int, int) GetTextNumbers(string line)
    {
        var values = line
            .Select((input, index) =>
            {
                var text = line.Substring(index);
                var key = Numbers.Keys.FirstOrDefault(key => text.StartsWith(key));

                return key == null
                    ? int.TryParse(input.ToString(), out var value) ? value : Optional<int>.None
                    : Numbers[key];
            })
            .Where(value => value.HasValue)
            .Select(value => value.Value)
            .ToList();

        return (values.First(), values.Last());
    }

    public static int Calibrate((int first, int last) input)
    {
        return input.first * 10 + input.last;
    }
}
