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

namespace Project_4___Cafe.TableFunctions
{
    public partial class Reserve : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-PS7OKKF;Initial Catalog=StepCafe_db;Integrated Security=True");
        string TableName;
        public Reserve(string tableName)
        {
            InitializeComponent();
            TableName = tableName;
        }

        private void ReserveBtn_Click(object sender, EventArgs e)
        {
            //check if user changed or not data value
            if ((DateTime.Now - Date.Value).Seconds < 0)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand($"UPDATE CafeTables_Tb SET BusyReserve = 'true', ReserveDate = '{Date.Value}' WHERE TableName = '{TableName}'",con);
                cmd.ExecuteNonQuery();
                con.Close();
                Table_Window.Ord = DialogResult.Cancel;
                Close();
                MessageBox.Show("Reserve Has Been Made.", "Success");
                Form1.LoadPanel(new Table_Window(true), Form1.MP);
            }
            else
            {
                MessageBox.Show("Dro Miutite bichoooo");
            }
        }

        private void Reserve_Load(object sender, EventArgs e)
        {
            //minimum date, it should be reserved in future.
            Date.MinDate = DateTime.Now;
        }
    }
}
