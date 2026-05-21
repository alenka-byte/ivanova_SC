using static System.Runtime.InteropServices.JavaScript.JSType;

namespace lab8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        Random random = new Random();
        private double Factorial(int n)
        {
            double result = 1;

            for (int i = 2; i <= n; i++)
                result *= i;

            return result;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();
            double T = (double)numericUpDown1.Value;
            double lam = (double)numericUpDown2.Value;
            int n = (int)numericUpDown3.Value;
            int s = 0;
            List<int> x_history = new List<int>();
            for (int exp = 0; exp < n; exp++)
            {
                double t = 0;
                int x = 0;
                while (t < T)
                {
                    double r = random.NextDouble();
                    double dt = -Math.Log(1 - r) / lam;
                    t += dt;
                    if (t <= T)
                        x++;
                    else
                        s += x;
                }
                x_history.Add(x);
            }
            
            int maxReq = x_history.Max();
            int[] counts = new int[maxReq+ 1];
            foreach (int value in x_history)
            {
                counts[value]++;
            }
            double[] probabilities = new double[maxReq + 1];
            for (int i = 0; i <= maxReq; i++)
            {
                probabilities[i] = (double)counts[i] / n;
            }

            chart1.Series[0].Name = "Эмпирическое";
            chart1.Series[1].Name = "Теоретическое";
            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            chart1.Series[0].BorderWidth = 1; 
            chart1.Series[0].Color = System.Drawing.Color.Blue; 
            chart1.Series[0].Name = "Эмпирическое распределение";
            chart1.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Series[1].BorderWidth = 3; 
            chart1.Series[1].Color = System.Drawing.Color.Red; 
            chart1.Series[1].Name = "Теоретическое распределение (экспоненциальное)";
            chart1.ChartAreas[0].AxisX.Title = "Время"; 
            chart1.ChartAreas[0].AxisY.Title = "Плотность вероятности";

            for (int i = 0; i <= maxReq; i++)
            {
                chart1.Series[0].Points.AddXY(i, probabilities[i]);
            }
            double a = lam * T;
            int maxX = x_history.Max();
            for (int k = 0; k <= maxX; k++)
            {
                double p = Math.Pow(a, k) * Math.Exp(-a) / Factorial(k);
                chart1.Series[1].Points.AddXY(k, p);
            }
            double empMean = x_history.Average();
            double sum = 0;
            foreach (int value in x_history)
            {
                double diff = value - empMean;
                sum += diff * diff;
            }
            double empVar = sum / x_history.Count;
            double theorMean = lam * T;
            double theorVar = lam * T;
            listBox1.Items.Add($"Число запросов за время T = {s}");
            listBox1.Items.Add("");
            listBox1.Items.Add("ЭМПИРИЧЕСКИЕ ХАРАКТЕРИСТИКИ");
            listBox1.Items.Add($"Среднее: {empMean:F4}");
            listBox1.Items.Add($"Дисперсия: {empVar:F4}");
            listBox1.Items.Add("");
            listBox1.Items.Add("ТЕОРЕТИЧЕСКИЕ ХАРАКТЕРИСТИКИ");
            listBox1.Items.Add($"M[X] = λT = {theorMean:F4}");
            listBox1.Items.Add($"D[X] = λT = {theorVar:F4}");
        }
    }
}