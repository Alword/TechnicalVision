using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalVision.WindowsForms.Views
{
    public abstract class BaseView
    {
        protected Form1 Form1 { get; set; }

        public BaseView(Form1 form1)
        {
            Form1 = form1;
        }
    }
}
