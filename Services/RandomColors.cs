using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;

namespace TechnicalVision.WindowsForms.Services
{
    public static class RandomColors
    {
        private static readonly int Colors = 25;
        private static readonly int Start = 10;
        private static readonly int End = 240;

        private static readonly Random Random = new Random(159753);
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
            color = color % ColorDictionary.Count;
            return IsValid(color) ? BrushDictionary[color] : Brushes.Black;
        }

        public static Color GetColor(int color)
        {
            color = color % BrushDictionary.Count;
            return IsValid(color) ? ColorDictionary[color] : Color.Black;
        }

        private static void Initialize()
        {
            foreach (int num in Enumerable.Range(0, Colors))
            {
                ColorDictionary.Add(num, Color.FromArgb(Random.Next(Start, End), Random.Next(Start, End), Random.Next(Start, End)));
                BrushDictionary.Add(num, new SolidBrush(ColorDictionary[num]));
            }
        }

        private static bool IsValid(int num)
        {
            return num >= 0 && num <= 256;
        }

        public static int RandomColorNum()
        {
            return Random.Next(0, ColorDictionary.Count);
        }
    }
}