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

namespace PeMonT_TexH
{
    public partial class LoginHistory : Form
    {
        private static string connectString = "Data Source = LAPTOP-M008LR82;Initial Catalog = Pr_Lab2;" +
               "Integrated Security = true;";
        public LoginHistory()
        {
            InitializeComponent();
        }

        private void LoginHistory_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            using (SqlConnection myConnection = new SqlConnection(connectString))
            {
                myConnection.Open();
                SqlCommand cmd = myConnection.CreateCommand();
                cmd.CommandText = "select LOGIN_HISTORY.id, STAFF.login, LOGIN_HISTORY.datetime_entrance, LOGIN_HISTORY.was_completed from LOGIN_HISTORY, STAFF where STAFF.id = LOGIN_HISTORY.[User];";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                DataSet data = new DataSet();
                dataAdapter.Fill(data);
                myConnection.Close();
                dataGridView1.DataSource = data.Tables[0];
            }
        }

        private void btn_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                using (SqlConnection myConnection = new SqlConnection(connectString))
                {
                    myConnection.Open();
                    SqlCommand cmd = myConnection.CreateCommand();
                    cmd.CommandText = "select LOGIN_HISTORY.id, STAFF.login, LOGIN_HISTORY.datetime_entrance, LOGIN_HISTORY.was_completed from LOGIN_HISTORY, STAFF where STAFF.id = LOGIN_HISTORY.[User];";
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    DataSet data = new DataSet();
                    dataAdapter.Fill(data);
                    myConnection.Close();
                    dataGridView1.DataSource = data.Tables[0];
                }
            }
            else
            {
                using (SqlConnection myConnection = new SqlConnection(connectString))
                {
                    myConnection.Open();
                    SqlCommand cmd = myConnection.CreateCommand();
                    cmd.CommandText = $"select LOGIN_HISTORY.id, STAFF.login, LOGIN_HISTORY.datetime_entrance, LOGIN_HISTORY.was_completed from LOGIN_HISTORY, STAFF where STAFF.id = LOGIN_HISTORY.[User] and STAFF.login = '{textBox2.Text}';";
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    DataSet data = new DataSet();
                    dataAdapter.Fill(data);
                    myConnection.Close();
                    dataGridView1.DataSource = data.Tables[0];
                }
            }
            
            }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                using (SqlConnection myConnection = new SqlConnection(connectString))
                {
                    myConnection.Open();
                    SqlCommand cmd = myConnection.CreateCommand();
                    cmd.CommandText = "select LOGIN_HISTORY.id, STAFF.login, LOGIN_HISTORY.datetime_entrance, LOGIN_HISTORY.was_completed from LOGIN_HISTORY, STAFF where STAFF.id = LOGIN_HISTORY.[User];";
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    DataSet data = new DataSet();
                    dataAdapter.Fill(data);
                    myConnection.Close();
                    dataGridView1.DataSource = data.Tables[0];
                }
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                using (SqlConnection myConnection = new SqlConnection(connectString))
                {
                    myConnection.Open();
                    SqlCommand cmd = myConnection.CreateCommand();
                    cmd.CommandText = "select LOGIN_HISTORY.id, STAFF.login, LOGIN_HISTORY.datetime_entrance, LOGIN_HISTORY.was_completed from LOGIN_HISTORY, STAFF  where STAFF.id = LOGIN_HISTORY.[User] order by LOGIN_HISTORY.datetime_entrance desc;";
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    DataSet data = new DataSet();
                    dataAdapter.Fill(data);
                    myConnection.Close();
                    dataGridView1.DataSource = data.Tables[0];
                }
            }
        }
    }
    }

