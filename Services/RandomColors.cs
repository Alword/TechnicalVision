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
        private static readonly Dictionary<int, Color> ColorDictionary;
        private static readonly Dictionary<int, Brush> BrushDictionary;
        static RandomColors()
        {
            ColorDictionary = new Dictionary<int, Color>();
            BrushDictionary = new Dictionary<int, Brush>(256);
            Initialize();
        }

        public static Brush GetBrush(int color)
        {
            return IsValid(color) ? BrushDictionary[color] : Brushes.Black;
        }

        public static Color GetColor(int color)
        {
            return IsValid(color) ? ColorDictionary[color] : Color.Black;
        }

        private static void Initialize()
        {
            var random = new Random(159753);
            foreach (int num in Enumerable.Range(0, 256))
            {
                ColorDictionary.Add(num,Color.FromArgb(random.Next(0, 256), random.Next(0, 256), random.Next(0, 256)));
                BrushDictionary.Add(num, new SolidBrush(ColorDictionary[num]));
            }
        }

        private static bool IsValid(int num)
        {
            return num >= 0 && num <= 256;
        }
    }
}
