using System.Collections.Generic;
using TechnicalVision.WindowsForms.Abstractions;
using TechnicalVision.WindowsForms.Models;

namespace TechnicalVision.WindowsForms.Services.RegressionAnalysis
{
    public class AverageAngleSearch : IRegressionAnalysis
    {
        public (int, double) Search(IReadOnlyList<Dot> dots)
        {
            double SummA = 0;
            double SummB = 0;
            int countPairs = 0;
            for(int i = 0; i < dots.Count; i++)
            {
                Dot dotLeft = dots[i];
                for(int j = i + 1; j < dots.Count; j++)
                {
                    Dot dotRight = dots[j];
                    double a = -(dotLeft.Y - dotRight.Y) / (double)(dotRight.X - dotLeft.X);
                    double b = -(dotLeft.X * dotRight.Y - dotRight.X * dotLeft.Y) / (double)(dotRight.X - dotLeft.X);
                    SummA += a;
                    SummB += b;
                    countPairs++;
                }
            }

            return ((int)(SummB / countPairs), SummA / countPairs);
        }
    }
}
