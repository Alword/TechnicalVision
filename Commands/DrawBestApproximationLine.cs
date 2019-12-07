using System.Collections.Generic;
using System.Drawing;
using TechnicalVision.WindowsForms.Abstractions;
using TechnicalVision.WindowsForms.Models;

namespace TechnicalVision.WindowsForms.Commands
{
    public class DrawBestApproximationLine : BaseCommand, ICommand<List<Dot>>
    {
        private readonly IRegressionAnalysis regressionAnalysis;

        public DrawBestApproximationLine(MainWindow mainWindow, IRegressionAnalysis regression) : base(mainWindow)
        {
            regressionAnalysis = regression;
        }

        public async void Execute(List<Dot> dots)
        {
            Point end = MainWindow.GetDrawableSize();
            var endDot = new Dot(end.X, end.Y);

            (Dot, Dot) besLineParams = regressionAnalysis
                .Search(MainWindow.CurrentDots)
                .GetDots(end: endDot);


            using (Graphics g = Graphics.FromImage(MainWindow.ImageBox))
            {
                (Dot, Dot) points = besLineParams;
                Dot dot1 = points.Item1;
                Dot dot2 = points.Item2;

                g.DrawLine(Pens.Blue, dot1.X, dot1.Y, dot2.X, dot2.Y);
            }

            MainWindow.ImageBox = (Image) MainWindow.ImageBox.Clone();
        }
    }
}