namespace TechnicalVision.WindowsForms.Models
{
    public struct LineParams
    {
        public LineParams(double a, double b, double c)
        {
            A = a;
            B = b;
            C = c;
        }

        public double A { get; set; }
        public double B { get; set; }
        public double C { get; set; }

        public static LineParams operator +(LineParams f, LineParams s) => new LineParams(f.A + s.A, f.B + s.B, f.C + s.C);

        public static LineParams operator /(LineParams f, int s) => new LineParams(f.A / s, f.B / s, f.C / s);
    }
}
