namespace TechnicalVision.WindowsForms.Views
{
    partial class PromptView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.confirmation = new System.Windows.Forms.Button();
            this.textBox = new System.Windows.Forms.TextBox();
            this.textLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // confirmation
            // 
            this.confirmation.Location = new System.Drawing.Point(110, 83);
            this.confirmation.Name = "confirmation";
            this.confirmation.Size = new System.Drawing.Size(75, 23);
            this.confirmation.TabIndex = 0;
            this.confirmation.Text = "ОК";
            this.confirmation.UseVisualStyleBackColor = true;
            // 
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point(12, 57);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(286, 20);
            this.textBox.TabIndex = 1;
            // 
            // textLabel
            // 
            this.textLabel.AutoSize = true;
            this.textLabel.Location = new System.Drawing.Point(12, 31);
            this.textLabel.Name = "textLabel";
            this.textLabel.Size = new System.Drawing.Size(35, 13);
            this.textLabel.TabIndex = 2;
            this.textLabel.Text = "label1";
            // 
            // PromptView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(310, 118);
            this.Controls.Add(this.textLabel);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.confirmation);
            this.Name = "PromptView";
            this.Text = "PromptView";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Label textLabel;
        public System.Windows.Forms.TextBox textBox;
        public System.Windows.Forms.Button confirmation;
    }
}