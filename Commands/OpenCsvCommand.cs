using System.Collections.Generic;
using TechnicalVision.WindowsForms.Abstractions;
using TechnicalVision.WindowsForms.Models;
using TechnicalVision.WindowsForms.Services;

namespace TechnicalVision.WindowsForms.Commands
{
    public class OpenCsvCommand : BaseCommand, ICommand
    {
        public OpenCsvCommand(MainWindow mainWindow) : base(mainWindow)
        {
        }


        public void Execute()
        {
            // open window
            string filePath = CsvOpenFileDialog.TryGetCsvFilePath(out bool isFileSelected);
            if (!isFileSelected) return;
            // load csv
            var reader = new ReadCsvFromFile(filePath);
            List<Dot> dots = reader.GetDots();
            // display to list
            AddNesList(dots);
        }
    }
}