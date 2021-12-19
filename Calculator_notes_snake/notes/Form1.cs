using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace notes
{
    public partial class Form1 : Form
    {
        int count = 0;
        public Form1()
        {
            InitializeComponent();
            HeaderOfTheTable();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            count++;
            dataGridView.Rows.Add(textBox1.Text, DateTime.Now);
            textBox1.Text = "";
        }
        public void HeaderOfTheTable()
        {
            var colomn1 = new DataGridViewColumn();
            colomn1.HeaderText = "Данные";
            colomn1.Width = 405;
            colomn1.CellTemplate = new DataGridViewTextBoxCell();
            colomn1.Name = "data";
            colomn1.Frozen = true;

            var colomn2 = new DataGridViewColumn();
            colomn2.HeaderText = "Время";
            colomn2.Width = 125;
            colomn2.CellTemplate = new DataGridViewTextBoxCell();
            colomn2.Name = "time";
            colomn2.Frozen = true;

            dataGridView.Columns.Add(colomn1);
            dataGridView.Columns.Add(colomn2);
            dataGridView.AllowUserToAddRows = false;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (count == 0)
            {
                MessageBox.Show("Список дел пуст!");
                return;
            }
            int ind = dataGridView.SelectedCells[0].RowIndex;
            dataGridView.Rows.RemoveAt(ind);
            count--;
        }
        private void оПрограммеToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Создатель Di");
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream(@"D:\програмирование\программы\Изучение C#\калькулятор на C#\calculator\notes\data\1.txt", FileMode.Create);
            StreamWriter streamWriter = new StreamWriter(fs);//записывальщик в файл
            try
            {
                for (int j = 0; j < dataGridView.Rows.Count; j++)
                {
                    for (int i = 0; i < dataGridView.Rows[j].Cells.Count; i++)
                    {
                        streamWriter.Write(dataGridView.Rows[j].Cells[i].Value + "/");
                    }

                    streamWriter.WriteLine();
                }
                streamWriter.Write("{" + count);
                streamWriter.Close();
                fs.Close();

                MessageBox.Show("Файл успешно сохранен");
            }
            catch
            {
                MessageBox.Show("Ошибка при сохранении файла!");
            }
        }
        private void удалитьВсеЗаметкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView.Rows.Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FileStream fs = new FileStream(@"D:\програмирование\программы\Изучение C#\калькулятор на C#\calculator\notes\data\1.txt", FileMode.Open);
            StreamReader streamReader = new StreamReader(fs);
            string str = streamReader.ReadToEnd();
            char [] splitsymbol1 = { '\n' };
            string [] str2 = str.Split(splitsymbol1);
            int count_notes = str2.Length - 1;
            string [] str3;
            char[] splitsymbol2 = { '/' };
            char[] splitsymbol3 = { '{' };
            for (int i = 0; i < count_notes; i++)
            {
                str3 = str2[i].Split(splitsymbol2);
                dataGridView.Rows.Add(str3[0], str3[1]);
            }
            str3 = str.Split(splitsymbol3);
            int count3 = str3.Length;
            count = Convert.ToInt32(str3[count3-1]);
            streamReader.Close();
        }
    }
}