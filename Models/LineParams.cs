using System;

namespace TechnicalVision.WindowsForms.Models
{
    public struct LineParams
    {
        private double a;
        private double b;
        private double c;

        public LineParams(double A, double B, double C)
        {
            if (A < 0)
            {
                A = -A;
                B = -B;
            }

            a = A;
            b = B;
            c = C;
        }

        public LineParams(Dot dot, double a)
            : this(Math.Sin(a),
                Math.Cos(a),
                -dot.Y * Math.Cos(a) - dot.X * Math.Sin(a))
        {
        }

        public double A
        {
            get => a;
            set => SetValue(value, B, C);
        }

        public double B
        {
            get => b;
            set => SetValue(A, value, C);
        }

        public double C
        {
            get => c;
            set => SetValue(A, value, C);
        }

        private void SetValue(double A, double B, double C)
        {
            if (A < 0)
            {
                A = -A;
                B = -B;
                C = -C;
            }

            a = A;
            b = B;
            c = C;
        }

        public double GetX(double y)
        {
            return -(B * y + C) / A;
        }

        public double GetY(double x)
        {
            return -(A * x + C) / B;
        }

        public static LineParams operator +(LineParams f, LineParams s)
        {
            return new LineParams(f.A + s.A, f.B + s.B, f.C + s.C);
        }

        public static LineParams operator /(LineParams f, int s)
        {
            return new LineParams(f.A / s, f.B / s, f.C / s);
        }

        public static LineParams[] GetBisector(LineParams l, LineParams r)
        {
            return new[]
            {
                new LineParams(
                    l.A * Math.Sqrt(r.A * r.A + r.B * r.B) - r.A * Math.Sqrt(l.A * l.A + l.B * l.B),
                    l.B * Math.Sqrt(r.A * r.A + r.B * r.B) - r.B * Math.Sqrt(l.A * l.A + l.B * l.B),
                    l.C * Math.Sqrt(r.A * r.A + r.B * r.B) - r.C * Math.Sqrt(l.A * l.A + l.B * l.B)
                ),
                new LineParams(
                    l.A * Math.Sqrt(r.A * r.A + r.B * r.B) + r.A * Math.Sqrt(l.A * l.A + l.B * l.B),
                    l.B * Math.Sqrt(r.A * r.A + r.B * r.B) + r.B * Math.Sqrt(l.A * l.A + l.B * l.B),
                    l.C * Math.Sqrt(r.A * r.A + r.B * r.B) + r.C * Math.Sqrt(l.A * l.A + l.B * l.B)
                )
            };
        }

        public double GetDistance(Dot dot)
        {
            return Math.Abs(A * dot.X + B * dot.Y + C) /
                   Math.Sqrt(Math.Pow(A, 2) + Math.Pow(B, 2));
        }

        public (Dot, Dot) GetDots(Dot begin = default, Dot end = default)
        {
            if (end.X == 0) end = new Dot(255, 255);

            Dot dot1 = begin;
            Dot dot2 = end;

            if (Math.Abs(B) > 0.01)
            {
                dot1.Y = (int) GetY(dot1.X);
                dot2.Y = (int) GetY(dot2.X);
            }
            else if (Math.Abs(A) > 0.01)
            {
                dot1.X = (int) GetX(dot1.Y);
                dot2.X = (int) GetX(dot2.Y);
            }
            else
            {
                throw new NotSupportedException();
            }

            return (dot1, dot2);
        }

        public static int Clamp(int value, int min, int max)
        {
            return value < min ? min : value > max ? max : value;
        }
    }
}