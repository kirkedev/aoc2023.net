using System.Text.RegularExpressions;

namespace day3;

public class Schematic
{
    public BoundaryBox Boundary { get; }
    private readonly string[] _grid;

    public Schematic(string[] input)
    {
        var right = input[0].Length - 1;
        var bottom = input.Length - 1;

        _grid = input;
        Boundary = new BoundaryBox(Right: right, Bottom: bottom);
    }

    public Schematic(IEnumerable<string> input) : this(input.ToArray())
    {
    }

    public IEnumerable<Entry> GetNumbers()
    {
        var pattern = new Regex("\\d+");

        return _grid.SelectMany((row, index) =>
            pattern.Matches(row).Select(match => new Entry(
                Top: index,
                Left: match.Index,
                Contents: match.Value
            )));
    }

    public IEnumerable<Entry> GetSymbols() =>
        _grid.SelectMany((row, top) =>
            row.Select((value, index) => (value, index))
                .Where(entry => Day3.IsSymbol(entry.value))
                .Select(((char value, int left) entry) =>
                    new Entry(
                        Top: top,
                        Left: entry.left,
                        Contents: entry.value.ToString())));

    public char Get(int left, int top) =>
        _grid[top][left];

    public char Get((int left, int top) position) =>
        Get(position.left, position.top);
}
