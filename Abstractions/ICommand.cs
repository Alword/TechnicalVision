using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalVision.WindowsForms.Abstractions
{
    public interface ICommand<in T>
    {
        void Execute(T parameter);
    }

    public interface ICommand
    {
        void Execute();
    }
}
