using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalVision.WindowsForms.Abstractions;
using TechnicalVision.WindowsForms.Models;
using TechnicalVision.WindowsForms.Services;

namespace TechnicalVision.WindowsForms.Commands
{
    public class SaveCsvCommand : ICommand<List<Dot>>
    {
        public void Execute(List<Dot> dots)
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
