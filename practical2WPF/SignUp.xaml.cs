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
using System.Data;
using System.Configuration;
using System.IO;
using System.Windows.Controls;
using System.Windows.Data;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace practical2WPF
{
    /// <summary>
    /// Interaction logic for SignUp.xaml
    /// </summary>
    public partial class SignUp : Window
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private void SignUpButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(box1.Text) || string.IsNullOrEmpty(box3.Text) || string.IsNullOrEmpty(psbox2.Password) || string.IsNullOrEmpty(psbox3.Password))
            {
                if (string.IsNullOrEmpty(box1.Text))
                {
                    block1.Text = "Fill this field";
                }
                if (string.IsNullOrEmpty(box3.Text))
                {
                    block2.Text = "Fill this field";
                }
                if (string.IsNullOrEmpty(psbox2.Password))
                {
                    block3.Text = "Fill this field";
                }
                if (string.IsNullOrEmpty(psbox3.Password))
                {
                    block4.Text = "Fill this field";
                }
                if (box1.Text.Any(char.IsDigit))
                {
                    block1.Text = "Do not enter numbers";
                }
                if (psbox2.Password != psbox3.Password)
                {
                    block3.Text = "Passwords do not match";
                    block4.Text = "Passwords do not match";
                }
            }
            else if (box1.Text.Any(char.IsDigit))
            {
                block1.Text = "Do not enter numbers";
            }
            else if (psbox2.Password != psbox3.Password)
            {
                block3.Text = "Passwords do not match";
                block4.Text = "Passwords do not match";
            }
            else
            {
                block1.Text = "";
                block2.Text = "";
                block3.Text = "";
                block4.Text = "";
                try
                {
                    string path = "UserIDgen.txt";
                    int ID = 0;
                    using (StreamReader reader = new StreamReader(path, true))
                    {
                        ID = Convert.ToInt32(reader.ReadLine());
                    }
                    ID++;
                    File.WriteAllText(path, string.Empty);
                    using (StreamWriter writter = new StreamWriter(path, true))
                    {
                        writter.WriteLine(ID.ToString());
                    }
                    string query = "INSERT INTO AccInfo (UserID,UserName,Password,Email) VALUES (@v1,@v2,@v3,@v4)";
                    using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\lenovo\Documents\AirlineBase.mdf;Integrated Security=True;Connect Timeout=30"))
                    {
                        con.Open();
                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@v1", "U" + ID.ToString());
                            cmd.Parameters.AddWithValue("@v2", box1.Text);
                            cmd.Parameters.AddWithValue("@v3", psbox2.Password);
                            cmd.Parameters.AddWithValue("@v4", box3.Text);
                            cmd.ExecuteNonQuery();
                        }
                        con.Close();
                        MessageBox.Show("Account created");
                        MainWindow m1 = new MainWindow();
                        this.Hide();
                        m1.Show();
                    }
                }
                catch (Exception ss)
                {
                    MessageBox.Show(ss.Message.ToString());
                }
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MainWindow m1 = new MainWindow();
            this.Hide();
            m1.Show();
        }
    }
}
