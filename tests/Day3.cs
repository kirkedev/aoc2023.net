using day3;

namespace tests;

public static class Day3Tests
{
    [Test]
    public static void TestGetNumbers()
    {
        const string input = """
                             467..114..
                             ...*......
                             ..35..633.
                             ......#...
                             617*......
                             .....+.58.
                             ..592.....
                             ......755.
                             ...$.*....
                             .664.598..
                             """;

        var schematic = Schematic.Parse(input.Split(Environment.NewLine));
        Assert.That(schematic.Boundary.Left, Is.EqualTo(0));
        Assert.That(schematic.Boundary.Top, Is.EqualTo(0));
        Assert.That(schematic.Boundary.Right, Is.EqualTo(9));
        Assert.That(schematic.Boundary.Bottom, Is.EqualTo(9));

        Assert.That(schematic.Numbers().ToArray(), Is.EquivalentTo(new Entry[]
        {
            new(Top: 0, Left: 0, Contents: "467"),
            new(Top: 0, Left: 5, Contents: "114"),
            new(Top: 2, Left: 2, Contents: "35"),
            new(Top: 2, Left: 6, Contents: "633"),
            new(Top: 4, Left: 0, Contents: "617"),
            new(Top: 5, Left: 7, Contents: "58"),
            new(Top: 6, Left: 2, Contents: "592"),
            new(Top: 7, Left: 6, Contents: "755"),
            new(Top: 9, Left: 1, Contents: "664"),
            new(Top: 9, Left: 5, Contents: "598")
        }));
    }

    [Test]
    public static void TestGetSymbols()
    {
        const string input = """
                             467..114..
                             ...*......
                             ..35..633.
                             ......#...
                             617*......
                             .....+.58.
                             ..592.....
                             ......755.
                             ...$.*....
                             .664.598..
                             """;

        var schematic = Schematic.Parse(input.Split(Environment.NewLine));

        Assert.That(schematic.Symbols().ToArray(), Is.EquivalentTo(new Entry[]
        {
            new(Top: 1, Left: 3, Contents: "*"),
            new(Top: 3, Left: 6, Contents: "#"),
            new(Top: 4, Left: 3, Contents: "*"),
            new(Top: 5, Left: 5, Contents: "+"),
            new(Top: 8, Left: 3, Contents: "$"),
            new(Top: 8, Left: 5, Contents: "*"),
        }));
    }

    [Test]
    public static void TestIsSymbol()
    {
        Assert.That(Day3.IsSymbol('*'));
        Assert.That(Day3.IsSymbol('#'));
        Assert.That(Day3.IsSymbol('.'), Is.False);
        Assert.That(Day3.IsSymbol('1'), Is.False);
    }

    [Test]
    public static void TestGetBorderPoints()
    {
        var box = new BoundaryBox(Bottom: 9, Right: 9);

        Assert.That(new Entry(Top: 2, Left: 6, Contents: "633").GetBorderPoints(box).ToArray(),
            Is.EquivalentTo(new[]
            {
                (5, 1), (6, 1), (7, 1), (8, 1), (9, 1),
                (5, 2), (9, 2),
                (5, 3), (6, 3), (7, 3), (8, 3), (9, 3)
            }));

        Assert.That(new Entry(Top: 0, Left: 0, Contents: "467").GetBorderPoints(box).ToArray(),
            Is.EquivalentTo(new[]
            {
                (3, 0),
                (0, 1), (1, 1), (2, 1), (3, 1)
            }));

        Assert.That(new Entry(Top: 9, Left: 7, Contents: "598").GetBorderPoints(box).ToArray(),
            Is.EquivalentTo(new[]
            {
                (6, 8), (7, 8), (8, 8), (9, 8),
                (6, 9)
            }));
    }
}
