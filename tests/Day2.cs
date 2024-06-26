using day2;

namespace tests;

public static class Day2Tests
{
    [Test]
    public static void TestParseRound()
    {
        Assert.That(Round.Parse("1 blue, 2 green"), Is.EqualTo(new Round(Red: 0, Green: 2, Blue: 1)));
        Assert.That(Round.Parse("3 green, 4 blue, 1 red"), Is.EqualTo(new Round(Red: 1, Green: 3, Blue: 4)));
        Assert.That(Round.Parse("1 green, 1 blue"), Is.EqualTo(new Round(Red: 0, Green: 1, Blue: 1)));
    }

    [Test]
    public static void TestParse()
    {
        var game = Game.Parse("Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green");
        Assert.That(game.Id, Is.EqualTo(1));

        Assert.That(game.Rounds, Is.EquivalentTo(new Round[]
        {
            new(Red: 4, Green: 0, Blue: 3),
            new(Red: 1, Green: 2, Blue: 6),
            new(Red: 0, Green: 2, Blue: 0)
        }));
    }

    [Test]
    public static void TestValidate()
    {
        const string input = """
                             Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green
                             Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue
                             Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red
                             Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red
                             Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green
                             """;

        var games = input.Split(Environment.NewLine)
            .Select(Game.Parse)
            .Where(Day2.IsValid(new Round(Red: 12, Green: 13, Blue: 14)))
            .ToList();

        Assert.That(games, Has.Count.EqualTo(3));
        Assert.That(games.Sum(game => game.Id), Is.EqualTo(8));
    }

    [Test]
    public static void TestMinimums()
    {
        Assert.That(Game.Parse("Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green").Minimums(),
            Is.EqualTo(new Round(Red: 4, Green: 2, Blue: 6)));

        Assert.That(Game.Parse("Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue").Minimums(),
            Is.EqualTo(new Round(Red: 1, Green: 3, Blue: 4)));

        Assert.That(
            Game.Parse("Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red").Minimums(),
            Is.EqualTo(new Round(Red: 20, Green: 13, Blue: 6)));

        Assert.That(
            Game.Parse("Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red").Minimums(),
            Is.EqualTo(new Round(Red: 14, Green: 3, Blue: 15)));

        Assert.That(Game.Parse("Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green").Minimums(),
            Is.EqualTo(new Round(Red: 6, Green: 3, Blue: 2)));
    }

    [Test]
    public static void TestPowers()
    {
        Assert.That(new Round(Red: 4, Green: 2, Blue: 6).Power(), Is.EqualTo(48));
        Assert.That(new Round(Red: 1, Green: 3, Blue: 4).Power(), Is.EqualTo(12));
        Assert.That(new Round(Red: 20, Green: 13, Blue: 6).Power(), Is.EqualTo(1560));
        Assert.That(new Round(Red: 14, Green: 3, Blue: 15).Power(), Is.EqualTo(630));
        Assert.That(new Round(Red: 6, Green: 3, Blue: 2).Power(), Is.EqualTo(36));
    }
}
