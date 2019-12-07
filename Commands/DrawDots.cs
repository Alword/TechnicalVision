using System;
using System.Collections.Generic;
using System.Drawing;
using TechnicalVision.WindowsForms.Abstractions;
using TechnicalVision.WindowsForms.Models;
using TechnicalVision.WindowsForms.Services;

namespace TechnicalVision.WindowsForms.Commands
{
    public class DrawDots : BaseCommand, ICommand<List<Dot>>
    {
        const int DOT_SIZE = 10;
        public DrawDots(MainWindow mainWindow) : base(mainWindow) { }
        public void Execute(List<Dot> dots)
        {
            Point screeSize = MainWindow.GetDrawableSize();
            Bitmap image = new Bitmap(screeSize.X, screeSize.Y);

            using (Graphics g = Graphics.FromImage(image))
            {
                g.Clear(Color.White);
                foreach (var dot in dots)
                {
                    g.FillEllipse(RandomColors.GetBrush(dot.C), dot.X - DOT_SIZE / 2, dot.Y - DOT_SIZE / 2, DOT_SIZE, DOT_SIZE);
                }
            }

            MainWindow.ImageBox = image;
        }

    }
}
