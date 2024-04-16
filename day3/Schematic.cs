using System.Text.RegularExpressions;

namespace day3;

public class Schematic
{
    private readonly string[] _grid;
    public readonly BoundaryBox Boundary;

    public static Schematic Parse(string[] input)
    {
        var right = input[0].Length - 1;
        var bottom = input.Length - 1;

        return new Schematic(input, new BoundaryBox(Right: right, Bottom: bottom));
    }

    public static Schematic Parse(IEnumerable<string> input) => Parse(input.ToArray());

    private Schematic(string[] grid, BoundaryBox boundary) =>
        (_grid, Boundary) = (grid, boundary);

    public IEnumerable<Entry> Numbers()
    {
        var pattern = new Regex("\\d+");

        return _grid.SelectMany((row, index) =>
            pattern.Matches(row).Select(match => new Entry(
                Top: index,
                Left: match.Index,
                Contents: match.Value
            )));
    }

    public IEnumerable<Entry> Symbols() =>
        _grid.SelectMany((row, top) =>
            row.Select((value, index) => (value, index))
                .Where(entry => Day3.IsSymbol(entry.value))
                .Select(((char value, int left) entry) => new Entry(
                    Top: top,
                    Left: entry.left,
                    Contents: entry.value.ToString())));

    public char this[(int left, int top) point] =>
        _grid[point.top][point.left];
}
