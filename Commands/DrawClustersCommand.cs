﻿using System;
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
        private readonly IRadialClusterAnalyzer analyzer;
        public DrawClustersCommand(MainWindow mainWindow, IRadialClusterAnalyzer analyzer) : base(mainWindow)
        {
            this.analyzer = analyzer;
        }

        public void Execute(List<Dot> dots)
        {
            string promptValue = UserPrompter.ShowDialog("Введите радиус кластера", "Введите радиус кластера");
            if (int.TryParse(promptValue, out int radius))
            {
                var enumerator = analyzer.SearchClusters(radius, dots);
                while (enumerator.MoveNext())
                {

                    var cluster = enumerator.Current;
                    // draw
                    using (Graphics g = Graphics.FromImage(MainWindow.ImageBox))
                    {
                        var pen = new Pen(RandomColors.GetColor(cluster.Number));
                        int x = (int)(cluster.RadiusDot.X - cluster.Radius);
                        int y = (int)(cluster.RadiusDot.Y - cluster.Radius);
                        int size = (int)radius * 2;
                        g.DrawEllipse(pen, x, y, size, size);
                    }

                    MainWindow.ImageBox = (Image)MainWindow.ImageBox.Clone();
                }
            }
        }
    }
}
