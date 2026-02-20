using System.Diagnostics;

namespace Лаба2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitializeDataGridView();
        }

        double ro = 19300;
        double c = 130;
        double lam = 317;
        double modelTime = 2.0;

        double[] timeSteps = { 0.1, 0.01, 0.001, 0.0001 };
        double[] spaceSteps = { 0.1, 0.01, 0.001, 0.0001 };

        private void InitializeDataGridView()
        {
            dataGridView1.ColumnCount = 5;
            dataGridView1.Columns[0].Name = "Шаг по пространству, м / Шаг по времени, с";
            dataGridView1.Columns[1].Name = "0,1";
            dataGridView1.Columns[2].Name = "0,01";
            dataGridView1.Columns[3].Name = "0,001";
            dataGridView1.Columns[4].Name = "0,0001";

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.RowHeadersVisible = false;

            dataGridView1.Rows.Clear();

            foreach (double h in spaceSteps)
            {
                dataGridView1.Rows.Add(h.ToString());
            }
        }

        private void btCount_Click(object sender, EventArgs e)
        {
            double L = (double)edLenght.Value;
            double t_left = (double)edLeft.Value;
            double t_right = (double)edRight.Value;
            double t0 = (double)edTemp.Value;

            if (L <= 0 || t_left < 0 || t_right < 0 || t0 < 0)
            {
                MessageBox.Show("Проверьте корректность введенных данных!");
                return;
            }


            for (int i = 0; i < spaceSteps.Length; i++)
            {
                for (int j = 1; j <= timeSteps.Length; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Value = "";
                }
            }

            for (int i = 0; i < spaceSteps.Length; i++)
            {
                double h = spaceSteps[i];

                for (int j = 0; j < timeSteps.Length; j++)
                {
                    double tau = timeSteps[j];

                    double temperature = Equation(h, tau, L, t_left, t_right, t0);
                    dataGridView1.Rows[i].Cells[j + 1].Value = temperature.ToString("F4");

                    Application.DoEvents();
                }
            }

            MessageBox.Show("Моделирование завершено!");
        }

        private double Equation(double h, double tau, double L, double t_left, double t_right, double t0)
        {
            int n = (int)(L / h) + 1;
            int nt = (int)(modelTime / tau);
            if (n < 3 || nt < 1)
            {
                return double.NaN;
            }
            double[] T_current = new double[n];
            double[] T_next = new double[n];
            double[] alpha = new double[n];
            double[] beta = new double[n];

            for (int i = 0; i < n; i++)
            {
                T_current[i] = t0;
            }

            double A = lam / (h * h);
            double C = lam / (h * h);
            double B = (2 * lam) / (h * h) + (ro * c) / tau;

            int centerIndex = n / 2;

            for (int step = 0; step < nt; step++)
            {
                alpha[0] = 0;
                beta[0] = t_left;

                for (int i = 1; i < n - 1; i++)
                {
                    double d = B - C * alpha[i - 1];
                    if (Math.Abs(d) < 1e-15)
                    {
                        d = 1e-15;
                    }

                    alpha[i] = A / d;
                    beta[i] = (C * beta[i - 1] + (ro * c / tau) * T_current[i]) / d;
                }

                T_next[n - 1] = t_right;

                for (int i = n - 2; i >= 0; i--)
                {
                    T_next[i] = alpha[i] * T_next[i + 1] + beta[i];
                }
                T_next[0] = t_left;
                Array.Copy(T_next, T_current, n);
            }

            return T_current[centerIndex];

        }

        private void btClean_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 1; j < dataGridView1.Columns.Count; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Value = "";
                }
            }
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}