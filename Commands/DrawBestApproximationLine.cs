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

        public async void Execute(List<Dot> dots)
        {
            (Dot, Dot) besLineParams = regressionAnalysis.Search(MainWindow.CurrentDots);


            using (Graphics g = Graphics.FromImage(MainWindow.ImageBox))
            {

                var points = besLineParams;
                var dot1 = points.Item1;
                var dot2 = points.Item2;

                g.DrawLine(Pens.Blue, dot1.X, dot1.Y, dot2.X, dot2.Y);
            }

            MainWindow.ImageBox = (Image)MainWindow.ImageBox.Clone();
        }

    }
}

