using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1
{
    public partial class Form3 : Form
    {

        const int MaxN = 4; // максимально допустимая размерность матрицы
        Form4 form4 = null;   // экземпляр (объект) класса формы Form2

        public Form3()
        {
            InitializeComponent();
        }

        private void ShowAndClean()
        {
            form4.ShowDialog();
            form4.dataGridView1.Rows.Clear();
            form4.dataGridView1.Columns.Clear();
            form4.dataGridView2.Rows.Clear();
            form4.dataGridView2.Columns.Clear();
            form4.dataGridView3.Rows.Clear();
            form4.dataGridView3.Columns.Clear();
            form4.dataGridView1.Visible = false;
            form4.dataGridView2.Visible = false;
            form4.dataGridView3.Visible = false;
            form4.label3.Visible = false;
        }

        /// <summary>
        /// Умножение Матрицы на скаляр
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text == "")||(textBox2.Text == "")||(textBox3.Text == ""))
            {
                MessageBox.Show("Введите число строк и столбцов и константу");
                return;
            }
            //Число строк
            int n = int.Parse(textBox1.Text);
            //Число столбцов
            int m = int.Parse(textBox2.Text);
            if ((n > MaxN) || (m > MaxN))
            {
                MessageBox.Show("Число строк и столбцов должно быть меньше или равно 4");
                return;
            }
            //Константа
            double constant = Convert.ToDouble(textBox3.Text);
            form4.dataGridView1.Visible = true;
            form4.dataGridView2.Visible = true;
            form4.label2.Text = "Матрица";
            Random rand = new Random();
            string[,] matrix = new string[MaxN, MaxN];
            for (int i = 0; i < m; i++)
            {
                form4.dataGridView1.Columns.Add("", i.ToString());
                form4.dataGridView2.Columns.Add("", i.ToString());
            }
            for (int i = 0; i < n; i++)
            {
                form4.dataGridView1.Rows.Add("");
                form4.dataGridView2.Rows.Add("");
            }
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = (Math.Round(100*rand.NextDouble(),2)).ToString();
                }
            }
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    form4.dataGridView1.Rows[j].Cells[i].Value = matrix[i, j];
                    form4.dataGridView2.Rows[j].Cells[i].Value = (constant * Convert.ToDouble(matrix[i, j])).ToString();
                }
            }
            ShowAndClean();
        }

        /// <summary>
        /// Модуль вектора
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "") 
            {
                MessageBox.Show("Введите число строк");
                return;
            }
            //Число строк
            int n = int.Parse(textBox1.Text);
            if (n > MaxN)
            {
                MessageBox.Show("Число строк должно быть меньше или равно 4");
                return;
            }
            form4.dataGridView1.Visible = true;
            form4.dataGridView2.Visible = true;
            form4.label2.Text = "Вектор";
            Random rand = new Random();
            string[,] vector = new string[MaxN, MaxN];
            form4.dataGridView1.Columns.Add("", 0.ToString());
            form4.dataGridView2.Columns.Add("", 0.ToString());
            form4.dataGridView2.Rows.Add("");
            double value = 0;
            for (int i = 0; i < n; i++)
            {
                form4.dataGridView1.Rows.Add(""); 
                vector[0, i] = (rand.Next(0, 10)).ToString();
                form4.dataGridView1.Rows[i].Cells[0].Value = vector[0, i];
                value = value + int.Parse(vector[0, i]) * int.Parse(vector[0, i]);
            }   
            form4.dataGridView2.Rows[0].Cells[0].Value = Math.Round(Math.Sqrt(value),2).ToString();
            ShowAndClean();
        }

        /// <summary>
        /// Скалярное произведение векторов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Введите число строк");
                return;
            }
            //Число строк
            int n = int.Parse(textBox1.Text);
            if (n > MaxN)
            {
                MessageBox.Show("Число строк должно быть меньше или равно 4");
                return;
            }
            form4.dataGridView1.Visible = true;
            form4.dataGridView2.Visible = true;
            form4.dataGridView3.Visible = true;
            form4.label2.Text = "Вектор";
            form4.label3.Visible = true;
            Random rand = new Random();
            string[,] vector1 = new string[MaxN, MaxN];
            string[,] vector2 = new string[MaxN, MaxN];
            form4.dataGridView1.Columns.Add("", 0.ToString());
            form4.dataGridView2.Columns.Add("", 0.ToString());
            form4.dataGridView3.Columns.Add("", 0.ToString());
            form4.dataGridView2.Rows.Add("");
            double value = 0;
            for (int i = 0; i < n; i++)
            {
                form4.dataGridView1.Rows.Add("");
                form4.dataGridView3.Rows.Add("");
                vector1[0, i] = (rand.Next(0, 10)).ToString();
                vector2[0, i] = (rand.Next(0, 10)).ToString();
                form4.dataGridView1.Rows[i].Cells[0].Value = vector1[0, i];
                form4.dataGridView3.Rows[i].Cells[0].Value = vector2[0, i];
                value = value + int.Parse(vector1[0, i]) * int.Parse(vector2[0, i]);
            }
            form4.dataGridView2.Rows[0].Cells[0].Value = value.ToString();
            ShowAndClean();
        }

        /// <summary>
        /// Векторное произведение векторов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text == "")||(textBox4.Text == ""))
            {
                MessageBox.Show("Введите число строк и угол в градусах");
                return;
            }
            //Число строк
            int n = int.Parse(textBox1.Text);
            if (n > MaxN)
            {
                MessageBox.Show("Число строк должно быть меньше или равно 4");
                return;
            }
            double sin = Convert.ToDouble(textBox4.Text);
            form4.dataGridView1.Visible = true;
            form4.dataGridView2.Visible = true;
            form4.dataGridView3.Visible = true;
            form4.label2.Text = "Вектор";
            form4.label3.Visible = true;
            Random rand = new Random();
            string[,] vector1 = new string[MaxN, MaxN];
            string[,] vector2 = new string[MaxN, MaxN];
            form4.dataGridView1.Columns.Add("", 0.ToString());
            form4.dataGridView2.Columns.Add("", 0.ToString());
            form4.dataGridView3.Columns.Add("", 0.ToString());
            form4.dataGridView2.Rows.Add("");
            double value1 = 0;
            double value2 = 0;
            for (int i = 0; i < n; i++)
            {
                form4.dataGridView1.Rows.Add("");
                form4.dataGridView3.Rows.Add("");
                vector1[0, i] = (rand.Next(0, 10)).ToString();
                vector2[0, i] = (rand.Next(0, 10)).ToString();
                form4.dataGridView1.Rows[i].Cells[0].Value = vector1[0, i];
                form4.dataGridView3.Rows[i].Cells[0].Value = vector2[0, i];
                value1 = value1 + int.Parse(vector1[0, i]) * int.Parse(vector1[0, i]);
                value2 = value2 + int.Parse(vector2[0, i]) * int.Parse(vector2[0, i]);
            }
            double result = Math.Round(Math.Sqrt(value1), 2) * Math.Round(Math.Sqrt(value2), 2) * Math.Sin(sin * Math.PI / 180);
            form4.dataGridView2.Rows[0].Cells[0].Value = result.ToString();
            ShowAndClean();
        }

        /// <summary>
        /// Транспонирование матрицы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text == "") || (textBox2.Text == ""))
            {
                MessageBox.Show("Введите число строк и столбцов");
                return;
            }
            //Число строк
            int n = int.Parse(textBox1.Text);
            //Число столбцов
            int m = int.Parse(textBox2.Text);
            if ((n > MaxN)||(m > MaxN))
            {
                MessageBox.Show("Число строк и столбцов должно быть меньше или равно 4");
                return;
            }
            form4.dataGridView1.Visible = true;
            form4.dataGridView2.Visible = true;
            form4.label2.Text = "Матрица";
            Random rand = new Random();
            string[,] matrix = new string[MaxN, MaxN];
            for (int i = 0; i < m; i++)
            {
                form4.dataGridView1.Columns.Add("", i.ToString());
            }
            for (int i = 0; i < n; i++)
            {
                form4.dataGridView1.Rows.Add("");
            }
            for (int i = 0; i < n; i++)
            {
                form4.dataGridView2.Columns.Add("", i.ToString());
            }
            for (int i = 0; i < m; i++)
            {
                form4.dataGridView2.Rows.Add("");
            }
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = (Math.Round(100 * rand.NextDouble(), 2)).ToString();
                }
            }
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    form4.dataGridView1.Rows[j].Cells[i].Value = matrix[i, j];
                    form4.dataGridView2.Rows[i].Cells[j].Value = matrix[i, j];
                }
            }
            ShowAndClean();
        }

        /// <summary>
        /// Умножение матрицы на вектор
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text == "") || (textBox2.Text == ""))
            {
                MessageBox.Show("Введите число строк и столбцов, они должны совпадать");
                return;
            }
            int n = int.Parse(textBox1.Text);
            int m = int.Parse(textBox2.Text);
            if ((n > MaxN) || (m > MaxN))
            {
                MessageBox.Show("Число строк и столбцов должно быть меньше или равно 4");
                return;
            }
            if (n!=m)
            {
                MessageBox.Show("Матрица должна быть квадратной");
                return;
            }
            form4.dataGridView1.Visible = true;
            form4.dataGridView2.Visible = true;
            form4.dataGridView3.Visible = true;
            form4.label2.Text = "Матрица";
            form4.label3.Visible = true;
            Random rand = new Random();
            string[,] matrix = new string[MaxN, MaxN];
            string[,] vector = new string[MaxN, MaxN];
            for (int i = 0; i < m; i++)
            {
                form4.dataGridView1.Columns.Add("", i.ToString());
            }
            form4.dataGridView2.Columns.Add("", 0.ToString());
            form4.dataGridView3.Columns.Add("", 0.ToString());
            for (int i = 0; i < n; i++)
            {
                form4.dataGridView1.Rows.Add("");
                form4.dataGridView2.Rows.Add("");
                form4.dataGridView3.Rows.Add("");
            }
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = rand.Next(0,10).ToString();
                }
            }
            for (int j = 0; j < n; j++)
            {
                vector[j,0] = rand.Next(0, 10).ToString();
            }
            double value = 0;
            for (int i = 0; i < m; i++)//столбец
            {
                for (int j = 0; j < n; j++)//строка
                {
                    value = 0;
                    form4.dataGridView1.Rows[j].Cells[i].Value = matrix[i, j];
                    form4.dataGridView3.Rows[j].Cells[0].Value = vector[j,0];
                    for (int k = 0; k < n; k++)
                    {
                        value = value + int.Parse(matrix[k, j]) * int.Parse(vector[k, 0]);
                    }
                    form4.dataGridView2.Rows[j].Cells[0].Value = value.ToString();
                }
            }
            ShowAndClean();            
        }

        /// <summary>
        /// Умножение вектора на скаляр
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button7_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text == "")|| (textBox3.Text == ""))
            {
                MessageBox.Show("Введите число строк и константу");
                return;
            }
            //Число строк
            int n = int.Parse(textBox1.Text);
            if (n > MaxN) 
            {
                MessageBox.Show("Число строк должно быть меньше или равно 4");
                return;
            }
            //Константа
            double constant = Convert.ToDouble(textBox3.Text);
            form4.dataGridView1.Visible = true;
            form4.dataGridView2.Visible = true;
            form4.label2.Text = "Вектор";
            Random rand = new Random();
            string[,] vector = new string[MaxN, MaxN];
            form4.dataGridView1.Columns.Add("", 0.ToString());
            form4.dataGridView2.Columns.Add("", 0.ToString());
            for (int i = 0; i < n; i++)
            {
                form4.dataGridView1.Rows.Add("");
                form4.dataGridView2.Rows.Add("");
                vector[0, i] = rand.Next(0, 10).ToString();
                form4.dataGridView1.Rows[i].Cells[0].Value = vector[0, i];
                form4.dataGridView2.Rows[i].Cells[0].Value = (constant*Convert.ToDouble(vector[0, i])).ToString();
            }
            ShowAndClean();
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            form4 = new Form4();
            form4.dataGridView1.Visible = false;
            form4.dataGridView2.Visible = false;
            form4.dataGridView3.Visible = false;
            form4.label3.Visible = false;
        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

    }
}
