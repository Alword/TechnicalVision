using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalVision.WindowsForms.Abstractions;
using TechnicalVision.WindowsForms.Models;

namespace TechnicalVision.WindowsForms.Commands
{
    public class GenerateDots : BaseCommand, ICommand<int>
    {
        private static readonly Random Random;
        static GenerateDots()
        {
            Random = new Random((int)DateTime.UtcNow.Ticks);
        }

        public GenerateDots(MainWindow window) : base(window) { }
        public void Execute(int parameter = 50)
        {
            var randomDots = new List<Dot>(parameter);
            randomDots.AddRange(Enumerable.Range(0, parameter)
                .Select(variable => new Dot()
                {
                    X = Random.Next(0, 256),
                    Y = Random.Next(0, 256),
                    C = Random.Next(0, 256)
                }));
            MainWindow.CurrentDots = randomDots;
        }
    }
}
