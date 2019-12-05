using System;
using System.Collections.Generic;
using System.IO;
using TechnicalVision.WindowsForms.Abstractions;
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
            if (string.IsNullOrEmpty(filePath) || !File.Exists(filePath))
                return new List<Dot>();

            string[] source = File.ReadAllLines(filePath);
            var dots = new List<Dot>(source.Length);

            foreach (string line in source)
            {
                Dot.TryParse(line, out Dot dot);
                dots.Add(dot);
            }

            return dots;
        }

    }
}