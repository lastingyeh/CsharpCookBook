using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace CookBook.Ch1
{
    public class Square : IComparable<Square>
    {
        public int Height { get; set; }
        public int Width { get; set; }

        public Square() { }

        public Square(int height, int width)
        {
            this.Height = height;
            this.Width = width;
        }

        public int CompareTo(object obj)
        {
            Square square = obj as Square;

            if (square != null)
            {
                return CompareTo(square);
            }

            throw new ArgumentException("Both objects being compared must be of type square.");
        }

        public override string ToString() => ($"Height: {this.Height}    Width: {this.Width}");

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            Square square = obj as Square;

            if (square != null)
                return this.Height == square.Height;

            return false;
        }

        public override int GetHashCode()
        {
            return this.Height.GetHashCode() | this.Width.GetHashCode();
        }

        // https://docs.microsoft.com/zh-tw/dotnet/csharp/programming-guide/statements-expressions-operators/how-to-define-value-equality-for-a-type
        public static bool operator ==(Square x, Square y) => x.Equals(y);
        public static bool operator !=(Square x, Square y) => !(x == y);
        public static bool operator <(Square x, Square y) => (x.CompareTo(y) < 0);
        public static bool operator >(Square x, Square y) => (x.CompareTo(y) > 0);

        public int CompareTo(Square other)
        {
            long area1 = this.Height * this.Width;
            long area2 = other.Height * other.Width;

            if (area1 == area2)
                return 0;
            else if (area1 > area2)
                return 1;
            else if (area1 < area2)
                return -1;
            else
                return -1;
        }
    }
}
