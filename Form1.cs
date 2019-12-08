using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using TechnicalVision.WindowsForms.Abstractions;
using TechnicalVision.WindowsForms.Commands;
using TechnicalVision.WindowsForms.Models;
using TechnicalVision.WindowsForms.Services;
using TechnicalVision.WindowsForms.Services.ClusterAnalyzers;
using TechnicalVision.WindowsForms.Services.RegressionAnalysis;

namespace TechnicalVision.WindowsForms
{
    public partial class MainWindow : Form
    {
        public bool Draw = true;
        private readonly ICommand<int> generateCommand;
        private readonly ICommand<IList<Dot>> drawDotsCommand;

        private readonly ICommand<IList<Dot>> drawAverageApproximationCommand;
        private readonly ICommand<IList<Dot>> drawBestApproximationCommand;
        private readonly ICommand<IList<Dot>> middleDotCommand;

        private readonly ICommand<IList<Dot>> drawTargetCommand;

        private readonly ICommand<IList<Dot>> exhaustiveClusterAnalyzerCommand;


        private readonly ICommand openCsvFile;
        private readonly ICommand<IList<Dot>> saveCsvFile;

        public MainWindow()
        {
            InitializeComponent();
            saveCsvFile = new SaveCsvCommand();
            openCsvFile = new OpenCsvCommand(this);
            generateCommand = new GenerateDots(this);
            drawDotsCommand = new DrawDots(this);
            drawBestApproximationCommand = new DrawBestApproximationLine(this, new ExhaustiveSearch());
            drawAverageApproximationCommand = new DrawBestApproximationLine(this, new AverageAngleSearch());
            middleDotCommand = new DrawBestApproximationLine(this, new MidpointAngleSearch());
            drawTargetCommand = new DrawTargetToMiddlePoint(this);
            exhaustiveClusterAnalyzerCommand = new DrawClustersCommand(this, new ExhaustiveClusterAnalyzer());
            
            CurrentDots = new BindingList<Dot>();
            listBox1.DataSource = CurrentDots;
            CurrentDots.ListChanged += CurrentDots_ListChanged;
        }

        private void CurrentDots_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (Draw)
            {
                drawDotsCommand.Execute(CurrentDots);
            }
        }

        public BindingList<Dot> CurrentDots { get; set; }

        public Image ImageBox
        {
            get => pictureBox1.Image;
            set
            {
                pictureBox1.Image?.Dispose();
                pictureBox1.Image = value;
                pictureBox1.Invalidate();
            }
        }

        public Point GetDrawableSize()
        {
            return new Point(pictureBox1.Size.Width, pictureBox1.Size.Height);
        }


        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openCsvFile.Execute();
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveCsvFile.Execute(CurrentDots);
        }

        private void GenerateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int dotsCount = (GetDrawableSize().X + GetDrawableSize().Y) / 5;
            generateCommand.Execute(dotsCount);
            drawTargetCommand.Execute(CurrentDots);
        }

        private void DrawBestApproximationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            drawBestApproximationCommand.Execute(CurrentDots);
        }

        private void AverageAngleExtraDipToolStripMenuItem_Click(object sender, EventArgs e)
        {
            drawAverageApproximationCommand.Execute(CurrentDots);
        }

        private void MiddleDotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            middleDotCommand.Execute(CurrentDots);
        }

        private void TargetXY_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            drawTargetCommand.Execute(CurrentDots);
        }

        private void ExhaustiveAnalyzerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            drawDotsCommand.Execute(CurrentDots);
            exhaustiveClusterAnalyzerCommand.Execute(CurrentDots);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            var mouse = (MouseEventArgs)e;
            CurrentDots.Add(new Dot(mouse.X, mouse.Y, RandomColors.RandomColorNum()));
        }

        private void NewPoolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentDots.Clear();
        }
    }
}