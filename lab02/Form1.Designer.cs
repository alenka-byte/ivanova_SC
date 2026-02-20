namespace Лаба2
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
            dataGridView1 = new DataGridView();
            btCount = new Button();
            btExit = new Button();
            btClean = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            edLeft = new NumericUpDown();
            edRight = new NumericUpDown();
            edLenght = new NumericUpDown();
            label5 = new Label();
            label6 = new Label();
            edTemp = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)edLeft).BeginInit();
            ((System.ComponentModel.ISupportInitialize)edRight).BeginInit();
            ((System.ComponentModel.ISupportInitialize)edLenght).BeginInit();
            ((System.ComponentModel.ISupportInitialize)edTemp).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(28, 243);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(772, 195);
            dataGridView1.TabIndex = 0;
            // 
            // btCount
            // 
            btCount.Location = new Point(516, 55);
            btCount.Name = "btCount";
            btCount.Size = new Size(94, 29);
            btCount.TabIndex = 1;
            btCount.Text = "Вывод";
            btCount.UseVisualStyleBackColor = true;
            btCount.Click += btCount_Click;
            // 
            // btExit
            // 
            btExit.Location = new Point(694, 12);
            btExit.Name = "btExit";
            btExit.Size = new Size(94, 29);
            btExit.TabIndex = 2;
            btExit.Text = "Закрыть";
            btExit.UseVisualStyleBackColor = true;
            btExit.Click += btExit_Click;
            // 
            // btClean
            // 
            btClean.Location = new Point(622, 55);
            btClean.Name = "btClean";
            btClean.Size = new Size(94, 29);
            btClean.TabIndex = 3;
            btClean.Text = "Очистить";
            btClean.UseVisualStyleBackColor = true;
            btClean.Click += btClean_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 57);
            label1.Name = "label1";
            label1.Size = new Size(100, 20);
            label1.TabIndex = 4;
            label1.Text = "Температура";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(142, 57);
            label2.Name = "label2";
            label2.Size = new Size(50, 20);
            label2.TabIndex = 5;
            label2.Text = "Слева";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(141, 4);
            label3.Name = "label3";
            label3.Size = new Size(60, 20);
            label3.TabIndex = 6;
            label3.Text = "Справа";
            // 
            // edLeft
            // 
            edLeft.DecimalPlaces = 1;
            edLeft.Location = new Point(131, 80);
            edLeft.Name = "edLeft";
            edLeft.Size = new Size(85, 27);
            edLeft.TabIndex = 7;
            edLeft.Value = new decimal(new int[] { 20, 0, 0, 0 });
            // 
            // edRight
            // 
            edRight.DecimalPlaces = 1;
            edRight.Location = new Point(131, 27);
            edRight.Name = "edRight";
            edRight.Size = new Size(85, 27);
            edRight.TabIndex = 8;
            edRight.Value = new decimal(new int[] { 100, 0, 0, 0 });
            // 
            // edLenght
            // 
            edLenght.DecimalPlaces = 4;
            edLenght.Location = new Point(260, 27);
            edLenght.Name = "edLenght";
            edLenght.Size = new Size(85, 27);
            edLenght.TabIndex = 12;
            edLenght.Value = new decimal(new int[] { 2, 0, 0, 131072 });
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(231, 4);
            label5.Name = "label5";
            label5.Size = new Size(138, 20);
            label5.TabIndex = 11;
            label5.Text = "Ширина пластины";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(14, 124);
            label6.Name = "label6";
            label6.Size = new Size(171, 20);
            label6.TabIndex = 13;
            label6.Text = "Температура пластины";
            // 
            // edTemp
            // 
            edTemp.DecimalPlaces = 1;
            edTemp.Location = new Point(203, 122);
            edTemp.Name = "edTemp";
            edTemp.Size = new Size(85, 27);
            edTemp.TabIndex = 14;
            edTemp.Value = new decimal(new int[] { 20, 0, 0, 0 });
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(edTemp);
            Controls.Add(label6);
            Controls.Add(edLenght);
            Controls.Add(label5);
            Controls.Add(edRight);
            Controls.Add(edLeft);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btClean);
            Controls.Add(btExit);
            Controls.Add(btCount);
            Controls.Add(dataGridView1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)edLeft).EndInit();
            ((System.ComponentModel.ISupportInitialize)edRight).EndInit();
            ((System.ComponentModel.ISupportInitialize)edLenght).EndInit();
            ((System.ComponentModel.ISupportInitialize)edTemp).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Button btCount;
        private Button btExit;
        private Button btClean;
        private Label label1;
        private Label label2;
        private Label label3;
        private NumericUpDown edLeft;
        private NumericUpDown edRight;
        private NumericUpDown edLenght;
        private Label label5;
        private Label label6;
        private NumericUpDown edTemp;
    }
}
