using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button2_Click(object sender, System.EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            }
            else
            {
                MessageBox.Show("Элемент не выбран!",
                    "Ошибка",
                    MessageBoxButtons.OK);
            }
        }

        private void Button1_Click(object sender, System.EventArgs e)
        {
            listBox1.Items.Add(listBox1.Items.Count + 1);
            MessageBox.Show($"Добавлен элемент {listBox1.Items.Count}",
                    "Я не поняла смысл задания, так что сделала так",
                    MessageBoxButtons.OK);
        }

        private void Button3_Click(object sender, System.EventArgs e)
        {
            listBox1.Items.Clear();
            this.listBox1.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7"});
        }

    }

}
