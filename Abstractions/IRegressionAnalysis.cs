using System.Collections.Generic;
using TechnicalVision.WindowsForms.Models;

namespace TechnicalVision.WindowsForms.Abstractions
{
    public interface IRegressionAnalysis
    {
        LineParams Search(IReadOnlyList<Dot> dots);
    }
}