using System.Collections.Generic;
using System.Threading.Tasks;
using TechnicalVision.WindowsForms.Abstractions;
using TechnicalVision.WindowsForms.Models;

namespace TechnicalVision.WindowsForms.Services.RegressionAnalysis
{
    public class ExhaustiveSearch : IRegressionAnalysis
    {
        public LineParams Search(IReadOnlyList<Dot> dots)
        {
            var e = 0.1;
            var minLine = new LineParams(0, 0, 0);
            double min = int.MaxValue;
            Parallel.For(-255, 255, c =>
            {
                for (double a = -1; a < 1; a += e)
                for (double b = -1; b < 1; b += e)
                {
                    var line = new LineParams(a, b, c);
                    double sum = 0;
                    foreach (Dot dot in dots)
                    {
                        sum += line.GetDistance(dot);

                        if (sum > min) break;
                    }

                    if (sum >= min) continue;

                    minLine = new LineParams(a, b, c);
                    min = sum;
                }
            });
            return minLine;
        }
    }
}