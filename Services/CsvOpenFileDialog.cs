using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TechnicalVision.WindowsForms.Services
{
    public class CsvOpenFileDialog
    {
        public static string TryGetCsvFilePath(out bool isFileSelected)
        {
            using (var opf = new OpenFileDialog())
            {
                isFileSelected = false;
                opf.InitialDirectory = Environment.CurrentDirectory;
                opf.Filter = "Файлы csv|*.csv|Все файлы (*.*)|*.*";
                if (opf.ShowDialog() == DialogResult.OK)
                {
                    isFileSelected = true;
                }
                return opf.FileName;
            }
        }
    }
}
