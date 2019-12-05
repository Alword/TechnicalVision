using System.Collections.Generic;
using System.IO;
using System.Linq;
using TechnicalVision.WindowsForms.Models;

namespace TechnicalVision.WindowsForms.Services
{
    public class SaveCsvToFile
    {
        public string FilePath { get; }

        public SaveCsvToFile(string filePath)
        {
            this.FilePath = filePath;
        }

        public void TrySaveToFile(List<Dot> dots)
        {
            File.WriteAllLines(FilePath, dots.Select(d => d.ToString()));
        }
    }
}
