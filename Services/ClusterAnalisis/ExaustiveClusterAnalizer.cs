using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalVision.WindowsForms.Abstractions;
using TechnicalVision.WindowsForms.Models;

namespace TechnicalVision.WindowsForms.Services.ClusterAnalyzers
{
    public class ExhaustiveClusterAnalyzer : IRadialClusterAnalyzer
    {
        public List<Cluster> SearchClusters(double radius, List<Dot> dots)
        {
            int i = 0;
            double range = int.MaxValue;//radius * radius;
            Dot[] copy = new Dot[dots.Count];
            dots.CopyTo(copy);
            var dotsToCluster = copy.ToList();
            List<Cluster> clusters = new List<Cluster>(dots.Count);

            Dot middlePoint = default;
            while (dotsToCluster.Count > 0)
            {
                middlePoint = dotsToCluster.OrderBy(d => d.GetDistance(middlePoint)).First();
                var dotsInRange = dotsToCluster
                    .Where(d => d.GetDistance(middlePoint) <= range)
                    .OrderBy(d => d.GetDistance(middlePoint))
                    .ToList();

                List<Dot> dotsInCluster = new List<Dot>(dotsInRange.Count());
                if (dotsInRange.Any())
                {
                    foreach (var inRangeDot in dotsInRange)
                    {
                        if (dotsInCluster.Count > 0)
                        {
                            middlePoint = default;
                            foreach (var dot in dotsInCluster)
                            {
                                middlePoint += dot;
                            }

                            middlePoint /= dotsInCluster.Count;
                        }

                        Dot displaced = (middlePoint + inRangeDot) / 2;
                        dotsInCluster.Add(inRangeDot);
                        if (dotsInCluster.Any(d => d.GetDistance(displaced) >= radius))
                        {
                            dotsInCluster.Remove(inRangeDot);
                            break;
                        }
                        else
                        {
                            middlePoint = displaced;
                        }
                    }
                }

                i = i + 1 % 255;
                clusters.Add(new Cluster()
                {
                    Dots = ColoredDots(dotsInCluster, i),
                    Number = i,
                    Radius = radius,
                    RadiusDot = middlePoint
                });

                dotsToCluster = dotsToCluster.Except(dotsInCluster).ToList();
            }

            return clusters;
        }

        public List<Dot> ColoredDots(List<Dot> dots, int i)
        {
            List<Dot> coloredDot = new List<Dot>(dots.Count);
            foreach (var dot in dots)
            {
                coloredDot.Add(new Dot(dot.X, dot.Y, i));
            }

            return coloredDot;
        }
    }
}
