﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalVision.WindowsForms.Models;

namespace TechnicalVision.WindowsForms.Abstractions
{
    public interface IRadialClusterAnalyzer
    {
        IList<Cluster> SearchClusters(double radius, IList<Dot> dots);
    }
}
