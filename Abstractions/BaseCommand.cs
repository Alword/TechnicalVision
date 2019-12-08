using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using TechnicalVision.WindowsForms.Models;

namespace TechnicalVision.WindowsForms.Abstractions
{
    public abstract class BaseCommand
    {
        protected BaseCommand(MainWindow mainWindow)
        {
            MainWindow = mainWindow;
        }

        protected MainWindow MainWindow { get; set; }

        protected void AddNesList(IList<Dot> dots)
        {
            MainWindow.CurrentDots.Clear();
            AddRange(dots);
        }


        protected void AddRange(IList<Dot> dots)
        {
            var lastDot = dots.Last();
            MainWindow.Draw = false;
            foreach (Dot dot in dots.Where(d => !d.Equals(lastDot)))
            {
                MainWindow.CurrentDots.Add(dot);
            }
            MainWindow.Draw = true;
            MainWindow.CurrentDots.Add(lastDot);
        }
    }
}