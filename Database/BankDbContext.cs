/*using System;
using Microsoft.EntityFrameworkCore;

namespace Database
{
    public class BankDbContext:DbContext
    {

    }
}*/
using System;
using System.Data;
using System.Drawing;
using MySql.Data.MySqlClient;

namespace Csharp_And_MySQL
{
    public partial class BankDbContext
    {
        public BankDbContext()
        {
            InitializeComponent();
        }
        MySqlConnection connection;
        private void Csharp_Connect_To_MySQL_Database_Load(object sender, EventArgs e)
        {
            try
            {
                connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");
                connection.Open();
                if (connection.State == ConnectionState.Open)
                {
                    label1.Text = "Connected";
                    label1.ForeColor = Color.Green;
                }
                else
                {
                    label1.Text = "Not Connected";
                    label1.ForeColor = Color.Red;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
                label1.Text = "Not Connected";
                label1.ForeColor = Color.Red;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
                label1.Text = "Connected";
                label1.ForeColor = Color.Green;
            }
        }
    }
}

