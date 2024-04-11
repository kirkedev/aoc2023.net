namespace day2;

public readonly struct Round(int red, int green, int blue)
{
    public readonly int Red = red;
    public readonly int Green = green;
    public readonly int Blue = blue;
}

public readonly struct Game(int id, Round[] rounds)
{
    public readonly int Id = id;
    public readonly Round[] Rounds = rounds;
}
