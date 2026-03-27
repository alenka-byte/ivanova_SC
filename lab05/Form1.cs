using System;
using System.Drawing;
using System.Windows.Forms;

namespace Лаба5
{
    public partial class Form1 : Form
    {
        private Random random = new Random();
        private (string Text, double Probability)[] magicAnswers = new[]
        {
            ("ДА", 0.125),
            ("НЕТ", 0.125),
            ("СКОРЕЕ ВСЕГО", 0.125),
            ("СОМНИТЕЛЬНО", 0.125),
            ("БЕЗ СОМНЕНИЙ", 0.125),
            ("СПРОСИ ПОЗЖЕ", 0.125),
            ("ОПРЕДЕЛЕННО ДА", 0.125),
            ("МАЛОВЕРОЯТНО", 0.125)
        };

        private string currentResult = "";

        public Form1()
        {
            InitializeComponent();
            DrawMagicBall();
        }

        private string GetPrediction((string Text, double Probability)[] answers)
        {
            double A = random.NextDouble();
            int k = 0;

            while (true)
            {
                A -= answers[k].Probability;
                if (A <= 0)
                    return answers[k].Text;
                k++;
                if (k >= answers.Length)
                    return answers[answers.Length - 1].Text;
            }
        }

        private void DrawMagicBall()
        {
            if (magicBallPictureBox == null) return;

            Bitmap bmp = new Bitmap(210, 210);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                PointF center = new PointF(105, 105);
                float radius = 100;

                // Заливка шара одним цветом (синий)
                using (SolidBrush brush = new SolidBrush(Color.FromArgb(76, 201, 240)))
                {
                    g.FillEllipse(brush, center.X - radius, center.Y - radius, radius * 2, radius * 2);
                }

                // Черная обводка шара
                using (Pen pen = new Pen(Color.Black, 3))
                {
                    g.DrawEllipse(pen, center.X - radius, center.Y - radius, radius * 2, radius * 2);
                }

                // Шестиугольник (темно-синий)
                PointF[] hexPoints = new PointF[6];
                float hexRadius = 75;
                for (int i = 0; i < 6; i++)
                {
                    double rad = Math.PI / 180 * (60 * i - 30);
                    float x = center.X + hexRadius * (float)Math.Cos(rad);
                    float y = center.Y + hexRadius * (float)Math.Sin(rad);
                    hexPoints[i] = new PointF(x, y);
                }

                using (SolidBrush brush = new SolidBrush(Color.FromArgb(4, 46, 73)))
                {
                    g.FillPolygon(brush, hexPoints);
                }

                // Обводка шестиугольника (черная)
                using (Pen pen = new Pen(Color.Black, 1.5f))
                {
                    g.DrawPolygon(pen, hexPoints);
                }

                // Текст предсказания
                if (!string.IsNullOrEmpty(currentResult))
                {
                    using (Font font = new Font("Segoe UI", 8, FontStyle.Bold))
                    {
                        string line1 = currentResult.Length > 15 ? currentResult.Substring(0, currentResult.Length / 2) : currentResult;
                        string line2 = currentResult.Length > 15 ? currentResult.Substring(currentResult.Length / 2) : "";

                        SizeF textSize1 = g.MeasureString(line1, font);
                        PointF textPoint1 = new PointF(center.X - textSize1.Width / 2,
                                                       center.Y - (string.IsNullOrEmpty(line2) ? 10 : 15));

                        using (SolidBrush brush = new SolidBrush(Color.White))
                        {
                            g.DrawString(line1, font, brush, textPoint1);

                            if (!string.IsNullOrEmpty(line2))
                            {
                                SizeF textSize2 = g.MeasureString(line2, font);
                                PointF textPoint2 = new PointF(center.X - textSize2.Width / 2, center.Y + 5);
                                g.DrawString(line2, font, brush, textPoint2);
                            }
                        }
                    }
                }
            }

            magicBallPictureBox.Image?.Dispose();
            magicBallPictureBox.Image = bmp;
        }

        private void UpdateResult()
        {
            currentResult = GetPrediction(magicAnswers);
            DrawMagicBall();
        }

        private void MagicBall_Click(object sender, EventArgs e)
        {
            UpdateResult();
        }

        private void AskButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(questionTextBox.Text) ||
                questionTextBox.Text == "Введите ваш вопрос...")
            {
                MessageBox.Show("Пожалуйста, введите вопрос!");
                return;
            }
            UpdateResult();
        }

        private void QuestionTextBox_Enter(object sender, EventArgs e)
        {
            if (questionTextBox.Text == "Введите ваш вопрос...")
            {
                questionTextBox.Text = "";
                questionTextBox.ForeColor = Color.Black;
            }
        }

        private void QuestionTextBox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(questionTextBox.Text))
            {
                questionTextBox.Text = "Введите ваш вопрос...";
                questionTextBox.ForeColor = Color.Gray;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double alfa = random.NextDouble();
            double p = 0.5;
            if (alfa < p)
                label2.Text = "НЕТ";
            else
                label2.Text = "ДА";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}