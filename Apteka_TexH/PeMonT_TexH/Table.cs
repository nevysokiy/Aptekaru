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
    public partial class Table : Form
    {
        private static string connectString = "Data Source = LAPTOP-M008LR82;Initial Catalog = Pr_Lab2;" +
               "Integrated Security = true;";
        private string tableName;
        public Table(string tabName)
        {
            InitializeComponent();
            this.tableName = tabName;
        }

        private void Table_Load(object sender, EventArgs e)
        {
            comboBox4.Items.Clear();
            comboBox4.Items.Add("Select column");
            if (tableName == "CUSTOMERS")
            {
                using (SqlConnection myConnection = new SqlConnection(connectString))
                {
                    comboBox4.Items.Add("id");
                    comboBox4.Items.Add("Name");
                    myConnection.Open();
                    SqlCommand cmd = myConnection.CreateCommand();
                    cmd.CommandText = $"select * from {tableName};";
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    DataSet data = new DataSet();
                    dataAdapter.Fill(data);
                    myConnection.Close();
                    dataGridView1.DataSource = data.Tables[0];
                }
            }
            else if (tableName == "FIRMS")
            {
                comboBox4.Items.Add("id");
                comboBox4.Items.Add("Name");
                using (SqlConnection myConnection = new SqlConnection(connectString))
                {
                    myConnection.Open();
                    SqlCommand cmd = myConnection.CreateCommand();
                    cmd.CommandText = $"select * from {tableName};";
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    DataSet data = new DataSet();
                    dataAdapter.Fill(data);
                    myConnection.Close();
                    dataGridView1.DataSource = data.Tables[0];
                }
            }
            else if (tableName == "POSTS")
            {
                comboBox4.Items.Add("id");
                comboBox4.Items.Add("Name");
                using (SqlConnection myConnection = new SqlConnection(connectString))
                {
                    myConnection.Open();
                    SqlCommand cmd = myConnection.CreateCommand();
                    cmd.CommandText = $"select * from {tableName};";
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    DataSet data = new DataSet();
                    dataAdapter.Fill(data);
                    myConnection.Close();
                    dataGridView1.DataSource = data.Tables[0];
                }
            }
            else if (tableName == "MODELS")
            {
                comboBox4.Items.Add("id");
                comboBox4.Items.Add("Firm");
                comboBox4.Items.Add("Name");
                using (SqlConnection myConnection = new SqlConnection(connectString))
                {
                    myConnection.Open();
                    SqlCommand cmd = myConnection.CreateCommand();
                    cmd.CommandText = $"select {tableName}.id, FIRMS.Name as [Firm] ,{tableName}.Name from {tableName}, FIRMS where {tableName}.Firm = Firms.id;";
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    DataSet data = new DataSet();
                    dataAdapter.Fill(data);
                    myConnection.Close();
                    dataGridView1.DataSource = data.Tables[0];
                }
            }
            else if (tableName == "STAFF")
            {
                comboBox4.Items.Add("id");
                comboBox4.Items.Add("Post");
                comboBox4.Items.Add("Surname");
                using (SqlConnection myConnection = new SqlConnection(connectString))
                {
                    myConnection.Open();
                    SqlCommand cmd = myConnection.CreateCommand();
                    cmd.CommandText = $"select {tableName}.id ,POSTS.Name as [Post], {tableName}.name,{tableName}.surname,  {tableName}.login, {tableName}.pwd, {tableName}.photo from {tableName}, POSTS where {tableName}.Post = POSTS.id;";
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    DataSet data = new DataSet();
                    dataAdapter.Fill(data);
                    myConnection.Close();
                    dataGridView1.DataSource = data.Tables[0];
                }
            }
            else if (tableName == "PRODUCTS")
            {
                comboBox4.Items.Add("id");
                comboBox4.Items.Add("Name");
                comboBox4.Items.Add("Model");
                using (SqlConnection myConnection = new SqlConnection(connectString))
                {
                    myConnection.Open();
                    SqlCommand cmd = myConnection.CreateCommand();
                    cmd.CommandText = $"select {tableName}.id ,{tableName}.Name, MODELS.Name as [Model], {tableName}.[Technical specifications], {tableName}.[Guarantee period], {tableName}.Image from {tableName}, MODELS where {tableName}.Model = MODELS.id;";
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    DataSet data = new DataSet();
                    dataAdapter.Fill(data);
                    myConnection.Close();
                    dataGridView1.DataSource = data.Tables[0];
                }
            }
            else if (tableName == "ORDERS")
            {
                comboBox4.Items.Add("id");
                comboBox4.Items.Add("Product");
                comboBox4.Items.Add("Customer");
                using (SqlConnection myConnection = new SqlConnection(connectString))
                {
                    myConnection.Open();
                    SqlCommand cmd = myConnection.CreateCommand();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    DataSet data = new DataSet();
                    cmd.CommandText = $"select {tableName}.id ,PRODUCTS.Name as [Product], CUSTOMERS.Name as [Customer], {tableName}.Guarantee, {tableName}.[Date of receipt] from {tableName}, PRODUCTS, CUSTOMERS where {tableName}.Product = PRODUCTS.id and {tableName}.Customer = CUSTOMERS.id;";
                    dataAdapter.Fill(data);
                    myConnection.Close();
                    dataGridView1.DataSource = data.Tables[0];
                }
                button1.Visible = true;
                button2.Visible = true;
                button3.Visible = true;
                textBox2.Visible = true;
            }
            else if (tableName == "EXECUTION")
            {
                comboBox4.Items.Add("orderId");
                comboBox4.Items.Add("Worker");
                using (SqlConnection myConnection = new SqlConnection(connectString))
                {
                    myConnection.Open();
                    SqlCommand cmd = myConnection.CreateCommand();
                    cmd.CommandText = $"select {tableName}.orderId ,STAFF.Surname as [Worker], {tableName}.[Type of repair], {tableName}.[Date of completion], {tableName}.message, {tableName}.[Date of issue], {tableName}.Cost from {tableName}, STAFF where {tableName}.Worker = STAFF.id;";
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    DataSet data = new DataSet();
                    dataAdapter.Fill(data);
                    myConnection.Close();
                    dataGridView1.DataSource = data.Tables[0];
                }
            }
            label1.Text = tableName;
            comboBox1.Items.Add("Select column");
            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                comboBox1.Items.Add(dataGridView1.Columns[i].HeaderText.ToString());
            }
            comboBox2.Items.Add("ascending");
            comboBox2.Items.Add("descending");
            comboBox2.SelectedIndex = 0;
            comboBox1.SelectedIndex = 0;

            label2.Text = $"Records: {dataGridView1.RowCount - 1}";
        }

        private void btn_Click(object sender, EventArgs e)
        {
            AddAndChangeForm addAndChange = new AddAndChangeForm();
            if (sender == sortBtn)
            {
                if (comboBox2.SelectedIndex == 0)
                {
                    if (tableName == "CUSTOMERS")
                    {
                        using (SqlConnection myConnection = new SqlConnection(connectString))
                        {
                            myConnection.Open();
                            SqlCommand cmd = myConnection.CreateCommand();
                            cmd.CommandText = $"select * from {tableName} ORDER BY [{comboBox1.Text}] ASC;";
                            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                            DataSet data = new DataSet();
                            dataAdapter.Fill(data);
                            myConnection.Close();
                            dataGridView1.DataSource = data.Tables[0];
                        }
                    }
                    else if (tableName == "FIRMS")
                    {
                        using (SqlConnection myConnection = new SqlConnection(connectString))
                        {
                            myConnection.Open();
                            SqlCommand cmd = myConnection.CreateCommand();
                            cmd.CommandText = $"select * from {tableName} ORDER BY [{comboBox1.Text}] ASC;";
                            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                            DataSet data = new DataSet();
                            dataAdapter.Fill(data);
                            myConnection.Close();
                            dataGridView1.DataSource = data.Tables[0];
                        }
                    }
                    else if (tableName == "POSTS")
                    {
                        using (SqlConnection myConnection = new SqlConnection(connectString))
                        {
                            myConnection.Open();
                            SqlCommand cmd = myConnection.CreateCommand();
                            cmd.CommandText = $"select * from {tableName} ORDER BY [{comboBox1.Text}] ASC;";
                            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                            DataSet data = new DataSet();
                            dataAdapter.Fill(data);
                            myConnection.Close();
                            dataGridView1.DataSource = data.Tables[0];
                        }
                    }
                    else if (tableName == "MODELS")
                    {
                        using (SqlConnection myConnection = new SqlConnection(connectString))
                        {
                            myConnection.Open();
                            SqlCommand cmd = myConnection.CreateCommand();
                            cmd.CommandText = $"select {tableName}.id, FIRMS.Name as [Firm] ,{tableName}.Name from {tableName}, FIRMS where {tableName}.Firm = Firms.id ORDER BY [{comboBox1.Text}] ASC;";
                            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                            DataSet data = new DataSet();
                            dataAdapter.Fill(data);
                            myConnection.Close();
                            dataGridView1.DataSource = data.Tables[0];
                        }
                    }
                    else if (tableName == "STAFF")
                    {
                        using (SqlConnection myConnection = new SqlConnection(connectString))
                        {
                            myConnection.Open();
                            SqlCommand cmd = myConnection.CreateCommand();
                            cmd.CommandText = $"select {tableName}.id ,POSTS.Name as [Post], {tableName}.name,{tableName}.surname,  {tableName}.login, {tableName}.pwd, {tableName}.photo from {tableName}, POSTS where {tableName}.Post = POSTS.id ORDER BY [{comboBox1.Text}] ASC;";
                            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                            DataSet data = new DataSet();
                            dataAdapter.Fill(data);
                            myConnection.Close();
                            dataGridView1.DataSource = data.Tables[0];
                        }
                    }                   
                    else if (tableName == "PRODUCTS")
                    {
                        using (SqlConnection myConnection = new SqlConnection(connectString))
                        {
                            myConnection.Open();
                            SqlCommand cmd = myConnection.CreateCommand();
                            cmd.CommandText = $"select {tableName}.id ,{tableName}.Name, MODELS.Name as [Model], {tableName}.[Technical specifications], {tableName}.[Guarantee period], {tableName}.Image from {tableName}, MODELS where {tableName}.Model = MODELS.id ORDER BY [{comboBox1.Text}] ASC;";
                            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                            DataSet data = new DataSet();
                            dataAdapter.Fill(data);
                            myConnection.Close();
                            dataGridView1.DataSource = data.Tables[0];
                        }
                    }
                    else if (tableName == "ORDERS")
                    {
                        using (SqlConnection myConnection = new SqlConnection(connectString))
                        {
                            myConnection.Open();
                            SqlCommand cmd = myConnection.CreateCommand();
                            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                            DataSet data = new DataSet();
                            cmd.CommandText = $"select {tableName}.id ,PRODUCTS.Name as [Product], CUSTOMERS.Name as [Customer], {tableName}.Guarantee, {tableName}.[Date of receipt] from {tableName}, PRODUCTS, CUSTOMERS where {tableName}.Product = PRODUCTS.id and {tableName}.Customer = CUSTOMERS.id ORDER BY [{comboBox1.Text}] ASC;";
                            dataAdapter.Fill(data);
                            myConnection.Close();
                            dataGridView1.DataSource = data.Tables[0];
                        }
                    }
                    else if (tableName == "EXECUTION")
                    {
                        using (SqlConnection myConnection = new SqlConnection(connectString))
                        {
                            myConnection.Open();
                            SqlCommand cmd = myConnection.CreateCommand();
                            cmd.CommandText = $"select {tableName}.orderId ,STAFF.Surname as [Worker], {tableName}.[Type of repair], {tableName}.[Date of completion], {tableName}.message, {tableName}.[Date of issue], {tableName}.Cost from {tableName}, STAFF where {tableName}.Worker = STAFF.id ORDER BY [{comboBox1.Text}] ASC;";
                            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                            DataSet data = new DataSet();
                            dataAdapter.Fill(data);
                            myConnection.Close();
                            dataGridView1.DataSource = data.Tables[0];
                        }
                    }
                }
                else if (comboBox2.SelectedIndex == 1)
                {
                    if (tableName == "CUSTOMERS")
                    {
                        using (SqlConnection myConnection = new SqlConnection(connectString))
                        {
                            myConnection.Open();
                            SqlCommand cmd = myConnection.CreateCommand();
                            cmd.CommandText = $"select * from {tableName} ORDER BY {comboBox1.Text} DESC;";
                            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                            DataSet data = new DataSet();
                            dataAdapter.Fill(data);
                            myConnection.Close();
                            dataGridView1.DataSource = data.Tables[0];
                        }
                    }
                    else if (tableName == "FIRMS")
                    {
                        using (SqlConnection myConnection = new SqlConnection(connectString))
                        {
                            myConnection.Open();
                            SqlCommand cmd = myConnection.CreateCommand();
                            cmd.CommandText = $"select * from {tableName} ORDER BY {comboBox1.Text}  DESC;";
                            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                            DataSet data = new DataSet();
                            dataAdapter.Fill(data);
                            myConnection.Close();
                            dataGridView1.DataSource = data.Tables[0];
                        }
                    }
                    else if (tableName == "POSTS")
                    {
                        using (SqlConnection myConnection = new SqlConnection(connectString))
                        {
                            myConnection.Open();
                            SqlCommand cmd = myConnection.CreateCommand();
                            cmd.CommandText = $"select * from {tableName} ORDER BY [{comboBox1.Text}] DESC;";
                            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                            DataSet data = new DataSet();
                            dataAdapter.Fill(data);
                            myConnection.Close();
                            dataGridView1.DataSource = data.Tables[0];
                        }
                    }
                    else if (tableName == "MODELS")
                    {
                        using (SqlConnection myConnection = new SqlConnection(connectString))
                        {
                            myConnection.Open();
                            SqlCommand cmd = myConnection.CreateCommand();
                            cmd.CommandText = $"select {tableName}.id, FIRMS.Name as [Firm],{tableName}.Name from {tableName}, FIRMS where {tableName}.Firm = Firms.id ORDER BY [{comboBox1.Text}] DESC;";
                            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                            DataSet data = new DataSet();
                            dataAdapter.Fill(data);
                            myConnection.Close();
                            dataGridView1.DataSource = data.Tables[0];
                        }
                    }
                    else if (tableName == "STAFF")
                    {
                        using (SqlConnection myConnection = new SqlConnection(connectString))
                        {
                            myConnection.Open();
                            SqlCommand cmd = myConnection.CreateCommand();
                            cmd.CommandText = $"select {tableName}.id ,POSTS.Name as [Posts], {tableName}.name,{tableName}.surname,  {tableName}.login, {tableName}.pwd, {tableName}.photo from {tableName}, POSTS where {tableName}.Post = POSTS.id ORDER BY [{comboBox1.Text}] DESC;";
                            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                            DataSet data = new DataSet();
                            dataAdapter.Fill(data);
                            myConnection.Close();
                            dataGridView1.DataSource = data.Tables[0];
                        }
                    }
                    else if (tableName == "PRODUCTS")
                    {
                        using (SqlConnection myConnection = new SqlConnection(connectString))
                        {
                            myConnection.Open();
                            SqlCommand cmd = myConnection.CreateCommand();
                            cmd.CommandText = $"select {tableName}.id ,{tableName}.Name, MODELS.Name as [Model], {tableName}.[Technical specifications], {tableName}.[Guarantee period], {tableName}.Image from {tableName}, MODELS where {tableName}.Model = MODELS.id ORDER BY [{comboBox1.Text}] DESC;";
                            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                            DataSet data = new DataSet();
                            dataAdapter.Fill(data);
                            myConnection.Close();
                            dataGridView1.DataSource = data.Tables[0];
                        }
                    }
                    else if (tableName == "ORDERS")
                    {
                        using (SqlConnection myConnection = new SqlConnection(connectString))
                        {
                            myConnection.Open();
                            SqlCommand cmd = myConnection.CreateCommand();
                            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                            DataSet data = new DataSet();
                            cmd.CommandText = $"select {tableName}.id ,PRODUCTS.Name [as Product], CUSTOMERS.Name as [Customer], {tableName}.Guarantee, {tableName}.[Date of receipt] from {tableName}, PRODUCTS, CUSTOMERS where {tableName}.Product = PRODUCTS.id and {tableName}.Customer = CUSTOMERS.id ORDER BY [{comboBox1.Text}] DESC;";
                            dataAdapter.Fill(data);
                            myConnection.Close();
                            dataGridView1.DataSource = data.Tables[0];
                        }
                    }
                    else if (tableName == "EXECUTION")
                    {
                        using (SqlConnection myConnection = new SqlConnection(connectString))
                        {
                            myConnection.Open();
                            SqlCommand cmd = myConnection.CreateCommand();
                            cmd.CommandText = $"select {tableName}.orderId ,STAFF.Surname, {tableName}.[Type of repair], {tableName}.[Date of completion], {tableName}.message, {tableName}.[Date of issue], {tableName}.Cost from {tableName}, STAFF where {tableName}.Worker = STAFF.id ORDER BY [{comboBox1.Text}] DESC;";
                            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                            DataSet data = new DataSet();
                            dataAdapter.Fill(data);
                            myConnection.Close();
                            dataGridView1.DataSource = data.Tables[0];
                        }
                    }
                }

            }
            else if (sender == filterBtn)
            {
                if (tableName == "CUSTOMERS")
                {
                    using (SqlConnection myConnection = new SqlConnection(connectString))
                    {
                        myConnection.Open();
                        SqlCommand cmd = myConnection.CreateCommand();
                        cmd.CommandText = $"select * from {tableName}  where {comboBox4.Text} = {comboBox3.SelectedIndex};";
                        SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                        DataSet data = new DataSet();
                        dataAdapter.Fill(data);
                        myConnection.Close();
                        dataGridView1.DataSource = data.Tables[0];
                    }
                }
                else if (tableName == "FIRMS")
                {
                    using (SqlConnection myConnection = new SqlConnection(connectString))
                    {
                        myConnection.Open();
                        SqlCommand cmd = myConnection.CreateCommand();
                        cmd.CommandText = $"select * from {tableName}  where {comboBox4.Text} = {comboBox3.SelectedIndex};";
                        SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                        DataSet data = new DataSet();
                        dataAdapter.Fill(data);
                        myConnection.Close();
                        dataGridView1.DataSource = data.Tables[0];
                    }
                }
                else if (tableName == "POSTS")
                {
                    using (SqlConnection myConnection = new SqlConnection(connectString))
                    {
                        myConnection.Open();
                        SqlCommand cmd = myConnection.CreateCommand();
                        cmd.CommandText = $"select * from {tableName} where {comboBox4.Text} = {comboBox3.SelectedIndex};";
                        SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                        DataSet data = new DataSet();
                        dataAdapter.Fill(data);
                        myConnection.Close();
                        dataGridView1.DataSource = data.Tables[0];
                    }
                }
                else if (tableName == "MODELS")
                {
                    using (SqlConnection myConnection = new SqlConnection(connectString))
                    {
                        myConnection.Open();
                        SqlCommand cmd = myConnection.CreateCommand();
                        cmd.CommandText = $"select {tableName}.id, FIRMS.Name as [Firm] ,{tableName}.Name from {tableName}, FIRMS where {tableName}.Firm = Firms.id and {comboBox4.Text} = {comboBox3.SelectedIndex};";
                        SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                        DataSet data = new DataSet();
                        dataAdapter.Fill(data);
                        myConnection.Close();
                        dataGridView1.DataSource = data.Tables[0];
                    }
                }
                else if (tableName == "STAFF")
                {
                    using (SqlConnection myConnection = new SqlConnection(connectString))
                    {
                        myConnection.Open();
                        SqlCommand cmd = myConnection.CreateCommand();
                        cmd.CommandText = $"select {tableName}.id ,POSTS.Name as [Post], {tableName}.name,{tableName}.surname,  {tableName}.login, {tableName}.pwd, {tableName}.photo from {tableName}, POSTS where {tableName}.Post = POSTS.id and {comboBox4.Text} = {comboBox3.SelectedIndex};";
                        SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                        DataSet data = new DataSet();
                        dataAdapter.Fill(data);
                        myConnection.Close();
                        dataGridView1.DataSource = data.Tables[0];
                    }
                }
                else if (tableName == "PRODUCTS")
                {
                    using (SqlConnection myConnection = new SqlConnection(connectString))
                    {
                        myConnection.Open();
                        SqlCommand cmd = myConnection.CreateCommand();
                        cmd.CommandText = $"select {tableName}.id ,{tableName}.Name, MODELS.Name as [Model], {tableName}.[Technical specifications], {tableName}.[Guarantee period], {tableName}.Image from {tableName}, MODELS where {tableName}.Model = MODELS.id and {comboBox4.Text} = {comboBox3.SelectedIndex};";
                        SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                        DataSet data = new DataSet();
                        dataAdapter.Fill(data);
                        myConnection.Close();
                        dataGridView1.DataSource = data.Tables[0];
                    }
                }
                else if (tableName == "ORDERS")
                {
                    using (SqlConnection myConnection = new SqlConnection(connectString))
                    {
                        myConnection.Open();
                        SqlCommand cmd = myConnection.CreateCommand();
                        SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                        DataSet data = new DataSet();
                        cmd.CommandText = $"select {tableName}.id ,PRODUCTS.Name as [Product], CUSTOMERS.Name as [Customer], {tableName}.Guarantee, {tableName}.[Date of receipt] from {tableName}, PRODUCTS, CUSTOMERS where {tableName}.Product = PRODUCTS.id and {tableName}.Customer = CUSTOMERS.id and {comboBox4.Text} = {comboBox3.SelectedIndex};";
                        dataAdapter.Fill(data);
                        myConnection.Close();
                        dataGridView1.DataSource = data.Tables[0];
                        button1.Visible = true;
                        button2.Visible = true;
                        button3.Visible = true;
                        textBox2.Visible = true;
                    }
                }
                else if (tableName == "EXECUTION")
                {
                    using (SqlConnection myConnection = new SqlConnection(connectString))
                    {
                        myConnection.Open();
                        SqlCommand cmd = myConnection.CreateCommand();
                        cmd.CommandText = $"select {tableName}.orderId ,STAFF.Surname as [Worker], {tableName}.[Type of repair], {tableName}.[Date of completion], {tableName}.message, {tableName}.[Date of issue], {tableName}.Cost from {tableName}, STAFF where {tableName}.Worker = STAFF.id and {comboBox4.Text} = {comboBox3.SelectedIndex};";
                        SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                        DataSet data = new DataSet();
                        dataAdapter.Fill(data);
                        myConnection.Close();
                        dataGridView1.DataSource = data.Tables[0];
                    }
                    
                }

            }
            else if (sender == button1)
            {
                addAndChange.AddFlag = true;
                //add.ChangingId = int.Parse(textBox1.Text);
                addAndChange.ShowDialog();
                using (SqlConnection myConnection = new SqlConnection(connectString))
                {
                    myConnection.Open();
                    SqlCommand cmd = myConnection.CreateCommand();
                    cmd.CommandText = $"select {tableName}.id ,{tableName}.Name, MODELS.Name as [Model], {tableName}.[Technical specifications], {tableName}.[Guarantee period], {tableName}.Image from {tableName}, MODELS where {tableName}.Model = MODELS.id and {comboBox4.Text} = {comboBox3.SelectedIndex};";
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    DataSet data = new DataSet();
                    dataAdapter.Fill(data);
                    myConnection.Close();
                    dataGridView1.DataSource = data.Tables[0];
                }
            }
            else if (sender == button2)
            {
                int index = 0;
                addAndChange.ChangingId = int.Parse(textBox2.Text);
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (int.Parse(dataGridView1.Rows[i].Cells[0].Value.ToString()) == addAndChange.ChangingId)
                    {
                        index = i;
                        break;
                    }
                }
                string[] row = new string[dataGridView1.Rows[index].Cells.Count];
                for (int i = 0; i < dataGridView1.Rows[index].Cells.Count; i++)
                {
                    row[i] = dataGridView1.Rows[index].Cells[i].Value.ToString();
                }
                addAndChange.ChangingRow = row;
                addAndChange.AddFlag = false;
                addAndChange.ShowDialog();
                using (SqlConnection myConnection = new SqlConnection(connectString))
                {
                    myConnection.Open();
                    SqlCommand cmd = myConnection.CreateCommand();
                    cmd.CommandText = $"select {tableName}.id ,{tableName}.Name, MODELS.Name as [Model], {tableName}.[Technical specifications], {tableName}.[Guarantee period], {tableName}.Image from {tableName}, MODELS where {tableName}.Model = MODELS.id and {comboBox4.Text} = {comboBox3.SelectedIndex};";
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    DataSet data = new DataSet();
                    dataAdapter.Fill(data);
                    myConnection.Close();
                    dataGridView1.DataSource = data.Tables[0];
                }
                textBox2.Text = "";
            }
            else if (sender == button3)
            {
                string message = "Do you really want to edit the selected entry?"; ;

                if (MessageBox.Show(message, "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.No)
                {
                    return;
                }
                using (SqlConnection myConnection = new SqlConnection(connectString))
                {
                    myConnection.Open();
                    string cmd = $"DELETE FROM ORDERS WHERE ORDERS.id = @code";
                    SqlCommand cmd1 = new SqlCommand(cmd, myConnection);
                    SqlParameter pr1 = new SqlParameter("@code", textBox2.Text);
                    cmd1.Parameters.Add(pr1);
                    cmd1.ExecuteNonQuery();
                    dataGridView1.Columns.Clear();
                    myConnection.Close();
                    textBox2.Text = "";
                }
                using (SqlConnection myConnection = new SqlConnection(connectString))
                {
                    myConnection.Open();
                    SqlCommand cmd = myConnection.CreateCommand();
                    cmd.CommandText = $"select {tableName}.id ,{tableName}.Name, MODELS.Name as [Model], {tableName}.[Technical specifications], {tableName}.[Guarantee period], {tableName}.Image from {tableName}, MODELS where {tableName}.Model = MODELS.id and {comboBox4.Text} = {comboBox3.SelectedIndex};";
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    DataSet data = new DataSet();
                    dataAdapter.Fill(data);
                    myConnection.Close();
                    dataGridView1.DataSource = data.Tables[0];
                }
            }
            label2.Text = $"Records: {dataGridView1.RowCount - 1}";
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox3.Items.Clear();
            comboBox3.Items.Add("Select column");
            using (SqlConnection myConnection = new SqlConnection(connectString))
            {
                myConnection.Open();
                SqlCommand cmd = myConnection.CreateCommand();
                cmd.CommandText = $"select distinct {comboBox4.Text} from {tableName}";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                DataSet data = new DataSet();
                dataAdapter.Fill(data);
                myConnection.Close();
                for (int i = 0; i < data.Tables[0].Columns[0].Table.Rows.Count; i++)
                {
                    comboBox3.Items.Add(data.Tables[0].Columns[0].Table.Rows[i].ItemArray[0].ToString());
                }
            }
            label2.Text = $"Records: {dataGridView1.RowCount - 1}";
        }
    }
}
