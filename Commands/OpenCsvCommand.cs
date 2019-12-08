using System.Collections.Generic;
using TechnicalVision.WindowsForms.Abstractions;
using TechnicalVision.WindowsForms.Models;
using TechnicalVision.WindowsForms.Services;

namespace TechnicalVision.WindowsForms.Commands
{
    public class OpenCsvCommand : BaseCommand, ICommand<int>
    {
        public OpenCsvCommand(MainWindow mainWindow) : base(mainWindow)
        {
        }


        public void Execute(int i = 0)
        {
            // open window
            string filePath = CsvOpenFileDialog.TryGetCsvFilePath(out bool isFileSelected);
            if (!isFileSelected) return;
            // load csv
            var reader = new ReadCsvFromFile(filePath);
            IList<Dot> dots = reader.GetDots();
            //
            dots = RepeatDots.Repeat(i, dots);
            // display to list
            AddNesList(dots);
        }
    }
}