using System.Collections.Generic;
using System.IO;
using System.Linq;
using TechnicalVision.WindowsForms.Models;

namespace TechnicalVision.WindowsForms.Services
{
    public class ReadCsvFromFile
    {
        private readonly string filePath;

        public ReadCsvFromFile(string filePath)
        {
            this.filePath = filePath;
        }

        public List<Dot> GetDots()
        {
            string[] source = File.ReadAllLines(filePath);
            var dots = new List<Dot>(source.Length);
            source.Select(new Dot(){ })
        }
    }
}
