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
    public partial class Order : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-PS7OKKF;Initial Catalog=StepCafe_db;Integrated Security=True");
        float TotalPrice;
        string TableName;
        List<string> OrderedFoods;
        //Constructor
        public Order(string TB)
        {
            TableName = TB;
            InitializeComponent();
            //Gets All Products and Drinks in Comboboxes
            CheckDb();
            //Giving Every ComboBox same Methodes on user changing selected item.
            List<ComboBox> Comboboxes = new List<ComboBox>() { MeatCB, BreadCB, DessertCB, SodaCB, AlcoholCB, NaturalCB };
            foreach (ComboBox cb in Comboboxes)
            {
                cb.SelectionChangeCommitted += CBMethod;
            }
        }
        //Getting Products Table From Database
        private DataTable GetProducts()
        {
            con.Open();
            SqlCommand GetProductsCommand = new SqlCommand("SELECT * FROM Products_Tb", con);
            SqlDataAdapter ProductsAdapter = new SqlDataAdapter(GetProductsCommand);
            DataTable ProductsTable = new DataTable();
            ProductsAdapter.Fill(ProductsTable);
            con.Close();
            return ProductsTable;
        }
        //Getting Drinks Table From DataBase
        private DataTable GetDrinks()
        {
            con.Open();
            SqlCommand GetDrinksCommand = new SqlCommand("SELECT * FROM Drinks_Tb", con);
            SqlDataAdapter DrinksAdapter = new SqlDataAdapter(GetDrinksCommand);
            DataTable DrinksTable = new DataTable();
            DrinksAdapter.Fill(DrinksTable);
            con.Close();
            return DrinksTable;
        }
        //Getting Tables Table From DataBase
        private DataTable GetTables()
        {
            con.Open();
            SqlCommand GetTablesCommand = new SqlCommand("SELECT * FROM CafeTables_Tb", con);
            SqlDataAdapter TablesAdapter = new SqlDataAdapter(GetTablesCommand);
            DataTable TablesTb = new DataTable();
            TablesAdapter.Fill(TablesTb);
            con.Close();
            return TablesTb;
        }
        //Everytime User Chooses Any Food.
        private void CBMethod(object sender, EventArgs e)
        {
            List<ComboBox> Comboboxes = new List<ComboBox>() { MeatCB, BreadCB, DessertCB, SodaCB, AlcoholCB, NaturalCB };
            ComboBox cb = (sender as ComboBox);
            DataTable ProductsTable = GetProducts();
            DataTable DrinksTable = GetDrinks();
            //Change all others' values.
            foreach (var item in Comboboxes)
            {
                if (item.Name != cb.Name)
                {
                    item.SelectedItem = null;
                }
            }
            //Get Details. (As Products)
            foreach (DataRow item in ProductsTable.Rows)
            {
                if (item["ProductName"].ToString() == cb.SelectedItem.ToString())
                {
                    ProductDetailsPanel.Visible = true;
                    NameInfoL.Text = item["ProductName"].ToString();
                    PriceInfoL.Text = item["ProductPrice"].ToString();
                    DescriptionInfoL.Text = item["ProductDescription"].ToString();
                }
            }
            //Get Details. (As Drinks)
            foreach (DataRow item in DrinksTable.Rows)
            {
                if (item["DrinkName"].ToString() == cb.SelectedItem.ToString())
                {
                    ProductDetailsPanel.Visible = true;
                    NameInfoL.Text = item["DrinkName"].ToString();
                    PriceInfoL.Text = item["DrinkPrice"].ToString();
                    DescriptionInfoL.Text = item["DrinkDescription"].ToString();
                }
            }

        }
        //Gets All Products and Drinks in Comboboxes
        private void CheckDb()
        {
            //Get Tables From DataBase
            DataTable ProductsTable = GetProducts();
            DataTable DrinksTable = GetDrinks();
            //For Products
            foreach (DataRow Product in ProductsTable.Rows)
            {
                string itemString = $"{Product[1]}";
                if (Product["ProductType"].ToString() == "Meat")
                {
                    MeatCB.Items.Add(itemString);
                }
                else if (Product["ProductType"].ToString() == "Bread")
                {
                    BreadCB.Items.Add(itemString);
                }
                else if (Product["ProductType"].ToString() == "Dessert")
                {
                    DessertCB.Items.Add(itemString);
                }
            }
            //For Drinks
            foreach (DataRow Drink in DrinksTable.Rows)
            {
                string itemString = $"{Drink[1]}";
                if (Drink["DrinkType"].ToString() == "Soda")
                {
                    SodaCB.Items.Add(itemString);
                }
                else if (Drink["DrinkType"].ToString() == "Alcohol")
                {
                    AlcoholCB.Items.Add(itemString);
                }
                else if (Drink["DrinkType"].ToString() == "Natural")
                {
                    NaturalCB.Items.Add(itemString);
                }
            }
        }

        private void OrderBtn_Click(object sender, EventArgs e)
        {
            //checks if User ordered anything or not.
            if (OrderListLB.Items.Count > 0)
            {
                DataTable Tables = GetTables();
                int tableid = 0;

                foreach (DataRow row in Tables.Rows)
                {
                    if (row["TableName"].ToString() == TableName)
                    {
                        tableid = int.Parse(row["Id"].ToString());
                    }
                }
                if (tableid > 0)
                {
                    string Description = "";
                    foreach (var item in OrderedFoods)
                    {
                        Description += item + ",";
                    }
                    con.Open();
                    SqlCommand OrderCommand = new SqlCommand($"Insert Into Order_Tb (TableId,Name,Description,TotalPrice,OrderDate) VALUES " +
                                        $"({tableid}, '{TableName} Table order', '{Description}', {TotalPrice}, '{DateTime.Now}' )", con);
                    OrderCommand.ExecuteNonQuery();
                    SqlCommand UpdateCafeTables_Tb = new SqlCommand($"UPDATE CafeTables_Tb SET BusyReserve = 'false' WHERE TableName = '{TableName}'",con);
                    UpdateCafeTables_Tb.ExecuteNonQuery();
                    con.Close();
                    Table_Window.Ord = DialogResult.OK;
                    MessageBox.Show("Order Has Been Made.", "Success");
                    Form1.LoadPanel(new Table_Window(true), Form1.MP);
                }
            }
            else
            {
                MessageBox.Show("Nigga you want air?", "Choose something bruh");
            }
            return;
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            float TotalMoney = float.Parse(OrderPriceL.Text);
            List<ComboBox> Comboboxes = new List<ComboBox>() { MeatCB, BreadCB, DessertCB, SodaCB, AlcoholCB, NaturalCB };
            string OrderName = "";
            //Getting Selected Item Name so later we can check it in database
            foreach (ComboBox comboBox in Comboboxes)
            {
                if (comboBox.SelectedItem != null)
                {
                    OrderName = comboBox.SelectedItem.ToString();
                }
            }
            //Getting Tables
            DataTable ProductsTable = GetProducts();
            DataTable DrinksTable = GetDrinks();
            //Adding To ListBox
            foreach (DataRow row in ProductsTable.Rows)
            {
                if (row["ProductName"].ToString() == OrderName && OrderName != "")
                {
                    OrderListLB.Items.Add($"{row["ProductName"].ToString()} - {row["ProductPrice"]}");
                    TotalMoney += float.Parse(row["ProductPrice"].ToString());
                    break;
                }
            }
            foreach (DataRow row in DrinksTable.Rows)
            {
                if (row["DrinkName"].ToString() == OrderName && OrderName != "")
                {
                    OrderListLB.Items.Add($"{row["DrinkName"].ToString()} - {row["DrinkPrice"]}");
                    TotalMoney += float.Parse(row["DrinkPrice"].ToString());
                    break;
                }
            }
            //Counting Total
            TotalMoney += 0.2f;
            OrderPriceL.Text = TotalMoney.ToString();
            TotalPrice = TotalMoney;
            //Saving Ordered Food
            List<string> foods = new List<string>();
            foreach (var item in OrderListLB.Items)
            {
                foods.Add(item.ToString().Split('-')[0]);
            }
            OrderedFoods = foods;
        }
    }
}
