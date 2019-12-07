using System;
using System.Windows.Forms;

namespace TechnicalVision.WindowsForms.Services
{
    public class CsvSafeFileDialog
    {
        public static string TryGetCsvFilePath(out bool isFileSelected)
        {
            using (var saveFileDialog = new SaveFileDialog())
            {
                isFileSelected = false;
                saveFileDialog.InitialDirectory = Environment.CurrentDirectory;
                saveFileDialog.Filter = "Файлы csv|*.csv|Все файлы (*.*)|*.*";
                if (saveFileDialog.ShowDialog() == DialogResult.OK) isFileSelected = true;
                return saveFileDialog.FileName;
            }
        }
    }
}