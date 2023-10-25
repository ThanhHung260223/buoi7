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

namespace buoi8
{
    public partial class Form1 : Form
    {
        private SqlConnection connect;

        string _connectionString = "server=.; database=test;integrated security=true";
        
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            connect = new SqlConnection(_connectionString);
            try
            {
                connect = new SqlConnection(_connectionString);
                connect.Open();
                MessageBox.Show("Ket noi thanh cong!");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ket noi that bai!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var sql = "select * from test";
            var command = new SqlCommand(sql, connect);

            SqlDataReader data = command.ExecuteReader();
            var name = "";
            var id = "";
            while(data.Read())
            {
                name = data["name"].ToString();
                id = data["id"].ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string update = "update test set id = " + 100 + " where id = " + 1 + "";
                SqlCommand cmd = new SqlCommand(update, connect);
                cmd.ExecuteNonQuery();
                if (connect.State == ConnectionState.Open)
                    connect.Close();
                MessageBox.Show("Update thanh cong!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update that bai!");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                string update = "delete test where id = " + 3 + "";
                SqlCommand cmd = new SqlCommand(update, connect);
                cmd.ExecuteNonQuery();
                if (connect.State == ConnectionState.Open)
                    connect.Close();
                MessageBox.Show("delete thanh cong!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("delete that bai!");
            }
        }
    }
}
