using System;
using System.Collections.Generic;
using TechnicalVision.WindowsForms.Abstractions;
using TechnicalVision.WindowsForms.Models;

namespace TechnicalVision.WindowsForms.Services.RegressionAnalysis
{
    public class ExoustiveSearch : IRegressionAnalysis
    {
        public (int, double) Search(IReadOnlyCollection<Dot> dots)
        {
            int minA = 0;
            int minB = 0;
            double min = int.MaxValue;
            for (int a = 0; a < 256; a++)
            {
                for (int b = 0; b < 256; b++)
                {
                    double sum = 0;
                    foreach (var dot in dots)
                    {
                        sum += Math.Pow(dot.Y - a - b * dot.X, 2);
                    }

                    if (sum < min)
                    {
                        minA = a;
                        minB = b;
                        min = sum;
                    }
                }
            }

            return (minA, minB);
        }
    }
}
