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
    public partial class RenameDir : Form
    {
        private string OldNameDir = "";
        public RenameDir(string oldnamedir)
        {
            InitializeComponent();
            OldNameDir = oldnamedir;
        }

        private void RenameDir_Load(object sender, EventArgs e)
        {
            textBox1.Text = OldNameDir;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HELPER.f1.RenameDir(textBox1.Text);
            this.Close();
        }
    }
}
