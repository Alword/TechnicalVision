using System.Collections.Generic;
using TechnicalVision.WindowsForms.Abstractions;
using TechnicalVision.WindowsForms.Models;
using TechnicalVision.WindowsForms.Services;

namespace TechnicalVision.WindowsForms.Commands
{
    public class SaveCsvCommand : ICommand<IList<Dot>>
    {
        public void Execute(IList<Dot> dots)
        {
            // open window
            string filePath = CsvSafeFileDialog.TryGetCsvFilePath(out bool isFileSelected);
            if (!isFileSelected) return;
            // get dots

            // save to file
            var saver = new SaveCsvToFile(filePath);
            saver.TrySaveToFile(dots);
        }
    }
}