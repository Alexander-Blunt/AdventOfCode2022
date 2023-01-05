using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RopeBridge
{
    public struct Point2D : IEquatable<Point2D>
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point2D(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static Point2D Add(Point2D left, Point2D right)
        {
            int newX = left.X + right.X;
            int newY = left.Y + right.Y;

            return new Point2D(newX, newY);
        }

        public Point2D Add(Point2D other)
        {
            return Add(this, other);
        }

        public Point2D Add(int x, int y)
        {
            return Add(this, new Point2D(x, y));
        }

        public static Point2D Subtract(Point2D left, Point2D right)
        {
            int newX = left.X - right.X;
            int newY = left.Y - right.Y;
            return new Point2D(newX, newY);
        }

        public Point2D Subtract(Point2D other)
        {
            return Subtract(this, other);
        }

        public Point2D Subtract(int x, int y)
        {
            return Subtract(this, new Point2D(x, y));
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
}
