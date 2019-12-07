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
            double range = 2 * radius;
            Dot[] copy = new Dot[dots.Count];
            dots.CopyTo(copy);
            var dotsToCluster = copy.ToList();
            List<Cluster> clusters = new List<Cluster>(dots.Count);

            while (dotsToCluster.Count > 0)
            {
                Dot middlePoint = dotsToCluster.First();
                var dotsInRange = dotsToCluster
                    .Where(d => d.GetDistance(middlePoint) <= range)
                    .OrderBy(d => d.GetDistance(middlePoint))
                    .ToList();

                List<Dot> dotsInCluster = new List<Dot>(dotsInRange.Count());
                if (dotsInRange.Any())
                {
                    foreach (var inRangeDot in dotsInRange)
                    {
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
                clusters.Add(new Cluster()
                {
                    Dots = dotsInCluster,
                    Number = i++ % 255,
                    Radius = radius,
                    RadiusDot = middlePoint
                });

                dotsToCluster = dotsToCluster.Except(dotsInCluster).ToList();
            }

            return clusters;
        }
    }
}
