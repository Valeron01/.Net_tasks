using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            float[][] matrix = ParseMatrix(richTextBox1.Text);

            int a = -1;
            int b = -1;

            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if(a == -1 && matrix[i][j] < 0)
                    {
                        a = i;
                    }
                    if(b == -1 && matrix[i][j] == 0)
                    {
                        b = j;
                    }
                }
            }


            if (a < 0)
            {
                MessageBox.Show("Отсутсвует отрицательный элемент"); // строка
                return;
            }

            if (b < 0)
            {
                MessageBox.Show("Отсутсвует нулевой элемент"); // столбец
                return;
            }

            if (matrix.Length != matrix[0].Length)
            {
                MessageBox.Show("Матрица должна быть квадратной!");
                return;
            }


            float[] column = GetColumn(matrix, b);

            float result = ScalarMultiplication(matrix[a], column);
            
            MessageBox.Show($"Row: ({M2S(matrix[a])}); Column: ({M2S(column)}); Result: {result}");
        }

        private float[][] ParseMatrix(string data)
        {
            float[][] ret;
            string[] rows = data.Split('\n');
            ret = new float[rows.Length][];

            for (int i = 0; i < ret.Length; i++)
            {
                string[] row = rows[i].Split(' ');
                ret[i] = new float[row.Length];

                for (int j = 0; j < row.Length; j++)
                {
                    ret[i][j] = float.Parse(row[j]);
                }
            }

            return ret;
        }

        private float ScalarMultiplication(float[] a, float[] b)
        {
            float sum = 0;
            for (int i = 0; i < a.Length; i++)
            {
                sum += a[i] * b[i];
            }
            return sum;
        }

        private float[] GetColumn(float[][] matrix, int j)
        {
            float[] ret = new float[matrix[0].Length];

            for (int i = 0; i < matrix[0].Length; i++)
            {
                ret[i] = matrix[i][j];
            }
            return ret;
        }

        private string M2S(float[] array)
        {
            string ret = "";
            for (int i = 0; i < array.Length; i++)
            {

                ret += array[i] + (i != array.Length - 1 ? " ":"");
            }
            return ret;
        }

        private float[][] RandomMatrix(int size)
        {
            float[][] matrix = new float[size][];
            Random r = new Random();
            for (int i = 0; i < size; i++)
            {
                matrix[i] = new float[size];
                for (int j = 0; j < size; j++)
                {
                    matrix[i][j] = r.Next(1, 9);
                }
            }

            int x0, y0, x1, y1;

            x0 = r.Next(0, size);
            y0 = r.Next(0, size);
            x1 = r.Next(0, size);
            y1 = r.Next(0, size);

            matrix[x0][y0] = 0;
            matrix[x1][y1] = -1;

            return matrix;
        }
    }
}
