using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalVision.WindowsForms.Models;

namespace TechnicalVision.WindowsForms.Services
{
    public class RepeatDots
    {
        public static IList<Dot> Repeat(int times, IList<Dot> dots)
        {
            int row = 4;
            if (times < 2 && dots.Count.Equals(0)) return dots;

            IList<Dot> additionalDots = new List<Dot>(dots.Count * times);

            var maxYDot = dots.OrderByDescending(d => d.Y).First();
            int padding = maxYDot.Y + row;
            foreach (int i in Enumerable.Range(1, times - 1))
            {
                foreach (var dot in dots)
                {
                    additionalDots.Add(new Dot(dot.X, dot.Y + padding * i, dot.C));
                }
            }


            return dots.Union(additionalDots).ToList();
        }
    }
}
