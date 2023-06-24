using Project_4___Cafe.TableFunctions;
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
    public partial class OrderWindow : Form
    {
        PictureBox picture;
        public static Panel ORPanel { get; set; }
        public OrderWindow(PictureBox pic)
        {
            InitializeComponent();
            ORPanel = ORPanelMain;
            picture = pic;
        }

        private void OrderBtn_Click(object sender, EventArgs e)
        {
            Order f = new Order(picture.Name.ToString());
            Form1.LoadPanel(f, ORPanel);
        }

        private void ReserveBtn_Click(object sender, EventArgs e)
        {
            Reserve f = new Reserve(picture.Name.ToString());
            Form1.LoadPanel(f, ORPanel);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Table_Window.Ord = DialogResult.Ignore;
            Form1.LoadPanel(new Table_Window(true), Form1.MP);
        }

    }
}
