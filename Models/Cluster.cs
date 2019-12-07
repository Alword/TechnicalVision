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
        public int Radius { get; set; }
        public Dot RadiusDot { get; set; }
        public List<Dot> Dots { get; set; }
    }
}
