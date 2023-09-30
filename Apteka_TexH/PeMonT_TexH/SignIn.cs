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
    public partial class SignIn : Form
    {
        private static string connectString = "Data Source = LAPTOP-M008LR82;Initial Catalog = Pr_Lab2;" +
                "Integrated Security = true;";
        private int attempts = 0;
        private string text = String.Empty;
        private int time = 0;
        private int allTime = 180;
        public SignIn()
        {
            InitializeComponent();
        }

        private Bitmap CreateImage(int Width, int Height)
        {
            Random rnd = new Random();

            //Создадим изображение
            Bitmap result = new Bitmap(Width, Height);

            //Вычислим позицию текста
            int Xpos = rnd.Next(0, Width - 50);
            int Ypos = rnd.Next(15, Height - 15);

            //Добавим различные цвета
            Brush[] colors = { Brushes.Black,
                     Brushes.Red,
                     Brushes.RoyalBlue,
                     Brushes.Green };

            //Укажем где рисовать
            Graphics g = Graphics.FromImage((Image)result);

            //Пусть фон картинки будет серым
            g.Clear(Color.Gray);

            //Сгенерируем текст
            text = String.Empty;
            string ALF = "1234567890QWERTYUIOPASDFGHJKLZXCVBNM";
            for (int i = 0; i < 5; ++i)
                text += ALF[rnd.Next(ALF.Length)];

            //Нарисуем сгенирируемый текст
            g.DrawString(text,
                         new Font("Arial", 15),
                         colors[rnd.Next(colors.Length)],
                         new PointF(Xpos, Ypos));

            //Добавим немного помех
            /////Линии из углов
            g.DrawLine(Pens.Black,
                       new Point(0, 0),
                       new Point(Width - 1, Height - 1));
            g.DrawLine(Pens.Black,
                       new Point(0, Height - 1),
                       new Point(Width - 1, 0));
            ////Белые точки
            for (int i = 0; i < Width; ++i)
                for (int j = 0; j < Height; ++j)
                    if (rnd.Next() % 20 == 0)
                        result.SetPixel(i, j, Color.White);

            return result;
        }

        private void SignInBtn_Click(object sender, EventArgs e)
        {
            using (SqlConnection myConnection = new SqlConnection(connectString))
            {
                myConnection.Open();
                SqlCommand cmd = myConnection.CreateCommand();
                cmd.CommandText = "SELECT STAFF.[name], [surname],[login],[pwd], POSTS.[Name], STAFF.id  from STAFF, POSTS where POSTS.id = Post";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                DataSet data = new DataSet();
                dataAdapter.Fill(data);
                myConnection.Close();
                bool flag = false;
                for (int i = 0; i < data.Tables[0].Columns[0].Table.Rows.Count; i++)
                {
                    if (attempts == 0)
                    {
                        if (textBox1.Text == data.Tables[0].Columns[2].Table.Rows[i].ItemArray[2].ToString() && textBox2.Text == data.Tables[0].Columns[3].Table.Rows[i].ItemArray[3].ToString())
                        {
                            myConnection.Open();
                            cmd = myConnection.CreateCommand();
                            cmd.CommandText = $"insert into LOGIN_HISTORY values ( {data.Tables[0].Columns[0].Table.Rows[i].ItemArray[5]} , '{DateTime.Now}', 'True');";
                            cmd.ExecuteNonQuery();
                            myConnection.Close();
                            flag = true;
                            if (data.Tables[0].Columns[2].Table.Rows[i].ItemArray[4].ToString() == "Administrator")
                            {
                                MainMenu mainMenu = new MainMenu(Convert.ToInt32(data.Tables[0].Columns[2].Table.Rows[i].ItemArray[5]));
                                mainMenu.ShowDialog();

                            }
                            else
                            {
                                MainMenuStaff mainMenu = new MainMenuStaff(Convert.ToInt32(data.Tables[0].Columns[2].Table.Rows[i].ItemArray[5]));
                                mainMenu.ShowDialog();
                            }
                        }
                    }
                    else if (attempts == 1)
                    {
                        if (textBox3.Text == text && textBox1.Text == data.Tables[0].Columns[2].Table.Rows[i].ItemArray[2].ToString() && textBox2.Text == data.Tables[0].Columns[3].Table.Rows[i].ItemArray[3].ToString())
                        {
                            myConnection.Open();
                            cmd = myConnection.CreateCommand();
                            cmd.CommandText = $"insert into LOGIN_HISTORY values ( {data.Tables[0].Columns[0].Table.Rows[i].ItemArray[5]} , '{DateTime.Now}', 'True');";
                            cmd.ExecuteNonQuery();
                            myConnection.Close();
                            flag = true;
                            if (data.Tables[0].Columns[2].Table.Rows[i].ItemArray[4].ToString() == "Administrator")
                            {
                                MainMenu mainMenu = new MainMenu(Convert.ToInt32(data.Tables[0].Columns[2].Table.Rows[i].ItemArray[5]));
                                mainMenu.ShowDialog();

                            }
                            else
                            {
                                MainMenuStaff mainMenu = new MainMenuStaff(Convert.ToInt32(data.Tables[0].Columns[2].Table.Rows[i].ItemArray[5]));
                                mainMenu.ShowDialog();
                            }
                        }
                    }
                    
                }
                if (!flag)
                {
                    for (int i = 0; i < data.Tables[0].Columns[0].Table.Rows.Count; i++)
                    {
                        if (data.Tables[0].Columns[0].Table.Rows[i].ItemArray[2].ToString() == textBox1.Text)
                        {
                            myConnection.Open();
                            cmd = myConnection.CreateCommand();
                            cmd.CommandText = $"insert into LOGIN_HISTORY values ( {Convert.ToInt32(data.Tables[0].Columns[0].Table.Rows[i].ItemArray[5])} , '{DateTime.Now}', 'True');";
                            cmd.ExecuteNonQuery();
                            myConnection.Close();
                        }
                    }
                    
                    MessageBox.Show("Неверный логин или пароль");
                    attempts++;
                    if (attempts == 1)
                    {
                        pictureBox1.Image = this.CreateImage(pictureBox1.Width, pictureBox1.Height);
                        pictureBox1.Visible = true;
                        refreshCaptchaBtn.Visible = true;
                        textBox3.Visible = true;
                    }
                    else if (attempts == 2)
                    {
                        textBox3.Text = "";
                        pictureBox1.Image = this.CreateImage(pictureBox1.Width, pictureBox1.Height);
                        signInBtn.Enabled = false;
                        label4.Text = "You're blocked! Time left: 180 seconds";
                        label4.Visible = true;
                        timer1.Start();
                    }
                    else if (attempts == 3)
                    {
                        Application.Restart();
                        Environment.Exit(0);
                    }
                }
            }
        }

        private void ShowPwdBtn_Click(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = !textBox2.UseSystemPasswordChar;
        }

        private void refreshCaptchaBtn_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = this.CreateImage(pictureBox1.Width, pictureBox1.Height);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            time++;
            label4.Text = $"You're blocked! Time left: {allTime - time} seconds";
            if (time == 180)
            {
                timer1.Stop();
                label4.Visible = false;
                signInBtn.Enabled = true;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
