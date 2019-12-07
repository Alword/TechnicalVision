using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TechnicalVision.WindowsForms.Views
{
    public static class UserPrompter
    {
        public static string ShowDialog(string text, string caption)
        {
            var prompt = new PromptView()
            {
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterParent,
            };
            prompt.textLabel.Text = text;
            prompt.confirmation.Text = "Ok";
            prompt.confirmation.DialogResult = DialogResult.OK;
            prompt.confirmation.Click += (sender, e) => { prompt.Close(); };
            return prompt.ShowDialog() == DialogResult.OK ? prompt.textBox.Text : "";
        }
    }
}
