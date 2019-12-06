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
            LineParams result = regressionAnalysis.Search(MainWindow.CurrentDots);


            using (Graphics g = Graphics.FromImage(MainWindow.ImageBox))
            {

                var points = GetPoints(result);
                var dot1 = points.Item1;
                var dot2 = points.Item2;

                g.DrawLine(Pens.Blue, dot1.X, dot1.Y, dot2.X, dot2.Y);
            }

            MainWindow.ImageBox = (Image)MainWindow.ImageBox.Clone();
        }

        private (Dot, Dot) GetPoints(LineParams line)
        {
            Dot start = new Dot(0, 0);
            Dot endPoint = new Dot(0, 0);

            if (line.B != 0 && line.A != 0)
            {
                start.X = 0;
                start.Y = (int) line.GetY(start.X);

                endPoint.Y = 0;
                endPoint.X = (int)line.GetX(endPoint.Y);
            }

            return (start, endPoint);
        }
    }
}
