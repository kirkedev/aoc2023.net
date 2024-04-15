namespace day3;

using Point = (int, int);

public readonly record struct Entry(int Left, int Top, string Contents)
{
    public Point Location => (Left, Top);
}

public readonly record struct BoundaryBox(int Left = 0, int Top = 0, int Right = 0, int Bottom = 0);

public static class Day3
{
    public static bool IsSymbol(char entry) =>
        entry != '.' && !char.IsNumber(entry);

    public static bool IsAdjacentTo(this Point point, Point other) =>
        Math.Abs(point.Item1 - other.Item1) <= 1 && Math.Abs(point.Item2 - other.Item2) <= 1;

    public static BoundaryBox GetBorders(this Entry entry) => new(
        Left: entry.Left - 1,
        Top: entry.Top - 1,
        Right: entry.Left + entry.Contents.Length,
        Bottom: entry.Top + 1);

    public static IEnumerable<Point> GetBorderPoints(this Entry entry, BoundaryBox boundary) =>
        entry.GetBorders().Clip(boundary);

    public static IEnumerable<Point> Clip(this BoundaryBox boundary, BoundaryBox other) =>
        boundary.GetPoints().Where(((int Left, int Top) point) =>
            point.Left >= other.Left &&
            point.Left <= other.Right &&
            point.Top >= other.Top &&
            point.Top <= other.Bottom);

    public static IEnumerable<Point> GetPoints(this BoundaryBox boundary)
    {
        for (var left = boundary.Left; left <= boundary.Right; left++)
        {
            yield return (left, boundary.Top);
        }

        for (var top = boundary.Top + 1; top < boundary.Bottom; top++)
        {
            yield return (boundary.Left, top);
            yield return (boundary.Right, top);
        }

        for (var left = boundary.Left; left <= boundary.Right; left++)
        {
            yield return (left, boundary.Bottom);
        }
    }
}
