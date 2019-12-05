using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace TechnicalVision.WindowsForms.Models
{
    public struct Dot
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int C { get; set; }

        public static bool TryParse(string value, out Dot dot)
        {
            string[] values = value.Split(' ');

            dot = new Dot();

            if (values.Length != 3)
            {
                return false;
            }

            bool result = int.TryParse(values[0], out int xResult);
            result &= int.TryParse(values[0], out int yResult);
            result &= int.TryParse(values[0], out int cResult);

            dot.X = xResult;
            dot.Y = yResult;
            dot.C = cResult;

            return result;
        }

    }
}
