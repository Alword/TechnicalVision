using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalVision.WindowsForms.Abstractions;
using TechnicalVision.WindowsForms.Models;
using TechnicalVision.WindowsForms.Services;
using TechnicalVision.WindowsForms.Services.RegressionAnalysis;

namespace TechnicalVision.WindowsForms.Commands
{
    public class DrawBestApproximationLine : BaseCommand, ICommand<List<Dot>>
    {
        private readonly IRegressionAnalysis regressionAnalysis;

        public DrawBestApproximationLine(MainWindow mainWindow, IRegressionAnalysis regression) : base(mainWindow)
        {
            regressionAnalysis = regression;
        }

        public void Execute(List<Dot> dots)
        {
            //y=a+bx
            (int, double) result = regressionAnalysis.Search(MainWindow.CurrentDots);

            using (Graphics g = Graphics.FromImage(MainWindow.ImageBox))
            {
                int x1 = 0;
                int x2 = 255;
                int y1 = GetCoordinate(x1, result.Item1, result.Item2);
                int y2 = GetCoordinate(x2, result.Item1, result.Item2);
                g.DrawLine(Pens.Blue, x1, y1, x2, y2);
            }

            MainWindow.ImageBox = (Image)MainWindow.ImageBox.Clone();
        }

        private int GetCoordinate(int x, int a, double b)
        {
            return (int)(a + b * x);
        }
    }
}
