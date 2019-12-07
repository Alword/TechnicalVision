using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalVision.WindowsForms.Abstractions;
using TechnicalVision.WindowsForms.Models;
using TechnicalVision.WindowsForms.Services;
using TechnicalVision.WindowsForms.Views;

namespace TechnicalVision.WindowsForms.Commands
{
    public class DrawClustersCommand : BaseCommand, ICommand<List<Dot>>
    {
        private readonly ICommand<List<Dot>> drawDotsCommand;
        private readonly IRadialClusterAnalyzer analyzer;
        public DrawClustersCommand(MainWindow mainWindow, IRadialClusterAnalyzer analyzer) : base(mainWindow)
        {
            this.analyzer = analyzer;
            drawDotsCommand = new DrawDots(mainWindow);
        }

        public void Execute(List<Dot> dots)
        {
            string promptValue = UserPrompter.ShowDialog("Введите радиус кластера", "Введите радиус кластера");
            if (int.TryParse(promptValue, out int radius) && radius > 0)
            {
                List<Cluster> clusterList = analyzer.SearchClusters(radius - DrawDots.DOT_RADIUS, dots);

                drawDotsCommand.Execute(clusterList.SelectMany(d => d.Dots).ToList());

                using (Graphics g = Graphics.FromImage(MainWindow.ImageBox))
                {
                    foreach (var cluster in clusterList)
                    {
                        var pen = new Pen(RandomColors.GetColor(cluster.Number));
                        int x = (int)(cluster.RadiusDot.X - cluster.Radius - DrawDots.DOT_RADIUS);
                        int y = (int)(cluster.RadiusDot.Y - cluster.Radius - DrawDots.DOT_RADIUS);
                        int size = (int)(cluster.Radius + DrawDots.DOT_RADIUS) * 2;
                        g.DrawEllipse(pen, x, y, size, size);
                    }
                }
                MainWindow.ImageBox = (Image)MainWindow.ImageBox.Clone();
            }
        }
    }
}
