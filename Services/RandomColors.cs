﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace TechnicalVision.WindowsForms.Services
{
    public static class RandomColors
    {
        private static readonly Random random = new Random(159753);
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
            foreach (int num in Enumerable.Range(0, 256))
            {
                ColorDictionary.Add(num, Color.FromArgb(random.Next(0, 256), random.Next(0, 256), random.Next(0, 256)));
                BrushDictionary.Add(num, new SolidBrush(ColorDictionary[num]));
            }
        }

        private static bool IsValid(int num)
        {
            return num >= 0 && num <= 256;
        }

        public static int RandomColorNum()
        {
            return random.Next(0, ColorDictionary.Count);
        }
    }
}