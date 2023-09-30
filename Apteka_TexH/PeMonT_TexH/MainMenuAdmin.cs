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

    public partial class MainMenu : Form
    {
        private static string connectString = "Data Source = LAPTOP-M008LR82;Initial Catalog = Pr_Lab2;" +
               "Integrated Security = true;";
        private int id;
        public MainMenu(int id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            using (SqlConnection myConnection = new SqlConnection(connectString))
            {
                myConnection.Open();
                SqlCommand cmd = myConnection.CreateCommand();
                cmd.CommandText = $"SELECT STAFF.[name], [surname],[login],[pwd], POSTS.[Name], STAFF.id  from STAFF, POSTS where POSTS.id = Post and STAFF.id = {id}";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                DataSet data = new DataSet();
                dataAdapter.Fill(data);
                myConnection.Close();
                label2.Text = data.Tables[0].Columns[0].Table.Rows[0].ItemArray[0].ToString();
                label3.Text = data.Tables[0].Columns[0].Table.Rows[0].ItemArray[1].ToString();
                label4.Text = data.Tables[0].Columns[0].Table.Rows[0].ItemArray[4].ToString();
            }
        }

        private void btn_Click(object sender, EventArgs e)
        {
            if (sender == loginHistoryBtn)
            {
                LoginHistory loginHistory = new LoginHistory();
                loginHistory.ShowDialog();
            }
            else if(sender == exitBtn)
            {
                Close();
            }
            else if (sender == toCustomersBtn)
            {
                this.Hide();
                Table table = new Table("CUSTOMERS");
                table.ShowDialog();
                this.Show();
            }
            else if (sender == toFirmsBtn)
            {
                this.Hide();
                Table table = new Table("FIRMS");
                table.ShowDialog();
                this.Show();
            }
            else if (sender == toModelsBtn)
            {
                this.Hide();
                Table table = new Table("MODELS");
                table.ShowDialog();
                this.Show();
            }
            else if (sender == toPostsBtn)
            {
                this.Hide();
                Table table = new Table("POSTS");
                table.ShowDialog();
                this.Show();
            }
            else if (sender == toProdBtn)
            {
                this.Hide();
                Table table = new Table("PRODUCTS");
                table.ShowDialog();
                this.Show();
            }
            else if (sender == toStaffBtn)
            {
                this.Hide();
                Table table = new Table("STAFF");
                table.ShowDialog();
                this.Show();
            }
        }
    }
}
