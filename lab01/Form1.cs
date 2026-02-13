using System.Windows.Forms.DataVisualization.Charting;

namespace Лаба1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitializeDataGridView();
        }
        const double g = 9.81;
        double y0, x, y, v0, alpha, sina, cosa, t, s, m, k, vx, vy, vx_new, vy_new, dt;
        double maxHeight = 0; double maxDistance = 0; double finalSpeed = 0;
        double timeOfFlight = 0;

        private void InitializeDataGridView()
        {
            dataGridView1.ColumnCount = 5;
            dataGridView1.Columns[0].Name = "Шаг";
            dataGridView1.Columns[1].Name = "Дальность (м)";
            dataGridView1.Columns[2].Name = "Макс. высота (м)";
            dataGridView1.Columns[3].Name = "Конечная скорость (м/с)";
            dataGridView1.Columns[4].Name = "Время полета (с)";

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void btStart_Click(object sender, EventArgs e)
        {
            y0 = (double)edHeight.Value;
            alpha = (double)edAngle.Value;
            sina = Math.Sin(alpha * Math.PI / 180);
            cosa = Math.Cos(alpha * Math.PI / 180);
            v0 = (double)edSpeed.Value;
            s = (double)edSize.Value;
            m = (double)edMass.Value;
            dt = (double)edGo.Value;
            t = 0; x = 0; y = y0;
            vx_new = v0 * cosa; vy_new = v0 * sina;

            k = 0.15 * s * 1.29 / (2 * m);
            maxHeight = 0; 
            maxDistance = 0;
            string seriesName = $"Траектория {chart1.Series.Count + 1}";
            Series newSeries = new Series(seriesName);
            newSeries.ChartType = SeriesChartType.Line;
            newSeries.BorderWidth = 2;
            newSeries.Color = GetNextColor();
            chart1.Series.Add(newSeries);
            newSeries.Points.AddXY(x, y);

            timer1.Start();
        }
        private Color GetNextColor()
        {
            Color[] colors = { Color.Blue, Color.Red, Color.Green, Color.Orange, Color.Purple };
            return colors[(chart1.Series.Count - 1) % colors.Length];
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            t = t + dt;
            vx = vx_new; vy = vy_new;
            double v = Math.Sqrt(vx * vx + vy * vy);
            vx_new = vx - k * vx * v * dt;
            vy_new = vy - (g + k * vy * v) * dt;
            x = x + vx_new * dt;
            y = y + vy_new * dt;
            chart1.Series[chart1.Series.Count - 1].Points.AddXY(x, y);
            if (y > maxHeight)
            {
                maxHeight = y;
            }
            if (y <= 0)
            {
                timer1.Stop();
                timeOfFlight = t;
                finalSpeed = Math.Sqrt(vx_new * vx_new + vy_new * vy_new);
                maxDistance = x;
                AddResultToTable();
            }
        }
        private void AddResultToTable()
        {
            dataGridView1.Rows.Add(
                dt.ToString("F4"),
                maxDistance.ToString("F2"),
                maxHeight.ToString("F2"),
                finalSpeed.ToString("F2"),
                timeOfFlight.ToString("F2")
            );
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            while (chart1.Series.Count > 1)
            {
                chart1.Series.RemoveAt(chart1.Series.Count - 1);
            }
            chart1.Series[0].Points.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled)
            {
                timer1.Stop();
                if (t > 0)
                {
                    timeOfFlight = t;
                    finalSpeed = Math.Sqrt(vx_new * vx_new + vy_new * vy_new);
                    maxDistance = x;

                    AddResultToTable();
                }
            }      
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
