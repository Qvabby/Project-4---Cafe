using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_4___Cafe
{
    public partial class Table_Window : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-PS7OKKF;Initial Catalog=StepCafe_db;Integrated Security=True");
        public static PictureBox pic { get; set; }
        public static int freetables { get; set; } = 36;
        public static DialogResult Ord { get; set; }

        public static List<PictureBox> TakenTables = new List<PictureBox>();
        private DataTable TBsData = new DataTable();
        public Table_Window(bool b)
        {
            InitializeComponent();
            if (!b)
            {
                freetables = 36;
            }
        }
        //Puts FreeTable Count on window
        private void TableFreeCounter()
        {
            FTL.Text = $"Free Tables: {freetables}";
        }
        //Checks if table is busy or not on click, And opens up Order/Reserve Window if its not busy
        private void TBmethod(object sender, EventArgs e)
        {
            //getting sender button so we can change picture image later then.
            pic = (sender as PictureBox);
            //get Tables Data
            DataTable dt = GetTables();
            bool can = true;
            //check if busy or not
            foreach (DataRow item in dt.Rows)
            {
                if (pic.Name.ToString() == item[1].ToString())
                {
                    if (!string.IsNullOrWhiteSpace(item[2].ToString()))
                    {
                        can = false;
                    }
                }
            }
            if (can)
            {
                //open Order/Reserve Window
                OrderWindow ow = new OrderWindow(pic);
                Form1.LoadPanel(ow, Form1.MP);
            }
            else
            {
                MessageBox.Show("Busy Table");
            }
        }
        //Get Tables Data
        private DataTable GetTables()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM CafeTables_Tb", con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            return dt;
        }
        //activates when form is loaded
        private void Table_Window_Load(object sender, EventArgs e)
        {
            List<PictureBox> btns = new List<PictureBox>() { t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11,t12,t13,t14,t15,t16,t17,t18,t19,t20,t21,t22,t23,t24,t25,t26,t27,t28,t29,t30,t31,t32,t33,t34,t35,t36 };
            foreach (PictureBox pb in btns)
            {
                //Giving every picturebutton same methods with loop.
                pb.Click += TBmethod;
            }
            //checks database if cafe table is busy or reserved and puts up needed image for it.
            TBsData = CheckTbsInDb(btns);
            //resets freetable counter variable.
            freetables = 36;
        }
        private DataTable CheckTbsInDb(List<PictureBox> tables)
        {
            DataTable dt = GetTables();
            //if there is no data in tables, add one.
            if (dt.Rows.Count <1)
            {
                foreach (var item in tables)
                {
                    con.Open();
                    SqlCommand cmd2 = new SqlCommand($"Insert into CafeTables_Tb (TableName) values ('{item.Name}')", con);
                    cmd2.ExecuteNonQuery();
                    con.Close();
                }
            }
            else
            {
                //if there is data aviable then use it to change pics.
                List<PictureBox> btns = new List<PictureBox>() { t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22, t23, t24, t25, t26, t27, t28, t29, t30, t31, t32, t33, t34, t35, t36 };
                foreach (DataRow item in dt.Rows)
                {
                    if (item[2].ToString() == "false")
                    {
                        foreach (var item2 in btns)
                        {
                            if (item2.Name.ToString() == item[1].ToString())
                            {
                                item2.Image = Image.FromFile(@"C:\Users\Saba\source\repos\Project 4 - Cafe\Project 4 - Cafe\Resources\icons8-tablecloth-50 (3).png");
                                freetables--;
                                TableFreeCounter();
                            }
                        }
                    }
                    else if (item[2].ToString() == "true")
                    {
                        foreach (var item2 in btns)
                        {
                            if (item2.Name.ToString() == item[1].ToString())
                            {
                                item2.Image = Image.FromFile(@"C:\Users\Saba\source\repos\Project 4 - Cafe\Project 4 - Cafe\Resources\icons8-tablecloth-50 (2).png");
                                freetables--;
                                TableFreeCounter();
                            }
                        }
                    }
                }
            }
            //returns table.
            return dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM Order_Tb", con);
            SqlCommand cmd2 = new SqlCommand("UPDATE CafeTables_Tb SET BusyReserve = NULL, ReserveDate = NULL",con);
            cmd.ExecuteNonQuery();
            cmd2.ExecuteNonQuery();
            MessageBox.Show("Every Table reseted, every order deleted.");
            Table_Window f = new Table_Window(false);
            Form1.LoadPanel(f, Form1.MP);
            con.Close();
        }
    }
}
