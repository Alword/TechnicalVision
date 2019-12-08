using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using TechnicalVision.WindowsForms.Models;

namespace TechnicalVision.WindowsForms.Services.ClusterAnalisis
{
    public static class ClusterOptimizer
    {
        public static List<Cluster> RemoveSharedClusters(List<Cluster> clusters)
        {
            int count = clusters.Count;
            int totalDots = clusters.SelectMany(d => d.Dots).Count();
            while (HasSharedClusters(clusters, out Dictionary<Dot, List<Cluster>> sharedDotsDictionary, out List<Cluster> sharedClusters))
            {
                var clusterToOptimize = sharedClusters.OrderBy(c => c.Dots.Count).First();

                foreach (var dot in clusterToOptimize.Dots)
                {
                    var clustersToMove = sharedDotsDictionary[dot]
                        .Where(c => !c.Equals(clusterToOptimize))
                        .OrderByDescending(d => d.Dots.Count)
                        .ToList();

                    var standaloneCluster = clustersToMove.Except(sharedClusters).ToList();
                    if (standaloneCluster.Any())
                    {
                        clustersToMove = standaloneCluster;
                    }


                    if (clustersToMove.Any())
                    { 
                        var clusterToMove = clustersToMove.First();
                        clusterToMove.AddDot(dot);
                    }

                }

                clusters.Remove(clusterToOptimize);
            }
            Debug.WriteLine($"Deleted clusters: {count - clusters.Count}");
            Debug.WriteLine($"Dots deleted: {totalDots - clusters.SelectMany(d => d.Dots).Count()}");

            return clusters;
        }

        public static bool HasSharedClusters(List<Cluster> clusters,
            out Dictionary<Dot, List<Cluster>> sharedDotsDictionary,
            out List<Cluster> sharedClusters)
        {
            sharedDotsDictionary = new Dictionary<Dot, List<Cluster>>();
            sharedClusters = new List<Cluster>(clusters.Count / 2);

            foreach (var cluster in clusters)
            {
                var allInRange = true;
                foreach (var dot in cluster.Dots)
                {
                    sharedDotsDictionary.Add(dot, clusters.Where(c => !c.Equals(cluster) && c.InRange(dot)).ToList());

                    allInRange = sharedDotsDictionary[dot].Any();

                    if (!allInRange)
                        break;
                }

                if (allInRange)
                {
                    sharedClusters.Add(cluster);
                }
            }

            return sharedClusters.Any();
        }
    }
}
