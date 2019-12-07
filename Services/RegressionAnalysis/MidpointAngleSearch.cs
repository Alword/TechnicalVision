using System;
using System.Collections.Generic;
using System.Linq;
using TechnicalVision.WindowsForms.Abstractions;
using TechnicalVision.WindowsForms.Models;

namespace TechnicalVision.WindowsForms.Services.RegressionAnalysis
{
    public class MidpointAngleSearch : IRegressionAnalysis
    {
        public LineParams Search(IReadOnlyList<Dot> dots)
        {
            double minSum = int.MaxValue;
            int middleX = dots.Sum(d => d.X) / dots.Count;
            int middleY = dots.Sum(d => d.Y) / dots.Count;
            var middleDot = new Dot(middleX, middleY);
            LineParams besLineParams = default;

            for (double a = 0; a <= Math.PI; a += Math.PI / 1000)
            {
                var line = new LineParams(middleDot, a);
                double sum = dots.Sum(dot => line.GetDistance(dot)) / dots.Count;

                if (minSum > sum)
                {
                    minSum = sum;
                    besLineParams = line;
                }
            }

            return besLineParams;
        }
    }
}