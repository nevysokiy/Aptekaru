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
    public partial class AddAndChangeForm : Form
    {
        private static string connectString = "Data Source = LAPTOP-M008LR82;Initial Catalog = Pr_Lab2;" +
               "Integrated Security = true;";
        private bool addFlag;
        private int changingId;
        private int changingIdPart;
        public string[] changingRow;
        public AddAndChangeForm()
        {
            InitializeComponent();
        }


        private void btn_Click(object sender, EventArgs e)
        {
            if (sender == button1)
            {
                if (addFlag == false)
                {
                    Change();
                }
                else if (addFlag == true)
                {
                    Add();
                }
                Close();
            }
            else if (sender == button4)
            {
                Close();
            }
        }
        private void Add()
        {
            using (SqlConnection myConnection = new SqlConnection(connectString))
            {
                myConnection.Open();
                SqlCommand cmd = new SqlCommand($"INSERT INTO Запчасти values ({int.Parse(textBox2.Text)}, {int.Parse(textBox3.Text)}, '{textBox4.Text}', '{Convert.ToDateTime(textBox5.Text)}')");
                cmd.Connection = myConnection;
                cmd.ExecuteNonQuery();
                myConnection.Close();
            }
        }

        private void Change()
        {
            using (SqlConnection myConnection = new SqlConnection(connectString))
            {
                myConnection.Open();
                SqlCommand cmd = new SqlCommand($"UPDATE Запчасти SET Product = {int.Parse(textBox2.Text)} , Customer = {int.Parse(textBox3.Text)}, Guarantee = '{textBox4.Text}', [Date of receipt] = '{Convert.ToDateTime(textBox5.Text)}' WHERE [id] = {changingId}");
                cmd.Connection = myConnection;
                cmd.ExecuteNonQuery();
                myConnection.Close();
            }
        }

        private void AddAndChangeForm_Load(object sender, EventArgs e)
        {
            if (addFlag == false)
            {
                button1.Text = "EDIT";
                textBox1.ReadOnly = true;
                textBox1.Visible = true;
                label2.Visible = true;
                textBox1.Text = Convert.ToString(changingId);
                textBox2.Text = Convert.ToString(changingRow[1]);
                textBox3.Text = Convert.ToString(changingRow[2]);
                textBox4.Text = Convert.ToString(changingRow[3]);
                textBox5.Text = Convert.ToString(changingRow[4]);
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                textBox3.Enabled = true;
                textBox4.Enabled = true;
                textBox5.Enabled = true;
            }
            else if (addFlag == true)
            {
                button1.Text = "ADD";
                textBox1.Visible = false;
                label2.Visible = false;
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
            }
        }
        public bool AddFlag
        {
            get { return addFlag; }
            set { addFlag = value; }
        }

        public int ChangingId
        {
            get { return changingId; }
            set { changingId = value; }
        }

        public int ChangingIdPart
        {
            get { return changingIdPart; }
            set { changingIdPart = value; }
        }

        public string[] ChangingRow
        {
            get { return changingRow; }
            set { changingRow = value; }
        }
    }
}
