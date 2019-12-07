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
        public IEnumerator<Cluster> SearchClusters(double radius, List<Dot> dots)
        {
            int i = 0;
            double range = 2 * radius;
            List<Dot> dotsToCluster = dots;
            List<Cluster> cliList = new List<Cluster>(dots.Count);

            while (dotsToCluster.Count > 0)
            {
                Dot dot = dotsToCluster.First();
                dotsToCluster.Remove(dot);
                var dotsInRange = dots
                    .Where(d => d.GetDistance(dot) <= range)
                    .OrderBy(d => d.GetDistance(dot))
                    .ToList();

                List<Dot> dotsInCluster = new List<Dot>(dotsInRange.Count()) { dot };
                Dot middlePoint = dot;
                if (dotsInRange.Any())
                {
                    foreach (var inRangeDot in dotsInRange)
                    {
                        var displaced = (middlePoint + inRangeDot) / 2;
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

                cliList.Add(new Cluster()
                {
                    Dots = dotsInCluster,
                    Number = i++,
                    Radius = radius,
                    RadiusDot = middlePoint
                });
                yield return cliList.Last();
                dotsToCluster = dotsToCluster.Except(dotsInCluster).ToList();
            }
            yield break;
        }
    }
}
