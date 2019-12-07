using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalVision.WindowsForms.Abstractions;

namespace TechnicalVision.WindowsForms.Commands
{
    public class DrawClustersCommand : BaseCommand, ICommand<int>
    {
        public DrawClustersCommand(MainWindow mainWindow) : base(mainWindow)
        {
        }

        public void Execute(int radius)
        {
            throw new NotImplementedException();
        }
    }
}
