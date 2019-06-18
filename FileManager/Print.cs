using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using FileManager.Properties;

namespace FileManager
{
    public partial class Print : Form
    {
        public Print()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            if (comboBox1.SelectedIndex != -1)
            {
                new Thread(() =>
                {
                    Invoke(new Action(() =>
                    {
                        while (progressBar1.Value != 100)
                        {
                            Thread.Sleep(500);
                            progressBar1.Value += 5;
                        }
                    }));
                    MessageBox.Show("Печать успешно завершена", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }).Start();
            }
            else
            {
                MessageBox.Show("Выберите принтер для печати", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Print_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (progressBar1.Value != 0 && progressBar1.Value != 100)
            {
                e.Cancel = true;
                MessageBox.Show("Дождитесь окончания печати", "Информация", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == 0)
            {
                pictureBox1.Image = Resources.XrCmsWfipM8;
            }

            if (comboBox2.SelectedIndex == 1)
            {
                pictureBox1.Image = Resources._12;
            }

            if (comboBox2.SelectedIndex == 2)
            {
                pictureBox1.Image = Resources._23;
            }
        }

        private void Print_Load(object sender, EventArgs e)
        {

        }
    }
}
