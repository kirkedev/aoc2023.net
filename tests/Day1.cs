using day1;

namespace tests;

public static class Day1Tests
{
    [Test]
    public static void TestGetNumbers()
    {
        Assert.That(Day1.GetNumbers("1abc2"), Is.EqualTo((1, 2)));
        Assert.That(Day1.GetNumbers("pqr3stu8vwx"), Is.EqualTo((3, 8)));
        Assert.That(Day1.GetNumbers("a1b2c3d4e5f"), Is.EqualTo((1, 5)));
        Assert.That(Day1.GetNumbers("treb7uchet"), Is.EqualTo((7, 7)));
    }

    [Test]
    public static void TestGetTextNumbers()
    {
        Assert.That(Day1.GetTextNumbers("two1nine"), Is.EqualTo((2, 9)));
        Assert.That(Day1.GetTextNumbers("eightwothree"), Is.EqualTo((8, 3)));
        Assert.That(Day1.GetTextNumbers("abcone2threexyz"), Is.EqualTo((1, 3)));
        Assert.That(Day1.GetTextNumbers("xtwone3four"), Is.EqualTo((2, 4)));
        Assert.That(Day1.GetTextNumbers("4nineeightseven2"), Is.EqualTo((4, 2)));
        Assert.That(Day1.GetTextNumbers("zoneight234"), Is.EqualTo((1, 4)));
        Assert.That(Day1.GetTextNumbers("7pqrstsixteen"), Is.EqualTo((7, 6)));
    }

    [Test]
    public static void TestCalibrate()
    {
        Assert.That(Day1.Calibrate((1, 2)), Is.EqualTo(12));
        Assert.That(Day1.Calibrate((3, 8)), Is.EqualTo(38));
        Assert.That(Day1.Calibrate((1, 5)), Is.EqualTo(15));
        Assert.That(Day1.Calibrate((7, 7)), Is.EqualTo(77));
    }
}
