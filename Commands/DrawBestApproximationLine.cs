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
            //(Dot,Dot) result = regressionAnalysis.Search(MainWindow.CurrentDots);


            double minSum = int.MaxValue;
            int middleX = dots.Sum(d => d.X) / dots.Count;
            int middleY = dots.Sum(d => d.Y) / dots.Count;
            Dot middleDot = new Dot(middleX, middleY);
            LineParams besLineParams = default;
            Pen coloPen;

            for (double a = 0; a < Math.PI; a += Math.PI / 100)
            {
                coloPen = Pens.Blue;
                LineParams line = new LineParams(middleDot, a);
                double sum = dots.Sum(dot => line.GetDistance(dot)) / dots.Count;

                if (minSum > sum)
                {
                    minSum = sum;
                    coloPen = Pens.Red;
                } 
                besLineParams = line;



                using (Graphics g = Graphics.FromImage(MainWindow.ImageBox))
                {

                    var points = besLineParams.GetDots();
                    var dot1 = points.Item1;
                    var dot2 = points.Item2;

                    g.DrawLine(coloPen, dot1.X, dot1.Y, dot2.X, dot2.Y);
                }

                MainWindow.ImageBox = (Image)MainWindow.ImageBox.Clone();
                await Task.Delay(1);
            }



        }
    }
}
