namespace Lab6
{
    partial class Form2
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            numericUpDown5 = new NumericUpDown();
            label5 = new Label();
            numericUpDown4 = new NumericUpDown();
            label4 = new Label();
            numericUpDown3 = new NumericUpDown();
            label3 = new Label();
            numericUpDown2 = new NumericUpDown();
            label2 = new Label();
            numericUpDown1 = new NumericUpDown();
            label1 = new Label();
            button1 = new Button();
            button2 = new Button();
            numericUpDown6 = new NumericUpDown();
            label6 = new Label();
            listBox1 = new ListBox();
            ((System.ComponentModel.ISupportInitialize)chart1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown6).BeginInit();
            SuspendLayout();
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            chart1.Legends.Add(legend1);
            chart1.Location = new Point(566, 73);
            chart1.Name = "chart1";
            chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SeaGreen;
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            chart1.Series.Add(series1);
            chart1.Size = new Size(413, 339);
            chart1.TabIndex = 23;
            chart1.Text = "chart1";
            // 
            // numericUpDown5
            // 
            numericUpDown5.DecimalPlaces = 5;
            numericUpDown5.Location = new Point(93, 205);
            numericUpDown5.Maximum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown5.Name = "numericUpDown5";
            numericUpDown5.Size = new Size(81, 27);
            numericUpDown5.TabIndex = 22;
            numericUpDown5.Value = new decimal(new int[] { 3, 0, 0, 65536 });
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(50, 207);
            label5.Name = "label5";
            label5.Size = new Size(25, 20);
            label5.TabIndex = 21;
            label5.Text = "P5";
            // 
            // numericUpDown4
            // 
            numericUpDown4.DecimalPlaces = 5;
            numericUpDown4.Location = new Point(93, 172);
            numericUpDown4.Maximum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown4.Name = "numericUpDown4";
            numericUpDown4.Size = new Size(81, 27);
            numericUpDown4.TabIndex = 20;
            numericUpDown4.Value = new decimal(new int[] { 25, 0, 0, 131072 });
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(50, 174);
            label4.Name = "label4";
            label4.Size = new Size(25, 20);
            label4.TabIndex = 19;
            label4.Text = "P4";
            // 
            // numericUpDown3
            // 
            numericUpDown3.DecimalPlaces = 5;
            numericUpDown3.Location = new Point(93, 139);
            numericUpDown3.Maximum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown3.Name = "numericUpDown3";
            numericUpDown3.Size = new Size(81, 27);
            numericUpDown3.TabIndex = 18;
            numericUpDown3.Value = new decimal(new int[] { 1, 0, 0, 65536 });
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(50, 141);
            label3.Name = "label3";
            label3.Size = new Size(25, 20);
            label3.TabIndex = 17;
            label3.Text = "P3";
            // 
            // numericUpDown2
            // 
            numericUpDown2.DecimalPlaces = 5;
            numericUpDown2.Location = new Point(93, 106);
            numericUpDown2.Maximum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(81, 27);
            numericUpDown2.TabIndex = 16;
            numericUpDown2.Value = new decimal(new int[] { 15, 0, 0, 131072 });
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(50, 108);
            label2.Name = "label2";
            label2.Size = new Size(25, 20);
            label2.TabIndex = 15;
            label2.Text = "P2";
            // 
            // numericUpDown1
            // 
            numericUpDown1.DecimalPlaces = 5;
            numericUpDown1.Location = new Point(93, 73);
            numericUpDown1.Maximum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(81, 27);
            numericUpDown1.TabIndex = 14;
            numericUpDown1.Value = new decimal(new int[] { 2, 0, 0, 65536 });
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(50, 75);
            label1.Name = "label1";
            label1.Size = new Size(25, 20);
            label1.TabIndex = 13;
            label1.Text = "P1";
            // 
            // button1
            // 
            button1.Location = new Point(885, 16);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 24;
            button1.Text = "Закрыть";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(749, 439);
            button2.Name = "button2";
            button2.Size = new Size(105, 29);
            button2.TabIndex = 25;
            button2.Text = "Построение";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // numericUpDown6
            // 
            numericUpDown6.Location = new Point(93, 14);
            numericUpDown6.Maximum = new decimal(new int[] { 1410065408, 2, 0, 0 });
            numericUpDown6.Name = "numericUpDown6";
            numericUpDown6.Size = new Size(150, 27);
            numericUpDown6.TabIndex = 26;
            numericUpDown6.Value = new decimal(new int[] { 1000000, 0, 0, 0 });
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(38, 16);
            label6.Name = "label6";
            label6.Size = new Size(37, 20);
            label6.TabIndex = 27;
            label6.Text = "Шаг";
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(38, 259);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(505, 264);
            listBox1.TabIndex = 28;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1005, 629);
            Controls.Add(listBox1);
            Controls.Add(label6);
            Controls.Add(numericUpDown6);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(chart1);
            Controls.Add(numericUpDown5);
            Controls.Add(label5);
            Controls.Add(numericUpDown4);
            Controls.Add(label4);
            Controls.Add(numericUpDown3);
            Controls.Add(label3);
            Controls.Add(numericUpDown2);
            Controls.Add(label2);
            Controls.Add(numericUpDown1);
            Controls.Add(label1);
            Name = "Form2";
            Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)chart1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown5).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown4).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown6).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private NumericUpDown numericUpDown5;
        private Label label5;
        private NumericUpDown numericUpDown4;
        private Label label4;
        private NumericUpDown numericUpDown3;
        private Label label3;
        private NumericUpDown numericUpDown2;
        private Label label2;
        private NumericUpDown numericUpDown1;
        private Label label1;
        private Button button1;
        private Button button2;
        private NumericUpDown numericUpDown6;
        private Label label6;
        private ListBox listBox1;
    }
}