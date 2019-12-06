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
        public DrawDots(MainWindow mainWindow) : base(mainWindow) { }
        public void Execute(List<Dot> dots)
        {
            int size = 256 * 4;
            Bitmap image = new Bitmap(size, size);

            using (Graphics g = Graphics.FromImage(image))
            {
                g.Clear(Color.White);
                foreach (var dot in dots)
                {
                    g.FillEllipse(RandomColors.GetColor(dot.C), dot.X, dot.Y, 10, 10);
                }
            }

            MainWindow.ImageBox = image;
        }

    }
}
