using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_4___Cafe
{
    public partial class Form1 : Form
    {
        public static Panel MP { get; set; }
        public Form1()
        {
            InitializeComponent();
        }
        public static void LoadPanel(Form f, Panel p)
        {
            if (p.Controls.Count > 0)
            {
                p.Controls.RemoveAt(0);
            }
            f.TopLevel = false;
            f.FormBorderStyle = FormBorderStyle.None;
            p.Controls.Add(f);
            f.Show();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Table_Window tb = new Table_Window(false);
            LoadPanel(tb, MainPanel);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MP = MainPanel;
        }
    }
}
