using day1;

namespace tests;

public static class Day1Tests
{
    [Test]
    public static void TestGetNumbers()
    {
        Assert.That(Day1.GetNumbers("1abc2"), Is.EqualTo(12));
        Assert.That(Day1.GetNumbers("pqr3stu8vwx"), Is.EqualTo(38));
        Assert.That(Day1.GetNumbers("a1b2c3d4e5f"), Is.EqualTo(15));
        Assert.That(Day1.GetNumbers("treb7uchet"), Is.EqualTo(77));
    }

    [Test]
    public static void TestGetTextNumbers()
    {
        Assert.That(Day1.GetTextNumbers("two1nine"), Is.EqualTo(29));
        Assert.That(Day1.GetTextNumbers("eightwothree"), Is.EqualTo(83));
        Assert.That(Day1.GetTextNumbers("abcone2threexyz"), Is.EqualTo(13));
        Assert.That(Day1.GetTextNumbers("xtwone3four"), Is.EqualTo(24));
        Assert.That(Day1.GetTextNumbers("4nineeightseven2"), Is.EqualTo(42));
        Assert.That(Day1.GetTextNumbers("zoneight234"), Is.EqualTo(14));
        Assert.That(Day1.GetTextNumbers("7pqrstsixteen"), Is.EqualTo(76));
    }

    [Test]
    public static void TestCalibrate()
    {
        Assert.That(Day1.Calibrate(1, 2), Is.EqualTo(12));
        Assert.That(Day1.Calibrate(3, 8), Is.EqualTo(38));
        Assert.That(Day1.Calibrate(1, 5), Is.EqualTo(15));
        Assert.That(Day1.Calibrate(7, 7), Is.EqualTo(77));
    }
}
