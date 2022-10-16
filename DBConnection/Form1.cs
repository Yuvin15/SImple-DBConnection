using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.VisualBasic.ApplicationServices;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;
using System.Reflection.Emit;

namespace DBConnection
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString;
            SqlConnection cnn;
            connectionString = @"Server=tcp:cldv10083835.database.windows.net,1433;Initial Catalog=TestDB;Persist Security Info=False;User ID=ST10083835;Password=Keenless19;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            cnn = new SqlConnection(connectionString);
            cnn.Open();

            SqlCommand command;
            SqlDataReader DR;
            String sql, Output = "";

            sql = "SELECT * FROM Test";
            command = new SqlCommand(sql, cnn);
            DR = command.ExecuteReader();

            while (DR.Read())
            {
                Output = "Username: " + Output + DR.GetValue(0) + "\nPassword: " + Output + DR.GetValue(1);
            }
            MessageBox.Show(Output);

            DR.Close();
            command.Dispose();
            cnn.Close();

            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Server=tcp:cldv10083835.database.windows.net,1433;Initial Catalog=TestDB;Persist Security Info=False;User ID=ST10083835;Password=Keenless19;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            con.Open();
            string userid = usernameTB.Text;
            string password = passwordTB.Text;
            SqlCommand cmd = new SqlCommand("select * from Test where USERNAME='" + usernameTB.Text + "'and PASSWORD='" + passwordTB.Text + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Login sucess ");
            }
            else
            {
                MessageBox.Show("Invalid Login please check username and password");
            }
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Server=tcp:cldv10083835.database.windows.net,1433;Initial Catalog=TestDB;Persist Security Info=False;User ID=ST10083835;Password=Keenless19;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

            try
            {
                string query = "Insert into Test(USERNAME,PASSWORD) Values('" + usernameTB.Text + "','" +passwordTB.Text + "')";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                con.Open();
                da.SelectCommand.ExecuteNonQuery();
                MessageBox.Show("Account created successfully..");
            }
            catch
            {
                MessageBox.Show("Error occured...");
            }
            finally
            {
                con.Close();
            }
        }

        private void passwordTB_Enter(object sender, EventArgs e)
        {
            passwordTB.Text = "";

            passwordTB.ForeColor = Color.Black;

            passwordTB.UseSystemPasswordChar = true;
        }
    }
}



