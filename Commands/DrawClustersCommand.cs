using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using TechnicalVision.WindowsForms.Abstractions;
using TechnicalVision.WindowsForms.Models;
using TechnicalVision.WindowsForms.Services;
using TechnicalVision.WindowsForms.Views;

namespace TechnicalVision.WindowsForms.Commands
{
    public class DrawClustersCommand : BaseCommand, ICommand<IList<Dot>>
    {
        private readonly ICommand<List<Dot>> drawDotsCommand;
        private readonly IRadialClusterAnalyzer analyzer;
        public DrawClustersCommand(MainWindow mainWindow, IRadialClusterAnalyzer analyzer) : base(mainWindow)
        {
            this.analyzer = analyzer;
            drawDotsCommand = new DrawDots(mainWindow);
        }

        public void Execute(IList<Dot> dots)
        {
            string promptValue = UserPrompter.ShowDialog("Введите радиус кластера", "Введите радиус кластера");
            if (int.TryParse(promptValue, out int radius) && radius > 0)
            {
                IList<Cluster> clusterList = analyzer.SearchClusters(radius - DrawDots.DOT_RADIUS, dots);

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

                        DrawText(g, cluster);

                    }
                }
                MainWindow.ImageBox = (Image)MainWindow.ImageBox.Clone();
            }
        }

        private void DrawText(Graphics g, Cluster cluster)
        {
            GraphicsPath myPath = new GraphicsPath();

            string stringText = $"{cluster.Number}";
            FontFamily family = new FontFamily("Arial");
            int fontStyle = (int)FontStyle.Regular;
            int emSize = 16;
            Point origin = new Point(cluster.RadiusDot.X - emSize / 2,
                cluster.RadiusDot.Y - emSize / 2);
            StringFormat format = StringFormat.GenericDefault;

            myPath.AddString(stringText,
                family,
                fontStyle,
                emSize,
                origin,
                format);

            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.FillPath(RandomColors.GetBrush(cluster.Number), myPath);
            g.DrawPath(new Pen(Brushes.Black,1F), myPath);
        }
    }
}
