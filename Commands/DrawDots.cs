using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TechnicalVision.WindowsForms.Abstractions;
using TechnicalVision.WindowsForms.Models;
using TechnicalVision.WindowsForms.Services;

namespace TechnicalVision.WindowsForms.Commands
{
    public class DrawDots : ICommand<List<Dot>>
    {
        private readonly List<Dot> dots;
        private readonly PictureBox pictureBox;
        public DrawDots(PictureBox pictureBox)
        {
            this.pictureBox = pictureBox;
        }

        public void Execute(List<Dot> dots)
        {

            int size = 256 * 4;
            Bitmap image = new Bitmap(size, size);

            using (Graphics g = Graphics.FromImage(image))
            {
                g.Clear(Color.White);
                foreach (var dot in dots)
                {
                    g.FillEllipse(RandomColors.GetColor(dot.C), dot.X, dot.Y, 10, 10);
                }
            }

            pictureBox.Image = image;
            pictureBox.Invalidate();
        }
    }
}
