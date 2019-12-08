using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalVision.WindowsForms.Models
{
    public struct Cluster
    {
        public int Number { get; set; }
        public double Radius { get; set; }
        public Dot RadiusDot { get; set; }
        public List<Dot> Dots { get; set; }

        public bool InRange(Dot dot)
        {
            return RadiusDot.GetDistance(dot) < Radius;
        }

        public void AddDot(Dot dot)
        {
            var clusterDot = new Dot(dot.X, dot.Y, Number);
            Dots.Add(clusterDot);
        }

        public void RemoveDot(Dot dot)
        {
            Dots.Remove(dot);
        }
    }
}
