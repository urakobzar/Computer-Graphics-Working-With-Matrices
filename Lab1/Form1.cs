using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace Lab1
{
    public partial class Form1 : Form
    {
        const int MaxN = 4;                         // Максимально допустимая размерность матрицы
        int n = 3;                                  // Текущее число строк
        int m = 3;                                  // Текущее число столбцов
        TextBox[,] MatrText = null;                 // Матрица элементов типа TextBox
        double[,] Matr1 = new double[MaxN, MaxN];   // Матрица 1 чисел с плавающей точкой
        double[,] Matr2 = new double[MaxN, MaxN];   // Матрица 2 чисел с плавающей точкой
        double[,] Matr3 = new double[MaxN, MaxN];   // Матрица результатов
        bool f1;                                    // Флажок, который указывает о вводе данных в матрицу Matr1
        bool f2;                                    // Флажок, который указывает о вводе данных в матрицу Matr2
        int dx = 40, dy = 20;                       // Ширина и высота ячейки в MatrText[,]
        Form2 form2 = null;                         // Экземпляр (объект) класса формы Form2

        private void Clear_MatrText()
        {
            for (int i = 0; i < MaxN; i++)
            {
                for (int j = 0; j < MaxN; j++)
                {
                    MatrText[i, j].Text = "0";
                }
            }
        }

        private void ClearAllMatrText()
        {
            for (int i = 0; i < MaxN; i++)
            {
                for (int j = 0; j < MaxN; j++)
                {
                    form2.Controls.Remove(MatrText[i, j]);
                    MatrText[i, j] = new TextBox();
                    MatrText[i, j].Text = "0";
                    MatrText[i, j].Location = new System.Drawing.Point(10 + i * dx, 10 + j * dy);
                    MatrText[i, j].Size = new System.Drawing.Size(dx, dy);
                    MatrText[i, j].Visible = false;
                    form2.Controls.Add(MatrText[i, j]);
                }
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text == "") || (textBox2.Text == ""))
            {
                MessageBox.Show("Введите число строк n и число столбцов m");
                return;
            }
            n = int.Parse(textBox1.Text);
            m = int.Parse(textBox2.Text);
            if ((n > MaxN) || (m > MaxN))
            {
                MessageBox.Show("Число строк и столбцов должно быть меньше или равно 4");
                return;
            }
            ClearAllMatrText();
            Clear_MatrText();
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    MatrText[i, j].TabIndex = i * n + j + 1;
                    MatrText[i, j].Visible = true;
                }
            }
            form2.Width = 10 + m * dx + 20;
            form2.Height = 10 + n * dy + form2.button1.Height + 50;
            form2.button1.Left = 10;
            form2.button1.Top = 10 + n * dy + 10;
            form2.button1.Width = form2.Width - 30;
            if (form2.ShowDialog() == DialogResult.OK)
            {
                for (int i = 0; i < m; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (MatrText[i, j].Text != "")
                        {
                            Matr1[i, j] = Double.Parse(MatrText[i, j].Text);
                        }
                        else
                        {
                            Matr1[i, j] = 0;
                        }
                     }
                }
                f1 = true;
                label2.Text = "Матрица заполнена!";
                label2.ForeColor = Color.Green;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text == "") || (textBox2.Text == ""))
            {
                MessageBox.Show("Введите число строк n и число столбцов m");
                return;
            }
            n = int.Parse(textBox1.Text);
            m = int.Parse(textBox2.Text);
            if ((n > MaxN) || (m > MaxN))
            {
                MessageBox.Show("Число строк и столбцов должно быть меньше или равно 4");
                return;
            }
            Clear_MatrText();
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    MatrText[i, j].TabIndex = i * n + j + 1;
                    MatrText[i, j].Visible = true;
                }
            }
            form2.Width = 10 + m * dx + 20;
            form2.Height = 10 + n * dy + form2.button1.Height + 50;
            form2.button1.Left = 10;
            form2.button1.Top = 10 + n * dy + 10;
            form2.button1.Width = form2.Width - 30;
            if (form2.ShowDialog() == DialogResult.OK)
            {
                for (int i = 0; i < m; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        Matr2[i, j] = Double.Parse(MatrText[i, j].Text);
                    }
                }
                f2 = true;
                label3.Text = "Матрица заполнена!";
                label3.ForeColor = Color.Green;
            }
            ClearAllMatrText();
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            int nn;
            nn = Int16.Parse(textBox1.Text);
            if (nn != n)
            {
                f1 = f2 = false;
                label2.Text = "Матрица не заполнена";
                label3.Text = "Матрица не заполнена";
                label2.ForeColor = Color.Red;
                label3.ForeColor = Color.Red;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!((f1 == true) && (f2 == true)))
            {
                return;
            }
            if (m!=n)
            {
                MessageBox.Show("Матрица должна быть квадратной (n=m)");
                return;
            }
            ClearAllMatrText();
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    MatrText[i, j].TabIndex = i * n + j + 1;
                    MatrText[i, j].Visible = true;
                }
            }
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Matr3[j, i] = 0;
                    for (int k = 0; k < n; k++)
                    {
                        Matr3[j, i] = Matr3[j, i] + Matr1[k, i] * Matr2[j, k];
                    }
                }
            }
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    MatrText[i, j].TabIndex = i * n + j + 1;
                    MatrText[i, j].Text = Matr3[i, j].ToString();
                }
            }
            form2.ShowDialog();
   
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FileStream fw = null;
            string msg;
            byte[] msgByte = null;
            fw = new FileStream("Res_Matr.txt", FileMode.Append);
            // 2. Запись матрицы результата в файл
            // 2.1. Сначала записать число элементов матрицы Matr3
            msg = n.ToString() +"x"+ m.ToString()+"\r\n";
            // перевод строки msg в байтовый массив msgByte
            msgByte = Encoding.Default.GetBytes(msg);
            // запись массива msgByte в файл
            fw.Write(msgByte, 0, msgByte.Length);
            // 2.2. Теперь записать саму матрицу
            msg = "";
            for (int i = 0; i < n; i++)
            {
                // формируем строку msg из элементов матрицы
                for (int j = 0; j < m; j++)
                {
                    msg = msg + Matr3[j,i].ToString() + "  ";
                }
                msg = msg + "\r\n"; // добавить перевод строки
            }
            // 3. Перевод строки msg в байтовый массив msgByte
            msgByte = Encoding.Default.GetBytes(msg);
            // 4. запись строк матрицы в файл
            fw.Write(msgByte, 0, msgByte.Length);
            // 5. Закрыть файл
            if (fw != null)
            {
                fw.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (!((f1 == true) && (f2 == true)))
            {
                return;
            }
            ClearAllMatrText();
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    MatrText[i, j].TabIndex = i * n + j + 1;
                    MatrText[i, j].Visible = true;
                }
            }
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Matr3[i, j] = 0;
                    Matr3[i, j] = Matr3[i, j] + Matr1[i, j] + Matr2[i, j];
                }
            }
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    MatrText[i, j].TabIndex = i * n + j + 1;
                    MatrText[i, j].Text = Matr3[i, j].ToString();
                }
            }  
            form2.ShowDialog();
   
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (!((f1 == true) && (f2 == true)))
            {
                return;
            }
            ClearAllMatrText();
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    MatrText[i, j].TabIndex = i * n + j + 1;
                    MatrText[i, j].Visible = true;
                }
            }
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Matr3[i, j] = 0;
                    Matr3[i, j] = Matr3[i, j] + Matr1[i, j] - Matr2[i, j];
                }
            }
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    MatrText[i, j].TabIndex = i * n + j + 1;
                    MatrText[i, j].Text = Matr3[i, j].ToString();
                }
            }
            form2.ShowDialog();
 
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Process.Start("HelloApp.exe");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = "";
            f1 = f2 = false;
            label2.Text = "Матрица не заполнена";
            label3.Text = "Матрица не заполнена";
            label2.ForeColor = Color.Red;
            label3.ForeColor = Color.Red;
            int i, j;
            form2 = new Form2();
            MatrText = new TextBox[MaxN, MaxN];
            for (i = 0; i < MaxN; i++)
            {
                for (j = 0; j < MaxN; j++)
                {
                    MatrText[i, j] = new TextBox();
                    MatrText[i, j].Text = "0";
                    MatrText[i, j].Location = new System.Drawing.Point(10 + i * dx, 10 + j * dy);
                    MatrText[i, j].Size = new System.Drawing.Size(dx, dy);
                    MatrText[i, j].Visible = false;
                    form2.Controls.Add(MatrText[i, j]);
                 }
            }
        }  
    }
}
