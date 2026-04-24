using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Lab6
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        double p1, p2, p3, p4, p5;
        Random random = new Random();

        private double[] GetTheorProb()
        {
            p1 = (double)numericUpDown1.Value;
            p2 = (double)numericUpDown2.Value;
            p3 = (double)numericUpDown3.Value;
            p4 = (double)numericUpDown4.Value;
            p5 = (double)numericUpDown5.Value;

            double sum = p1 + p2 + p3 + p4 + p5;

            if (sum > 1) {
                MessageBox.Show("Не удовлетворяется условие нормировки. Произведется замена P5");
                p5 = 1 - (p1 + p2 + p3 + p4);
            }
            return new double[] {p1, p2, p3, p4, p5};
        }

        // Генерация одного значения дискретной случайной величины методом преобразования
        private int GenerateVal(double[] prob)
        {
            double ran = random.NextDouble(); 
            double cum = 0;

            for (int i = 0; i < prob.Length; i++)
            {
                cum += prob[i];
                if (ran <= cum)
                    return i + 1; 
            }

            return prob.Length;
        }

        // Генерация массива значений
        private int[] GenerateSam(double[] prob, int N)
        {
            int[] results = new int[N];
            for (int i = 0; i < N; i++)
            {
                results[i] = GenerateVal(prob);
            }
            return results;
        }

        // Вычисление эмпирических вероятностей 
        private double[] CalculateEmpiricalProb(int[] values, int num)
        {
            double[] empirical = new double[num];
            int total = values.Length;

            for (int i = 0; i < num; i++)
            {
                int value = i + 1;
                int frequency = 0;

                foreach (int element in values)
                {
                    if (element == value)
                    {
                        frequency++;
                    }
                }

                empirical[i] = (double)frequency / total;
            }

            return empirical;
        }

        // Вычисление эмпирического среднего (X̄)
        private double CalculateSampleMean(int[] values)
        {
            return values.Average();
        }

        // Вычисление эмпирической дисперсии (S²)
        private double CalculateSampleVar(int[] values)
        {
            double mean = CalculateSampleMean(values);
            double sumSquaredDiff = 0;
            for (int i = 0; i < values.Length; i++)
            {
                double diff = values[i] - mean;
                sumSquaredDiff += diff * diff;
            }
            return sumSquaredDiff / (values.Length - 1); 
        }

        // Вычисление теоретического математического ожидания M[X]
        private double CalculateTheorMean(double[] probabilities)
        {
            double mean = 0;
            for (int i = 0; i < probabilities.Length; i++)
            {
                mean += (i + 1) * probabilities[i];
            }
            return mean;
        }

        // Вычисление теоретической дисперсии D[X]
        private double CalculateTheorVar(double[] probabilities)
        {
            double mean = CalculateTheorMean(probabilities);
            double variance = 0;
            for (int i = 0; i < probabilities.Length; i++)
            {
                variance += Math.Pow((i + 1) - mean, 2) * probabilities[i];
            }
            return variance;
        }

        // Вычисление статистики χ² (хи-квадрат)
        private double CalculateChiSquared(double[] theoreticalProbs, double[] empiricalProbs, int N)
        {
            double chiSquared = 0;
            for (int i = 0; i < theoreticalProbs.Length; i++)
            {
                double expectedFrequency = theoreticalProbs[i] * N;
                double observedFrequency = empiricalProbs[i] * N;
                if (expectedFrequency > 0)
                {
                    chiSquared += Math.Pow(observedFrequency - expectedFrequency, 2) / expectedFrequency;
                }
            }
            return chiSquared;
        }

        // Вычисление критического значения χ² для уровня значимости α = 0.05
        private double GetCriticalChiSquared(int degreesOfFreedom)
        {
            // Табличные значения χ² для уровня значимости 0.05
            double[] criticalValues = { 0, 3.841, 5.991, 7.815, 9.488, 11.070, 12.592, 14.067, 15.507, 16.919 };
            if (degreesOfFreedom < criticalValues.Length)
                return criticalValues[degreesOfFreedom];
            else
                // Приближение для больших степеней свободы
                return degreesOfFreedom + 2 * Math.Sqrt(2 * degreesOfFreedom) + 1.64;
        }

        // Формирование эмпирического ряда распределения
        //private void DisplayEmpiricalDistribution(int[] values, int numValues)
        //{
        //    listBox1.Items.Add("ЭМПИРИЧЕСКИЙ РЯД РАСПРЕДЕЛЕНИЯ:");
        //    for (int i = 0; i < numValues; i++)
        //    {
        //        int frequency = values.Count(v => v == i + 1);
        //        listBox1.Items.Add($"  x{i + 1} = {i + 1}, частота n{i + 1} = {frequency}");
        //    }
        //}

        private void button2_Click(object sender, EventArgs e)
        {
            double[] theoreticalProbs = GetTheorProb();
            int N = (int)numericUpDown6.Value; 

            chart1.Series.Clear();
            listBox1.Items.Clear();

            double theoreticalMean = CalculateTheorMean(theoreticalProbs);
            double theoreticalVariance = CalculateTheorVar(theoreticalProbs);

            listBox1.Items.Add("ТЕОРЕТИЧЕСКИЕ ХАРАКТЕРИСТИКИ:");
            listBox1.Items.Add($"  Математическое ожидание M[X]: {theoreticalMean:F6}");
            listBox1.Items.Add($"  Дисперсия D[X]: {theoreticalVariance:F6}");
            listBox1.Items.Add("");

            int[] generatedValues = GenerateSam(theoreticalProbs, N);
            double[] empiricalProbs = CalculateEmpiricalProb(generatedValues, theoreticalProbs.Length);
            double sampleMean = CalculateSampleMean(generatedValues);
            double sampleVariance = CalculateSampleVar(generatedValues);

            
            double relativeErrorMean = Math.Abs(sampleMean - theoreticalMean) / theoreticalMean * 100;
            double relativeErrorVariance = Math.Abs(sampleVariance - theoreticalVariance) / theoreticalVariance * 100;

            // Эмпирический ряд распределения
            //DisplayEmpiricalDistribution(generatedValues, theoreticalProbs.Length);
            //listBox1.Items.Add("");

            
            listBox1.Items.Add("ЭМПИРИЧЕСКИЕ ВЕРОЯТНОСТИ:");
            for (int i = 0; i < empiricalProbs.Length; i++)
            {
                listBox1.Items.Add($"  P*(X={i + 1}) = {empiricalProbs[i]:F6}");
            }
            listBox1.Items.Add("");
            listBox1.Items.Add("ВЫБОРОЧНЫЕ ХАРАКТЕРИСТИКИ:");
            listBox1.Items.Add($"  Эмпирическое среднее X̄: {sampleMean:F6}");
            listBox1.Items.Add($"  Эмпирическая дисперсия S²: {sampleVariance:F6}");
            listBox1.Items.Add("");
            listBox1.Items.Add("ОТНОСИТЕЛЬНЫЕ ПОГРЕШНОСТИ:");
            listBox1.Items.Add($"  Относительная погрешность среднего: {relativeErrorMean:F4}%");
            listBox1.Items.Add($"  Относительная погрешность дисперсии: {relativeErrorVariance:F4}%");
            listBox1.Items.Add("");

            // Критерий хи-квадрат
            double chiSquared = CalculateChiSquared(theoreticalProbs, empiricalProbs, N);
            int degreesOfFreedom = theoreticalProbs.Length - 1;
            double criticalChiSquared = GetCriticalChiSquared(degreesOfFreedom);
            string chiSquaredConclusion = chiSquared <= criticalChiSquared ? "ПРИНИМАЕТСЯ" : "ОТВЕРГАЕТСЯ";

            listBox1.Items.Add("КРИТЕРИЙ ХИ-КВАДРАТ (χ²):");
            listBox1.Items.Add($"  Число степеней свободы: {degreesOfFreedom}");
            listBox1.Items.Add($"  Уровень значимости α = 0.05");
            listBox1.Items.Add($"  Статистика χ² = {chiSquared:F4}");
            listBox1.Items.Add($"  Критическое значение χ²_крит = {criticalChiSquared:F4}");
            listBox1.Items.Add($"  Нулевая гипотеза (о соответствии распределений): {chiSquaredConclusion}");
            listBox1.Items.Add("");

            // Построение графика
            System.Windows.Forms.DataVisualization.Charting.Series theoreticalSeries =
                new System.Windows.Forms.DataVisualization.Charting.Series("Теоретические вероятности P(X)");
            theoreticalSeries.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            theoreticalSeries.Color = Color.Blue;
            theoreticalSeries.BorderWidth = 1;
            theoreticalSeries.BorderColor = Color.DarkBlue;

            for (int i = 0; i < theoreticalProbs.Length; i++)
            {
                theoreticalSeries.Points.AddXY(i + 1, theoreticalProbs[i]);
            }
            chart1.Series.Add(theoreticalSeries);

            System.Windows.Forms.DataVisualization.Charting.Series empiricalSeries =
                new System.Windows.Forms.DataVisualization.Charting.Series($"Эмпирические вероятности P*(X) (N={N})");
            empiricalSeries.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            empiricalSeries.Color = Color.Red;
            empiricalSeries.BorderWidth = 3;
            empiricalSeries.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            empiricalSeries.MarkerSize = 8;
            empiricalSeries.MarkerColor = Color.DarkRed;

            for (int i = 0; i < empiricalProbs.Length; i++)
            {
                empiricalSeries.Points.AddXY(i + 1, empiricalProbs[i]);
            }
            chart1.Series.Add(empiricalSeries);

            // Настройка осей графика
            chart1.ChartAreas[0].AxisX.Title = "Значения X";
            chart1.ChartAreas[0].AxisY.Title = "P(X)";
            chart1.ChartAreas[0].AxisY.Minimum = 0;
            chart1.ChartAreas[0].AxisY.Maximum = Math.Max(theoreticalProbs.Max(), empiricalProbs.Max()) * 1.2;
            chart1.ChartAreas[0].AxisX.Minimum = 0.5;
            chart1.ChartAreas[0].AxisX.Maximum = theoreticalProbs.Length + 0.5;
            chart1.ChartAreas[0].AxisX.Interval = 1;
            chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = true;
            chart1.ChartAreas[0].AxisY.MajorGrid.Enabled = true;

            // Настройка легенды
            chart1.Legends[0].Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            chart1.Legends[0].Alignment = System.Drawing.StringAlignment.Center;

            // Заголовок графика
            chart1.Titles.Clear();
            var title = new System.Windows.Forms.DataVisualization.Charting.Title();
            title.Text = $"Сравнение теоретического и эмпирического распределений (объем выборки N = {N})\n";
            title.Font = new Font("Arial", 10, FontStyle.Regular);
            title.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            chart1.Titles.Add(title);
        }
    }
}