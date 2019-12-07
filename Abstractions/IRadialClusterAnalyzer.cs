using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalVision.WindowsForms.Models;

namespace TechnicalVision.WindowsForms.Abstractions
{
    interface IRadialClusterAnalyzer
    {
        List<Cluster> SearchClusters(double radius, List<Dot> dots);
    }
}
