﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using TechnicalVision.WindowsForms.Abstractions;
using TechnicalVision.WindowsForms.Commands;
using TechnicalVision.WindowsForms.Models;
using TechnicalVision.WindowsForms.Services.RegressionAnalysis;

namespace TechnicalVision.WindowsForms
{
    public partial class MainWindow : Form
    {
        private List<Dot> currentDots;
        public List<Dot> CurrentDots
        {
            get => currentDots ?? (currentDots = new List<Dot>(0));
            set
            {
                currentDots = value;
                listBox1.DataSource = currentDots;
                drawDotsCommand.Execute(currentDots);
            }
        }

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

        private readonly ICommand openCsvFile;
        private readonly ICommand<List<Dot>> drawDotsCommand;
        private readonly ICommand<List<Dot>> drawBestApproximationCommand;
        private readonly ICommand<List<Dot>> drawAvarageApproximationCommand;
        private readonly ICommand<List<Dot>> middleDotCommand;
        private readonly ICommand<List<Dot>> saveCsvFile;
        private readonly ICommand<List<Dot>> drawTargetCommand;
        private readonly ICommand<int> generateCommand;
        public MainWindow()
        {
            InitializeComponent();
            saveCsvFile = new SaveCsvCommand();
            openCsvFile = new OpenCsvCommand(this);
            generateCommand = new GenerateDots(this);
            drawDotsCommand = new DrawDots(this);
            drawBestApproximationCommand = new DrawBestApproximationLine(this, new ExoustiveSearch());
            drawAvarageApproximationCommand = new DrawBestApproximationLine(this, new AverageAngleSearch());
            middleDotCommand = new DrawBestApproximationLine(this, new MidpointAngleSearch());
            drawTargetCommand = new DrawTargetToMiddlePoint(this);
        }


        private void OpenToolStripMenuItem_Click(object sender, EventArgs e) => openCsvFile.Execute();

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e) => saveCsvFile.Execute(CurrentDots);

        private void GenerateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            generateCommand.Execute(100);
            drawTargetCommand.Execute(CurrentDots);
        }

        private void DrawBestApproximationToolStripMenuItem_Click(object sender, EventArgs e) =>
            drawBestApproximationCommand.Execute(CurrentDots);

        private void AvarageAngleExtraDipToolStripMenuItem_Click(object sender, EventArgs e)
            => drawAvarageApproximationCommand.Execute(CurrentDots);

        private void MiddleDotToolStripMenuItem_Click(object sender, EventArgs e)
            => middleDotCommand.Execute(CurrentDots);

        private void TargetXY_ToolStripMenuItem_Click(object sender, EventArgs e)
            => drawTargetCommand.Execute(CurrentDots);
    }
}
