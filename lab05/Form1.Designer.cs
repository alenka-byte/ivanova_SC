namespace Лаба5
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            questionTextBox = new TextBox();
            askButton = new Button();
            button1 = new Button();
            button2 = new Button();
            label2 = new Label();
            magicBallPictureBox = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)magicBallPictureBox).BeginInit();
            SuspendLayout();
            // 
            // questionTextBox
            // 
            questionTextBox.BackColor = Color.White;
            questionTextBox.BorderStyle = BorderStyle.FixedSingle;
            questionTextBox.Font = new Font("Segoe UI", 9F);
            questionTextBox.ForeColor = Color.Gray;
            questionTextBox.Location = new Point(39, 14);
            questionTextBox.Margin = new Padding(3, 4, 3, 4);
            questionTextBox.Name = "questionTextBox";
            questionTextBox.Size = new Size(462, 27);
            questionTextBox.TabIndex = 1;
            questionTextBox.Text = "Введите ваш вопрос...";
            questionTextBox.Enter += QuestionTextBox_Enter;
            questionTextBox.Leave += QuestionTextBox_Leave;
            // 
            // askButton
            // 
            askButton.BackColor = Color.FromArgb(76, 201, 240);
            askButton.FlatStyle = FlatStyle.Flat;
            askButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            askButton.ForeColor = Color.Black;
            askButton.Location = new Point(232, 302);
            askButton.Margin = new Padding(3, 4, 3, 4);
            askButton.Name = "askButton";
            askButton.Size = new Size(229, 40);
            askButton.TabIndex = 2;
            askButton.Text = "Спросить";
            askButton.UseVisualStyleBackColor = false;
            askButton.Click += AskButton_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(76, 201, 240);
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            button1.ForeColor = Color.Black;
            button1.Location = new Point(12, 152);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(114, 40);
            button1.TabIndex = 4;
            button1.Text = "ДА/НЕТ";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(76, 201, 240);
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            button2.ForeColor = Color.Black;
            button2.Location = new Point(12, 480);
            button2.Margin = new Padding(3, 4, 3, 4);
            button2.Name = "button2";
            button2.Size = new Size(114, 40);
            button2.TabIndex = 5;
            button2.Text = "Закрыть";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(50, 196);
            label2.Name = "label2";
            label2.Size = new Size(21, 28);
            label2.TabIndex = 6;
            label2.Text = "?";
            // 
            // magicBallPictureBox
            // 
            magicBallPictureBox.BackColor = Color.NavajoWhite;
            magicBallPictureBox.Cursor = Cursors.Hand;
            magicBallPictureBox.Location = new Point(250, 80);
            magicBallPictureBox.Margin = new Padding(3, 4, 3, 4);
            magicBallPictureBox.Name = "magicBallPictureBox";
            magicBallPictureBox.Size = new Size(370, 360);
            magicBallPictureBox.TabIndex = 0;
            magicBallPictureBox.TabStop = false;
            magicBallPictureBox.Click += MagicBall_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.NavajoWhite;
            ClientSize = new Size(544, 533);
            Controls.Add(label2);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(askButton);
            Controls.Add(questionTextBox);
            Controls.Add(magicBallPictureBox);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Генератор случайных событий";
            ((System.ComponentModel.ISupportInitialize)magicBallPictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.TextBox questionTextBox;
        private System.Windows.Forms.Button askButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private PictureBox magicBallPictureBox;
    }
}