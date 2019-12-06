using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalVision.WindowsForms.Services
{
    public static class RandomColors
    {
        private static readonly Dictionary<int, Brush> BrushDictionary;
        static RandomColors()
        {
            BrushDictionary = new Dictionary<int, Brush>(256);
            Initialize();
        }

        public static Brush GetColor(int color)
        {
            return IsValid(color) ? BrushDictionary[color] : Brushes.Black;
        }

        private static void Initialize()
        {
            var random = new Random(159753);
            foreach (int num in Enumerable.Range(0, 256))
            {
                BrushDictionary.Add(num, new SolidBrush(Color.FromArgb(random.Next(0, 256), random.Next(0, 256), random.Next(0, 256))));
            }
        }

        private static bool IsValid(int num)
        {
            return num >= 0 && num <= 256;
        }
    }
}
