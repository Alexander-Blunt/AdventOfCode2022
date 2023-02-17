namespace HillClimbingAlgorithm;

// Represents zero indexed coordinates on a grid as in the following diagram
//   X->
// Y Sabqponm
// | abcryxxl
// v accszExk
//   acctuvwj
//   abdefghi
public struct Point2D : IEquatable<Point2D>
{
    public int X { get; }
    public int Y { get; }

    public Point2D(int x, int y)
    {
        this.X = x;
        this.Y = y;
    }

    public override string ToString()
    {
        return $"[{X}, {Y}]";
    }

    public override bool Equals(object? obj)
    {
        return obj is Point2D d && Equals(d);
    }

    public bool Equals(Point2D other)
    {
        return X == other.X &&
               Y == other.Y;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y);
    }

    public static bool operator ==(Point2D left, Point2D right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(Point2D left, Point2D right)
    {
        return !(left == right);
    }
}