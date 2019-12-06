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
                
                var dot1 = GetCoordinate(result,0,0);
                var dot2 = GetCoordinate(result,255,255);
                g.DrawLine(Pens.Blue,dot1.Item1,dot1.Item2,dot2.Item1,dot2.Item2);
            }

            MainWindow.ImageBox = (Image)MainWindow.ImageBox.Clone();
        }

        private (int, int) GetCoordinate(LineParams line, int x, int y)
        {
            if (line.A != 0)
            {
                x = (int)(-(line.A * x + line.C) / line.B);
                return (x, y);
            }
            else if (line.B != 0)
            {
                y = (int)(-(line.A * x + line.C) / line.B);
            }
            else
            {
                x = 0;
                y = 0;
            }

            return (x, y);
        }
    }
}
