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
            MainWindow.CurrentDots.AddRange(dots);
        }
    }
}