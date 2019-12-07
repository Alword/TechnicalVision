using System;

namespace TechnicalVision.WindowsForms.Models
{
    public struct Dot
    {
        public Dot(int x, int y, int c = 0)
        {
            X = x;
            Y = y;
            C = c;
        }


        public int X { get; set; }
        public int Y { get; set; }
        public int C { get; set; }

        public static bool TryParse(string value, out Dot dot)
        {
            string[] values = value.Split(',');

            dot = new Dot();

            if (values.Length != 3) return false;

            bool result = int.TryParse(values[0], out int xResult);
            result &= int.TryParse(values[1], out int yResult);
            result &= int.TryParse(values[2], out int cResult);

            dot.X = xResult;
            dot.Y = yResult;
            dot.C = cResult;

            return result;
        }

        public double GetDistance(Dot dot)
        {
            return Math.Sqrt(Math.Pow(X - dot.X, 2) + Math.Pow(Y - dot.Y, 2));
        }

        public override string ToString()
        {
            return $"{X},{Y},{C}";
        }

        public static Dot operator +(Dot l, Dot r)
        {
            return new Dot(l.X + r.X, l.Y + r.Y);
        }

        public static Dot operator /(Dot l, int n)
        {
            return new Dot(l.X / n, l.Y / n);
        }

        public static Dot operator +(Dot l, int r)
        {
            return new Dot(l.X + r, l.Y + r);
        }
    }
}