using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MathNet.Numerics.Distributions;

namespace Lab6
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        Random random = new Random();

        private (double, double) GenerateBoxMullerPair()
        {
            double u1 = random.NextDouble();
            double u2 = random.NextDouble();
            double z1 = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Cos(2.0 * Math.PI * u2);
            double z2 = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2);
            return (z1, z2);
        }

        private double[] GenerateNormalArray(double mean, double variance, int sampleSize)
        {
            double[] results = new double[sampleSize];
            double sigma = Math.Sqrt(variance);
            int index = 0;
            while (index < sampleSize)
            {
                var (z1, z2) = GenerateBoxMullerPair();
                results[index++] = mean + z1 * sigma;
                if (index < sampleSize) results[index++] = mean + z2 * sigma;
            }
            Array.Sort(results);
            return results;
        }

        private double CalculateSampleMean(double[] values)
        {
            return values.Average();
        }

        private double CalculateSampleVariance(double[] values, double mean)
        {
            double sumSquaredDiff = 0;
            for (int i = 0; i < values.Length; i++)
            {
                double diff = values[i] - mean;
                sumSquaredDiff += diff * diff;
            }
            return sumSquaredDiff / (values.Length - 1);
        }

        private int GetOptimalBins(int sampleSize)
        {
            int bins = (int)Math.Ceiling(Math.Log2(sampleSize) + 1);
            return Math.Max(bins, 3); 
        }

        private double[] CreateHistogram(double[] values, out double[] binCenters, out double binWidth)
        {
            double minVal = values[0];
            double maxVal = values[values.Length - 1];

            int numIntervals = GetOptimalBins(values.Length);
            binWidth = (maxVal - minVal) / numIntervals;

            if (binWidth <= 0) binWidth = 1.0;

            binCenters = new double[numIntervals];

            for (int i = 0; i < numIntervals; i++)
            {
                double left = minVal + i * binWidth;
                double right = minVal + (i + 1) * binWidth;
                binCenters[i] = (left + right) / 2;
            }

            int[] counts = new int[numIntervals];
            foreach (double value in values)
            {
                int index = (int)((value - minVal) / binWidth);
                if (index >= numIntervals) index = numIntervals - 1;
                if (index < 0) index = 0;
                counts[index]++;
            }

            double[] densities = new double[numIntervals];
            for (int i = 0; i < numIntervals; i++)
            {
                densities[i] = (double)counts[i] / (values.Length * binWidth);
            }

            return densities;
        }

        private double NormalPDF(double x, double mean, double variance)
        {
            double stdDev = Math.Sqrt(variance);
            return Normal.PDF(mean, stdDev, x);
        }

        private double NormalCDF(double x, double mean, double variance)
        {
            double stdDev = Math.Sqrt(variance);
            return Normal.CDF(mean, stdDev, x);
        }

        private (double chiSquared, int degreesOfFreedom) CalculateChiSquared(double[] values, double mean, double variance)
        {
            double minVal = values[0];
            double maxVal = values[values.Length - 1];

            int numIntervals = GetOptimalBins(values.Length);
            double binWidth = (maxVal - minVal) / numIntervals;
            if (binWidth <= 0) binWidth = 1.0;

            int[] observed = new int[numIntervals];
            foreach (double value in values)
            {
                int index = (int)((value - minVal) / binWidth);
                if (index >= numIntervals) index = numIntervals - 1;
                if (index < 0) index = 0;
                observed[index]++;
            }

            double[] probabilities = new double[numIntervals];
            for (int i = 0; i < numIntervals; i++)
            {
                double left = minVal + i * binWidth;
                double right = minVal + (i + 1) * binWidth;
                probabilities[i] = NormalCDF(right, mean, variance) - NormalCDF(left, mean, variance);
            }

            double[] expected = new double[numIntervals];
            for (int i = 0; i < numIntervals; i++)
            {
                expected[i] = values.Length * probabilities[i];
            }

            var observedMerged = new List<int>();
            var expectedMerged = new List<double>();

            int currentObserved = 0;
            double currentExpected = 0;

            for (int i = 0; i < numIntervals; i++)
            {
                currentObserved += observed[i];
                currentExpected += expected[i];

                if (currentExpected >= 5.0 || i == numIntervals - 1)
                {
                    observedMerged.Add(currentObserved);
                    expectedMerged.Add(currentExpected);
                    currentObserved = 0;
                    currentExpected = 0;
                }
            }

            double chiSquared = 0;
            for (int i = 0; i < observedMerged.Count; i++)
            {
                if (expectedMerged[i] > 0)
                {
                    chiSquared += (observedMerged[i] * observedMerged[i]) / expectedMerged[i];
                }
            }
            chiSquared -= values.Length;

            int degreesOfFreedom = observedMerged.Count - 1;
            if (degreesOfFreedom < 1) degreesOfFreedom = 1;

            return (chiSquared, degreesOfFreedom);
        }

        private double GetCriticalChiSquared(int degreesOfFreedom)
        {
            double[] criticalValues = { 0, 3.841, 5.991, 7.815, 9.488, 11.070, 12.592, 14.067, 15.507, 16.919,
                                        18.307, 19.675, 21.026, 22.362, 23.685, 24.996, 26.296, 27.587, 28.869, 30.144 };
            if (degreesOfFreedom < criticalValues.Length)
                return criticalValues[degreesOfFreedom];
            else
                return degreesOfFreedom + 2 * Math.Sqrt(2 * degreesOfFreedom) + 1.64;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double mean = (double)numericUpDown1.Value;
            double variance = (double)numericUpDown2.Value;
            int N = (int)numericUpDown3.Value;

            chart1.Series.Clear();
            listBox1.Items.Clear();

            double[] generatedValues = GenerateNormalArray(mean, variance, N);

            double sampleMean = CalculateSampleMean(generatedValues);
            double sampleVariance = CalculateSampleVariance(generatedValues, sampleMean);

            double relativeErrorMean = (Math.Abs(sampleMean - mean) / Math.Abs(mean)) * 100;
            double relativeErrorVariance = (Math.Abs(sampleVariance - variance) / variance) * 100;

            listBox1.Items.Add("ВЫБОРОЧНЫЕ ХАРАКТЕРИСТИКИ:");
            listBox1.Items.Add($"  Выборочное среднее X̄ = {sampleMean:F6}");
            listBox1.Items.Add($"  Выборочная дисперсия S² = {sampleVariance:F6}");
            listBox1.Items.Add("");
            listBox1.Items.Add("ОТНОСИТЕЛЬНЫЕ ПОГРЕШНОСТИ:");
            listBox1.Items.Add($"  Относительная погрешность среднего: {relativeErrorMean:F4}%");
            listBox1.Items.Add($"  Относительная погрешность дисперсии: {relativeErrorVariance:F4}%");
            listBox1.Items.Add("");

            var (chiSquared, degreesOfFreedom) = CalculateChiSquared(generatedValues, mean, variance);
            double criticalChiSquared = GetCriticalChiSquared(degreesOfFreedom);
            string chiSquaredConclusion = chiSquared <= criticalChiSquared ? "ПРИНИМАЕТСЯ" : "ОТВЕРГАЕТСЯ";

            listBox1.Items.Add("КРИТЕРИЙ ХИ-КВАДРАТ (χ²):");
            listBox1.Items.Add($"  Статистика χ² = {chiSquared:F4}");
            listBox1.Items.Add($"  Число степеней свободы: {degreesOfFreedom}");
            listBox1.Items.Add($"  Критическое значение χ²_крит = {criticalChiSquared:F4}");
            listBox1.Items.Add($"  Уровень значимости α = 0.05");
            listBox1.Items.Add($"  Нулевая гипотеза (о нормальности распределения): {chiSquaredConclusion}");
            listBox1.Items.Add("");

            double[] binCenters;
            double binWidth;
            double[] densities = CreateHistogram(generatedValues, out binCenters, out binWidth);

            // Гистограмма плотности
            System.Windows.Forms.DataVisualization.Charting.Series histogramSeries =
                new System.Windows.Forms.DataVisualization.Charting.Series("Эмпирическая плотность");
            histogramSeries.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            histogramSeries.Color = Color.FromArgb(100, 65, 140, 240);
            histogramSeries.BorderWidth = 1;
            histogramSeries.BorderColor = Color.Blue;

            for (int i = 0; i < densities.Length; i++)
            {
                histogramSeries.Points.AddXY(binCenters[i], densities[i]);
            }
            chart1.Series.Add(histogramSeries);

            // Теоретическая плотность
            System.Windows.Forms.DataVisualization.Charting.Series theoreticalSeries =
                new System.Windows.Forms.DataVisualization.Charting.Series("Теоретическая плотность");
            theoreticalSeries.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            theoreticalSeries.Color = Color.Red;
            theoreticalSeries.BorderWidth = 3;

            double xMin = generatedValues.Min() - 1;
            double xMax = generatedValues.Max() + 1;
            int points = 100;
            for (int i = 0; i <= points; i++)
            {
                double x = xMin + (xMax - xMin) * i / points;
                double pdf = NormalPDF(x, mean, variance);
                theoreticalSeries.Points.AddXY(x, pdf);
            }
            chart1.Series.Add(theoreticalSeries);

            chart1.ChartAreas[0].AxisX.Title = "Значение случайной величины X";
            chart1.ChartAreas[0].AxisY.Title = "f(x)";
            chart1.ChartAreas[0].AxisY.Minimum = 0;
            chart1.ChartAreas[0].AxisX.LabelStyle.Format = "F3";
            chart1.ChartAreas[0].AxisY.LabelStyle.Format = "F3";

            // Автоматический подбор максимума оси Y для лучшего отображения
            double maxDensity = densities.Length > 0 ? densities.Max() : 0;
            double maxPDF = 0;
            for (double x = xMin; x <= xMax; x += (xMax - xMin) / points)
            {
                double pdf = NormalPDF(x, mean, variance);
                if (pdf > maxPDF) maxPDF = pdf;
            }
            chart1.ChartAreas[0].AxisY.Maximum = Math.Max(maxDensity, maxPDF) * 1.2;

            chart1.Titles.Clear();
            var title = new System.Windows.Forms.DataVisualization.Charting.Title();
            title.Text = $"Сравнение эмпирической и теоретической плотности нормального распределения (N={N})\n";
            title.Font = new Font("Arial", 9, FontStyle.Regular);
            title.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            chart1.Titles.Add(title);

            chart1.Legends[0].Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            chart1.Legends[0].Alignment = StringAlignment.Center;
        }
    }
}