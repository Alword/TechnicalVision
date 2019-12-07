using System.Collections.Generic;
using System.Drawing;
using TechnicalVision.WindowsForms.Abstractions;
using TechnicalVision.WindowsForms.Models;
using TechnicalVision.WindowsForms.Services;

namespace TechnicalVision.WindowsForms.Commands
{
    public class DrawDots : BaseCommand, ICommand<List<Dot>>
    {
        public const int DOT_RADIUS = 4;

        public DrawDots(MainWindow mainWindow) : base(mainWindow)
        {
        }

        public void Execute(List<Dot> dots)
        {
            Point screeSize = MainWindow.GetDrawableSize();
            var image = new Bitmap(screeSize.X, screeSize.Y);

            using (Graphics g = Graphics.FromImage(image))
            {
                g.Clear(Color.White);
                foreach (Dot dot in dots)
                    g.FillEllipse(RandomColors.GetBrush(dot.C), dot.X - DOT_RADIUS, dot.Y - DOT_RADIUS, 2 * DOT_RADIUS,
                        2 * DOT_RADIUS);
            }

            MainWindow.ImageBox = image;
        }
    }
}