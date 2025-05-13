using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.IO;

namespace practical2WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string UserID; //Variables
        string Uname;
        string pass;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnMini_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void BtnMax_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Logbtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(box1.Text) || string.IsNullOrEmpty(box2.Password) || box1.Text.Any(char.IsDigit))
            {
                if (string.IsNullOrEmpty(box1.Text) && string.IsNullOrEmpty(box2.Password)) {
                    lbl1.Content = "Enter the username";
                    lbl2.Content = "Enter the password";
                    box1.Focus();
                    box2.Focus();
                }
                else if (string.IsNullOrEmpty(box1.Text))
                {
                    lbl1.Content = "Enter the username";
                    box1.Focus();
                }
                else if (string.IsNullOrEmpty(box2.Password))
                {
                    lbl2.Content = "Enter the password";
                    box2.Focus();
                }
                 else if(box1.Text.Any(char.IsDigit)) {
                    lbl1.Content = "Do not enter numbers";
                    box1.Focus();
                 }
                else
                {
                    MessageBox.Show("ERROR OCURED");
                }
            }
            else
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\lenovo\Documents\AirlineBase.mdf;Integrated Security=True;Connect Timeout=30"))
                    {
                        con.Open();
                        string query = "SELECT UserID,UserName,Password FROM AccInfo WHERE UserName = @v1 AND Password = @v2";
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@v1", box1.Text);
                        cmd.Parameters.AddWithValue("@v2", box2.Password);
                        using (SqlDataReader dataRead = cmd.ExecuteReader())
                        {
                            if (dataRead != null)
                            {
                                while (dataRead.Read())
                                {
                                    UserID = dataRead["UserID"].ToString();
                                    Uname = dataRead["UserName"].ToString();
                                    pass = dataRead["Password"].ToString();
                                    //MessageBox.Show(planeID);
                                }
                            }
                            if (Uname == null || pass == null)
                            {
                                MessageBox.Show("Incorrect Username or password");
                                box1.Focus();
                                box2.Focus();
                            }
                            else
                            {
                                string path = "DataShare2.txt";
                                try
                                {
                                    using (StreamWriter writer = new StreamWriter(path, true))
                                    {
                                        writer.WriteLine(UserID+"\n"+Uname+"\n"+pass+"\n");
                                    }
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message.ToString());
                                }
                                MainMenu m1 = new MainMenu();
                                this.Hide();
                                m1.Show();
                            }
                        }
                        con.Close();
                    }
                }
                catch (Exception ee)
                { MessageBox.Show(ee.Message.ToString()); }
            }

            
        }

        private void TextBlock_MouseEnter(object sender, MouseEventArgs e)
        {
           
        }

        private void Label_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            SignUp s1 = new SignUp();
            this.Hide();
            s1.Show();
        }

        private void AdBtn_Click(object sender, RoutedEventArgs e)
        {
           

        }

        private void Adbtn_Click_1(object sender, RoutedEventArgs e)
        {
            string AdID = "", adName = "", adPassword = "";
            if (string.IsNullOrEmpty(box1.Text) || string.IsNullOrEmpty(box2.Password) || box1.Text.Any(char.IsDigit))
            {
                if (string.IsNullOrEmpty(box1.Text) && string.IsNullOrEmpty(box2.Password))
                {
                    lbl1.Content = "Enter the username";
                    lbl2.Content = "Enter the password";
                    box1.Focus();
                    box2.Focus();
                }
                else if (string.IsNullOrEmpty(box1.Text))
                {
                    lbl1.Content = "Enter the username";
                    box1.Focus();
                }
                else if (string.IsNullOrEmpty(box2.Password))
                {
                    lbl2.Content = "Enter the password";
                    box2.Focus();
                }
                else if (box1.Text.Any(char.IsDigit))
                {
                    lbl1.Content = "Do not enter numbers";
                    box1.Focus();
                }
                else
                {
                    MessageBox.Show("ERROR OCURED");
                }
            }
            else
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\lenovo\Documents\AirlineBase.mdf;Integrated Security=True;Connect Timeout=30"))
                    {
                        con.Open();
                        string query = "SELECT AdminID,name,password FROM AdminUsers WHERE name = @v1 AND password = @v2";
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@v1", box1.Text);
                        cmd.Parameters.AddWithValue("@v2", box2.Password);
                        using (SqlDataReader dataRead = cmd.ExecuteReader())
                        {
                            if (dataRead != null)
                            {
                                while (dataRead.Read())
                                {
                                    AdID = dataRead["AdminID"].ToString();
                                    adName = dataRead["name"].ToString();
                                    adPassword = dataRead["password"].ToString();
                                    //MessageBox.Show(adName);
                                }
                            }
                        }
                        con.Close();
                        if (adName == box1.Text && adPassword == box2.Password)
                        {
                            //MessageBox.Show("PASSE");
                            // MessageBox.Show("TESTp");
                            //ADMIN WINDOW CALL
                             AdminWindow m1 = new AdminWindow();
                             this.Hide();
                             m1.Show();
                        }
                        else
                        {
                            MessageBox.Show("Incorrect Username or password");
                            box1.Focus();
                            box2.Focus();
                        }
                        /* if (adName == null || adPassword == null)
                         {
                             MessageBox.Show(adName);
                             MessageBox.Show("Incorrect Username or password");
                             box1.Focus();
                             box2.Focus();
                         }
                         else
                         {
                             // MessageBox.Show("TESTp");
                             //ADMIN WINDOW CALL
                             // AdminWindow m1 = new AdminWindow();
                             //this.Hide();
                             //m1.Show();
                         }*/
                    }
                }
                catch (Exception ee)
                { MessageBox.Show(ee.Message.ToString()); }
            }
        }
    }
}
