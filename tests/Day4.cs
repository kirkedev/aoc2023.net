using day4;

namespace tests;

public static class Day4Tests
{
    [Test]
    public static void TestParse()
    {
        var (winners, numbers) = Card.Parse("Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53");

        Assert.That(winners, Is.EquivalentTo(new[] { 41, 48, 83, 86, 17 }));
        Assert.That(numbers, Is.EquivalentTo(new[] { 83, 86, 6, 31, 17, 9, 48, 53 }));
    }

    [Test]
    public static void TestGetWinningNumbers()
    {
        Assert.That(Card.Parse("Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53").WinningNumbers,
            Is.EquivalentTo(new[] { 48, 83, 86, 17 }));

        Assert.That(Card.Parse("Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19").WinningNumbers,
            Is.EquivalentTo(new[] { 32, 61 }));

        Assert.That(Card.Parse("Card 3: 1 21 53 59 44 | 69 82 63 72 16 21 14 1").WinningNumbers,
            Is.EquivalentTo(new[] { 1, 21 }));

        Assert.That(Card.Parse("Card 4: 41 92 73 84 69 | 59 84 76 51 58 5 54 83").WinningNumbers,
            Is.EquivalentTo(new[] { 84 }));

        Assert.That(Card.Parse("Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36").WinningNumbers,
            Is.Empty);

        Assert.That(Card.Parse("Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11").WinningNumbers,
            Is.Empty);
    }

    [Test]
    public static void TestScore()
    {
        Assert.That(Array.Empty<int>().Score(), Is.EqualTo(0));
        Assert.That(new[] { 1 }.Score(), Is.EqualTo(1));
        Assert.That(new[] { 1, 2 }.Score(), Is.EqualTo(2));
        Assert.That(new[] { 1, 2, 3 }.Score(), Is.EqualTo(4));
        Assert.That(new[] { 48, 83, 86, 17 }.Score(), Is.EqualTo(8));
    }
}
