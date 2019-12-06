using System.Collections.Generic;
using TechnicalVision.WindowsForms.Abstractions;
using TechnicalVision.WindowsForms.Models;

namespace TechnicalVision.WindowsForms.Services.RegressionAnalysis
{
    public class AverageAngleSearch : IRegressionAnalysis
    {
        public LineParams Search(IReadOnlyList<Dot> dots)
        {
            LineParams Sum = default;
            int countPairs = 0;
            for(int i = 0; i < dots.Count; i++)
            {
                Dot left = dots[i];
                for(int j = i + 1; j < dots.Count; j++)
                {
                    Dot right = dots[j];
                    Sum += new LineParams(
                        left.Y - right.Y,
                        right.X - left.X,
                        left.X * right.Y - right.X * left.Y);
                    countPairs++;
                }
            }

            return Sum / countPairs;
        }
    }
}
