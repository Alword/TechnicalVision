using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TechnicalVision.WindowsForms.Abstractions;
using TechnicalVision.WindowsForms.Commands;
using TechnicalVision.WindowsForms.Models;

namespace TechnicalVision.WindowsForms
{
    public partial class MainWindow : Form
    {
        private List<Dot> currentDots;
        public List<Dot> CurrentDots
        {
            get => currentDots;
            set
            {
                currentDots = value;
                listBox1.DataSource = currentDots;
            }
        }

        private readonly ICommand openCsvFile;
        private readonly ICommand<List<Dot>> saveCsvFile;
        public MainWindow()
        {
            InitializeComponent();
            saveCsvFile = new SaveCsvCommand();
            openCsvFile = new OpenCsvCommand(this);
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e) => openCsvFile.Execute();

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e) => saveCsvFile.Execute(CurrentDots);
    }
}
