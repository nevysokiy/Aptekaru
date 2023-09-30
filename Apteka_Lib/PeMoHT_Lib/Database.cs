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

namespace PeMoHT_Lib
{
    public class Database
    {
        private static string connectString = "Data Source = LAPTOP-M008LR82;Initial Catalog = Pr_Lab2;" +
               "Integrated Security = true;";

        public double CalcProfit()
        {
            using (SqlConnection myConnection = new SqlConnection(connectString))
            {

                myConnection.Open();
                SqlCommand cmd = myConnection.CreateCommand();
                cmd.CommandText = $"Select Sum(Cost) From EXECUTION;";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                DataSet data = new DataSet();
                dataAdapter.Fill(data);
                myConnection.Close();
                return Convert.ToDouble(data.Tables[0].Columns[0].Table.Rows[0].ItemArray[0]);
            }
        }

        public string TechinicianWithMostExpensiveRepair()
        {
            using (SqlConnection myConnection = new SqlConnection(connectString))
            {

                myConnection.Open();
                SqlCommand cmd = myConnection.CreateCommand();
                cmd.CommandText = $"select surname from [STAFF], EXECUTION where EXECUTION.Worker = STAFF.id and EXECUTION.Cost = (select max(EXECUTION.Cost) from EXECUTION);";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                DataSet data = new DataSet();
                dataAdapter.Fill(data);
                myConnection.Close();
                return data.Tables[0].Columns[0].Table.Rows[0].ItemArray[0].ToString();
            }
        }

        public string MostExpensiveSalary()
        {
            using (SqlConnection myConnection = new SqlConnection(connectString))
            {

                myConnection.Open();
                SqlCommand cmd = myConnection.CreateCommand();
                cmd.CommandText = $"select surname from [STAFF], POSTS where POSTS.id = STAFF.Post and POSTS.Salary = (select max(POSTS.Salary) from POSTS);";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                DataSet data = new DataSet();
                dataAdapter.Fill(data);
                myConnection.Close();
                return data.Tables[0].Columns[0].Table.Rows[0].ItemArray[0].ToString();
            }
        }

        public string MostExpensiveRepair()
        {
            using (SqlConnection myConnection = new SqlConnection(connectString))
            {

                myConnection.Open();
                SqlCommand cmd = myConnection.CreateCommand();
                cmd.CommandText = $"select PRODUCTS.Name from PRODUCTS, EXECUTION, ORDERS where EXECUTION.orderId = ORDERS.id and ORDERS.Product = PRODUCTS.id and EXECUTION.Cost = (select max(EXECUTION.Cost) from EXECUTION);";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                DataSet data = new DataSet();
                dataAdapter.Fill(data);
                myConnection.Close();
                return data.Tables[0].Columns[0].Table.Rows[0].ItemArray[0].ToString();
            }
        }

        public int CountOfTechnician()
        {
            using (SqlConnection myConnection = new SqlConnection(connectString))
            {

                myConnection.Open();
                SqlCommand cmd = myConnection.CreateCommand();
                cmd.CommandText = $"select COUNT(Post) from STAFF where Post = 1";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                DataSet data = new DataSet();
                dataAdapter.Fill(data);
                myConnection.Close();
                return Convert.ToInt32(data.Tables[0].Columns[0].Table.Rows[0].ItemArray[0]);
            }
        }
    }

}
