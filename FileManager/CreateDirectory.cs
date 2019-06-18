using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileManager
{
    public partial class CreateDirectory : Form
    {
        public CreateDirectory()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HELPER.f1.CreateDir(textBox1.Text);
            this.Close();
        }
    }
}
