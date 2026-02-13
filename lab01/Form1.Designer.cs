namespace Лаба1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            panel1 = new Panel();
            btExit = new Button();
            btStop = new Button();
            btClear = new Button();
            edGo = new NumericUpDown();
            label6 = new Label();
            btStart = new Button();
            edMass = new NumericUpDown();
            label5 = new Label();
            edSize = new NumericUpDown();
            label4 = new Label();
            edSpeed = new NumericUpDown();
            label3 = new Label();
            edAngle = new NumericUpDown();
            label2 = new Label();
            edHeight = new NumericUpDown();
            label1 = new Label();
            chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            timer1 = new System.Windows.Forms.Timer(components);
            dataGridView1 = new DataGridView();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)edGo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)edMass).BeginInit();
            ((System.ComponentModel.ISupportInitialize)edSize).BeginInit();
            ((System.ComponentModel.ISupportInitialize)edSpeed).BeginInit();
            ((System.ComponentModel.ISupportInitialize)edAngle).BeginInit();
            ((System.ComponentModel.ISupportInitialize)edHeight).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chart1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ButtonHighlight;
            panel1.Controls.Add(btExit);
            panel1.Controls.Add(btStop);
            panel1.Controls.Add(btClear);
            panel1.Controls.Add(edGo);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(btStart);
            panel1.Controls.Add(edMass);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(edSize);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(edSpeed);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(edAngle);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(edHeight);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1166, 77);
            panel1.TabIndex = 0;
            // 
            // btExit
            // 
            btExit.Location = new Point(989, 27);
            btExit.Name = "btExit";
            btExit.Size = new Size(101, 29);
            btExit.TabIndex = 15;
            btExit.Text = "Закрыть";
            btExit.UseVisualStyleBackColor = true;
            btExit.Click += btExit_Click;
            // 
            // btStop
            // 
            btStop.Location = new Point(786, 27);
            btStop.Name = "btStop";
            btStop.Size = new Size(94, 29);
            btStop.TabIndex = 14;
            btStop.Text = "Стоп";
            btStop.UseVisualStyleBackColor = true;
            btStop.Click += button2_Click;
            // 
            // btClear
            // 
            btClear.Location = new Point(886, 27);
            btClear.Name = "btClear";
            btClear.Size = new Size(97, 29);
            btClear.TabIndex = 13;
            btClear.Text = "Очистить";
            btClear.UseVisualStyleBackColor = true;
            btClear.Click += button1_Click;
            // 
            // edGo
            // 
            edGo.DecimalPlaces = 4;
            edGo.Location = new Point(571, 29);
            edGo.Name = "edGo";
            edGo.Size = new Size(83, 27);
            edGo.TabIndex = 12;
            edGo.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(594, 5);
            label6.Name = "label6";
            label6.Size = new Size(37, 20);
            label6.TabIndex = 11;
            label6.Text = "Шаг";
            // 
            // btStart
            // 
            btStart.Location = new Point(686, 27);
            btStart.Name = "btStart";
            btStart.Size = new Size(94, 29);
            btStart.TabIndex = 10;
            btStart.Text = "Пуск";
            btStart.UseVisualStyleBackColor = true;
            btStart.Click += btStart_Click;
            // 
            // edMass
            // 
            edMass.DecimalPlaces = 1;
            edMass.Location = new Point(462, 29);
            edMass.Name = "edMass";
            edMass.Size = new Size(83, 27);
            edMass.TabIndex = 9;
            edMass.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(485, 5);
            label5.Name = "label5";
            label5.Size = new Size(33, 20);
            label5.TabIndex = 8;
            label5.Text = "Вес";
            // 
            // edSize
            // 
            edSize.DecimalPlaces = 1;
            edSize.Location = new Point(349, 29);
            edSize.Name = "edSize";
            edSize.Size = new Size(83, 27);
            edSize.TabIndex = 7;
            edSize.Value = new decimal(new int[] { 1, 0, 0, 65536 });
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(359, 5);
            label4.Name = "label4";
            label4.Size = new Size(60, 20);
            label4.TabIndex = 6;
            label4.Text = "Размер";
            // 
            // edSpeed
            // 
            edSpeed.DecimalPlaces = 1;
            edSpeed.Location = new Point(238, 29);
            edSpeed.Name = "edSpeed";
            edSpeed.Size = new Size(83, 27);
            edSpeed.TabIndex = 5;
            edSpeed.Value = new decimal(new int[] { 78, 0, 0, 65536 });
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(248, 5);
            label3.Name = "label3";
            label3.Size = new Size(73, 20);
            label3.TabIndex = 4;
            label3.Text = "Скорость";
            // 
            // edAngle
            // 
            edAngle.DecimalPlaces = 1;
            edAngle.Location = new Point(128, 29);
            edAngle.Name = "edAngle";
            edAngle.Size = new Size(83, 27);
            edAngle.TabIndex = 3;
            edAngle.Value = new decimal(new int[] { 356, 0, 0, 65536 });
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(147, 6);
            label2.Name = "label2";
            label2.Size = new Size(41, 20);
            label2.TabIndex = 2;
            label2.Text = "Угол";
            // 
            // edHeight
            // 
            edHeight.DecimalPlaces = 1;
            edHeight.Location = new Point(12, 29);
            edHeight.Name = "edHeight";
            edHeight.Size = new Size(83, 27);
            edHeight.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(22, 5);
            label1.Name = "label1";
            label1.Size = new Size(59, 20);
            label1.TabIndex = 0;
            label1.Text = "Высота";
            // 
            // chart1
            // 
            chartArea2.Name = "ChartArea1";
            chart1.ChartAreas.Add(chartArea2);
            chart1.Location = new Point(0, 74);
            chart1.Name = "chart1";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series2.Name = "Series1";
            chart1.Series.Add(series2);
            chart1.Size = new Size(1166, 494);
            chart1.TabIndex = 1;
            chart1.Text = "chart1";
            // 
            // timer1
            // 
            timer1.Interval = 10;
            timer1.Tick += timer1_Tick;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(0, 574);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1166, 129);
            dataGridView1.TabIndex = 2;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1166, 715);
            Controls.Add(dataGridView1);
            Controls.Add(chart1);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "Form1";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)edGo).EndInit();
            ((System.ComponentModel.ISupportInitialize)edMass).EndInit();
            ((System.ComponentModel.ISupportInitialize)edSize).EndInit();
            ((System.ComponentModel.ISupportInitialize)edSpeed).EndInit();
            ((System.ComponentModel.ISupportInitialize)edAngle).EndInit();
            ((System.ComponentModel.ISupportInitialize)edHeight).EndInit();
            ((System.ComponentModel.ISupportInitialize)chart1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private NumericUpDown edMass;
        private Label label5;
        private NumericUpDown edSize;
        private Label label4;
        private NumericUpDown edSpeed;
        private Label label3;
        private NumericUpDown edAngle;
        private Label label2;
        private NumericUpDown edHeight;
        private Label label1;
        private Button btStart;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Timer timer1;
        private NumericUpDown edGo;
        private Label label6;
        private DataGridView dataGridView1;
        private Button btClear;
        private Button btStop;
        private Button btExit;
    }
}
