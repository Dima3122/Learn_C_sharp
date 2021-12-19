using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, EventArgs e)
        {
            textBox3.Text = " ";
            float result;
            string myString;
            string select = listBox1.SelectedIndex.ToString();
            int selected = Convert.ToInt32(select);
            switch (selected)
            {
                case 0:
                    result = int.Parse(textBox1.Text) + int.Parse(textBox2.Text);
                    myString = result.ToString();
                    textBox3.Text = myString;
                    break;
                case 1:
                    result = int.Parse(textBox1.Text) - int.Parse(textBox2.Text);
                    myString = result.ToString();
                    textBox3.Text = myString;
                    break;
                case 2:
                    result = int.Parse(textBox1.Text) * int.Parse(textBox2.Text);
                    myString = result.ToString();
                    textBox3.Text = myString;
                    break;
                case 3:
                    if(int.Parse(textBox2.Text) != 0)
                    {
                        result = int.Parse(textBox1.Text) / int.Parse(textBox2.Text);
                        myString = result.ToString();
                        textBox3.Text = myString;
                    }
                    else
                    {
                        textBox3.Text = "На ноль делить нельзя!";
                    }
                    break;
                default:
                    textBox3.Text = "Выберите действие!";
                    break;
            }
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Создатель: Dile");
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
