namespace day2;

public readonly record struct Round(int Red, int Green, int Blue);

public readonly record struct Game(int Id, Round[] Rounds);

public static class Day2
{
    public static Round ParseRound(string round)
    {
        var cubes = round.Split(", ")
            .Select(cubes =>
            {
                var cube = cubes.Split(" ");
                return (cube[1], int.Parse(cube[0]));
            })
            .ToDictionary();

        return new Round(
            Red: cubes.GetValueOrDefault("red"),
            Green: cubes.GetValueOrDefault("green"),
            Blue: cubes.GetValueOrDefault("blue"));
    }

    public static Func<Game, bool> IsValid(Round totals)
    {
        return game => game.Rounds.All(round =>
            round.Red <= totals.Red && round.Green <= totals.Green && round.Blue <= totals.Blue);
    }

    public static Game ParseGame(string line)
    {
        var game = line.Split(": ");
        var id = game[0].Split(' ')[1];
        var rounds = game[1].Split("; ").Select(ParseRound).ToArray();

        return new Game(int.Parse(id), rounds);
    }

    public static Round Minimums(this Game game)
    {
        return new Round(
            Red: game.Rounds.Max(round => round.Red),
            Green: game.Rounds.Max(round => round.Green),
            Blue: game.Rounds.Max(round => round.Blue));
    }

    public static int Power(this Round round)
    {
        return round.Red * round.Green * round.Blue;
    }
}
