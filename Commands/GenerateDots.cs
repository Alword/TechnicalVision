using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using TechnicalVision.WindowsForms.Abstractions;
using TechnicalVision.WindowsForms.Models;
using TechnicalVision.WindowsForms.Services;

namespace TechnicalVision.WindowsForms.Commands
{
    public class GenerateDots : BaseCommand, ICommand<int>
    {
        private static readonly Random Random;

        static GenerateDots()
        {
            Random = new Random((int) DateTime.UtcNow.Ticks);
        }

        public GenerateDots(MainWindow window) : base(window)
        {
        }

        public void Execute(int parameter = 50)
        {
            Point screSize = MainWindow.GetDrawableSize();
            var randomDots = new List<Dot>(parameter);
            randomDots.AddRange(Enumerable.Range(0, parameter)
                .Select(variable => new Dot
                {
                    X = Random.Next(0, screSize.X),
                    Y = Random.Next(0, screSize.Y),
                    C = Random.Next(0, RandomColors.RandomColorNum())
                }));
            MainWindow.CurrentDots = randomDots;
        }
    }
}