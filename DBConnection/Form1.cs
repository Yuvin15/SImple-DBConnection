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
            string connetionString;
            SqlConnection cnn;
            connetionString = @"Server=tcp:cldv10083835.database.windows.net,1433;Initial Catalog=TestDB;Persist Security Info=False;User ID=ST10083835;Password=Keenless19;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            cnn = new SqlConnection(connetionString);
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
    }
}