using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalVision.WindowsForms.Abstractions;
using TechnicalVision.WindowsForms.Services.RegressionAnalysis;

namespace TechnicalVision.WindowsForms.Commands
{
    public class DrawBestApproximationLine : BaseCommand, ICommand
    {
        IRegressionAnalysis regressionAnalysis = new ExoustiveSearch();
        public DrawBestApproximationLine(MainWindow mainWindow) : base(mainWindow) { }

        public void Execute()
        {
            (int, double) result = regressionAnalysis.Search(MainWindow.CurrentDots);

            //MainWindow.pictureBox1.Image = 
        }
    }
}
