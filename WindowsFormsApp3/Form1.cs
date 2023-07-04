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

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog() { FileName = "SelectFolder", Filter = "Folder|.", CheckFileExists = false })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    this.textBox1.Text = Path.GetDirectoryName(ofd.FileName);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.treeView1.Nodes.Clear();

            try
            {
                foreach (var file in Directory.GetFiles(this.textBox1.Text))
                {
                    TreeNode node = new TreeNode(file);
                    this.treeView1.Nodes.Add(node);
                }
            }
            catch (Exception error)
            {
                this.toolStripStatusLabel1.Text = error.Message;
            }
        }
    }
}
