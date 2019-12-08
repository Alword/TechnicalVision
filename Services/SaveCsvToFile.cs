using System.Collections.Generic;
using System.IO;
using System.Linq;
using TechnicalVision.WindowsForms.Models;

namespace TechnicalVision.WindowsForms.Services
{
    public class SaveCsvToFile
    {
        public SaveCsvToFile(string filePath)
        {
            FilePath = filePath;
        }

        public string FilePath { get; }

        public void TrySaveToFile(IList<Dot> dots)
        {
            File.WriteAllLines(FilePath, dots.Select(d => d.ToString()));
        }
    }
}