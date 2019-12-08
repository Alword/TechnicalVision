namespace TechnicalVision.WindowsForms
{
    partial class MainWindow
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.генераторТочекToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.построитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.линиюНаилучшегоПриближенияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.линияСреднихExtraDipToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.рофланЛинияПоЦентруToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.среднийXИYToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.разбитьНаКластерыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.подборПозицийToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.splitter1);
            this.panel1.Controls.Add(this.listBox1);
            this.panel1.Controls.Add(this.menuStrip1);
            this.panel1.Cursor = System.Windows.Forms.Cursors.Default;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(805, 436);
            this.panel1.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(628, 412);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter1.Location = new System.Drawing.Point(628, 24);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 412);
            this.splitter1.TabIndex = 4;
            this.splitter1.TabStop = false;
            // 
            // listBox1
            // 
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(631, 24);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(174, 412);
            this.listBox1.TabIndex = 5;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.генераторТочекToolStripMenuItem,
            this.построитьToolStripMenuItem,
            this.среднийXИYToolStripMenuItem,
            this.разбитьНаКластерыToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(805, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сохранитьToolStripMenuItem,
            this.OpenToolStripMenuItem,
            this.SaveAsToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.сохранитьToolStripMenuItem.Text = "Новый";
            this.сохранитьToolStripMenuItem.Click += new System.EventHandler(this.NewPoolToolStripMenuItem_Click);
            // 
            // OpenToolStripMenuItem
            // 
            this.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem";
            this.OpenToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.OpenToolStripMenuItem.Text = "Открыть";
            this.OpenToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
            // 
            // SaveAsToolStripMenuItem
            // 
            this.SaveAsToolStripMenuItem.Name = "SaveAsToolStripMenuItem";
            this.SaveAsToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.SaveAsToolStripMenuItem.Text = "Сохранить как";
            this.SaveAsToolStripMenuItem.Click += new System.EventHandler(this.SaveAsToolStripMenuItem_Click);
            // 
            // генераторТочекToolStripMenuItem
            // 
            this.генераторТочекToolStripMenuItem.Name = "генераторТочекToolStripMenuItem";
            this.генераторТочекToolStripMenuItem.Size = new System.Drawing.Size(110, 20);
            this.генераторТочекToolStripMenuItem.Text = "Генератор точек";
            this.генераторТочекToolStripMenuItem.Click += new System.EventHandler(this.GenerateToolStripMenuItem_Click);
            // 
            // построитьToolStripMenuItem
            // 
            this.построитьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.линиюНаилучшегоПриближенияToolStripMenuItem,
            this.линияСреднихExtraDipToolStripMenuItem,
            this.рофланЛинияПоЦентруToolStripMenuItem});
            this.построитьToolStripMenuItem.Name = "построитьToolStripMenuItem";
            this.построитьToolStripMenuItem.Size = new System.Drawing.Size(138, 20);
            this.построитьToolStripMenuItem.Text = "Линии  приближения";
            // 
            // линиюНаилучшегоПриближенияToolStripMenuItem
            // 
            this.линиюНаилучшегоПриближенияToolStripMenuItem.Name = "линиюНаилучшегоПриближенияToolStripMenuItem";
            this.линиюНаилучшегоПриближенияToolStripMenuItem.Size = new System.Drawing.Size(309, 22);
            this.линиюНаилучшегоПриближенияToolStripMenuItem.Text = "Подбор коэффициентов";
            this.линиюНаилучшегоПриближенияToolStripMenuItem.Click += new System.EventHandler(this.DrawBestApproximationToolStripMenuItem_Click);
            // 
            // линияСреднихExtraDipToolStripMenuItem
            // 
            this.линияСреднихExtraDipToolStripMenuItem.Enabled = false;
            this.линияСреднихExtraDipToolStripMenuItem.Name = "линияСреднихExtraDipToolStripMenuItem";
            this.линияСреднихExtraDipToolStripMenuItem.Size = new System.Drawing.Size(309, 22);
            this.линияСреднихExtraDipToolStripMenuItem.Text = "Среднее арифметическое коэффициентов";
            this.линияСреднихExtraDipToolStripMenuItem.Click += new System.EventHandler(this.AverageAngleExtraDipToolStripMenuItem_Click);
            // 
            // рофланЛинияПоЦентруToolStripMenuItem
            // 
            this.рофланЛинияПоЦентруToolStripMenuItem.Name = "рофланЛинияПоЦентруToolStripMenuItem";
            this.рофланЛинияПоЦентруToolStripMenuItem.Size = new System.Drawing.Size(309, 22);
            this.рофланЛинияПоЦентруToolStripMenuItem.Text = "Подбор угла";
            this.рофланЛинияПоЦентруToolStripMenuItem.Click += new System.EventHandler(this.MiddleDotToolStripMenuItem_Click);
            // 
            // среднийXИYToolStripMenuItem
            // 
            this.среднийXИYToolStripMenuItem.Name = "среднийXИYToolStripMenuItem";
            this.среднийXИYToolStripMenuItem.Size = new System.Drawing.Size(97, 20);
            this.среднийXИYToolStripMenuItem.Text = "Средний X и Y";
            this.среднийXИYToolStripMenuItem.Click += new System.EventHandler(this.TargetXY_ToolStripMenuItem_Click);
            // 
            // разбитьНаКластерыToolStripMenuItem
            // 
            this.разбитьНаКластерыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.подборПозицийToolStripMenuItem});
            this.разбитьНаКластерыToolStripMenuItem.Name = "разбитьНаКластерыToolStripMenuItem";
            this.разбитьНаКластерыToolStripMenuItem.Size = new System.Drawing.Size(113, 20);
            this.разбитьНаКластерыToolStripMenuItem.Text = "Поиск кластеров";
            // 
            // подборПозицийToolStripMenuItem
            // 
            this.подборПозицийToolStripMenuItem.Name = "подборПозицийToolStripMenuItem";
            this.подборПозицийToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.подборПозицийToolStripMenuItem.Text = "Подбор позиций";
            this.подборПозицийToolStripMenuItem.Click += new System.EventHandler(this.ExhaustiveAnalyzerToolStripMenuItem_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 436);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(805, 34);
            this.panel2.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Период:  ";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBox1.Location = new System.Drawing.Point(61, 8);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 6;
            this.textBox1.Text = "1";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(805, 436);
            this.panel3.TabIndex = 3;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(805, 470);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Name = "MainWindow";
            this.Text = "Кластеризация";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveAsToolStripMenuItem;
        public System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ToolStripMenuItem генераторТочекToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem построитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem линиюНаилучшегоПриближенияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem линияСреднихExtraDipToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem рофланЛинияПоЦентруToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem среднийXИYToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem разбитьНаКластерыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem подборПозицийToolStripMenuItem;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
    }
}

