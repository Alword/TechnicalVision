using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalVision.WindowsForms.Abstractions;
using TechnicalVision.WindowsForms.Models;

namespace TechnicalVision.WindowsForms.Commands
{
    public class DrawTargetToMiddlePoint : BaseCommand, ICommand<List<Dot>>
    {
        public DrawTargetToMiddlePoint(MainWindow mainWindow) : base(mainWindow)
        {
        }

        public void Execute(List<Dot> dots)
        {
            Point screeSize = MainWindow.GetDrawableSize();

            int x = dots.Sum(d => d.X) / dots.Count;
            int y = dots.Sum(d => d.Y) / dots.Count;

            using (Graphics g = Graphics.FromImage(MainWindow.ImageBox))
            {
                g.DrawLine(Pens.BlueViolet, 0, y, screeSize.X, y);
                g.DrawLine(Pens.BlueViolet, x, 0, x, screeSize.Y);
            }

            MainWindow.ImageBox = (Image)MainWindow.ImageBox.Clone();
        }
    }
}
