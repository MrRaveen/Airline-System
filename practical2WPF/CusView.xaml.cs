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
    /// Interaction logic for CusView.xaml
    /// </summary>
    public partial class CusView : UserControl
    {
        public CusView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(box1.Text) || string.IsNullOrEmpty(box2.Text))
            {
                if (string.IsNullOrEmpty(box1.Text))
                {
                    block1.Content = "Fill this field";
                }
                if (string.IsNullOrEmpty(box2.Text))
                {
                    block2.Content = "Fill this field";
                }
            }
            else
            {
                string path = "DataShare2.txt", UID = "";
                try
                {

                    using (SqlConnection con2 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\lenovo\Documents\AirlineBase.mdf;Integrated Security=True;Connect Timeout=30"))
                    {
                        con2.Open();
                        string query = "SELECT CusID,Fname,Lname,DOB,FrequentFlyierNo,Phone,CountryCallingCode,Email FROM Customer WHERE UserID = @v1 AND TicketID = @v2";
                        SqlCommand cmd5 = new SqlCommand(query, con2);
                        cmd5.Parameters.AddWithValue("@v1", box1.Text);
                        cmd5.Parameters.AddWithValue("@v2", box2.Text);
                        cmd5.Connection = con2;
                        SqlDataAdapter da = new SqlDataAdapter(cmd5);
                        DataTable dt = new DataTable("Customer");
                        da.Fill(dt);
                        gridBooked.ItemsSource = dt.DefaultView;
                        con2.Close();
                    }
                }
                catch (Exception ss)
                {
                    MessageBox.Show(ss.Message.ToString());
                }
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            string path = "DataShare2.txt", UID = "";
            try
            {

                using (SqlConnection con2 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\lenovo\Documents\AirlineBase.mdf;Integrated Security=True;Connect Timeout=30"))
                {
                    con2.Open();
                    string query = "SELECT CusID,Fname,Lname,DOB,FrequentFlyierNo,Phone,CountryCallingCode,Email FROM Customer";
                    SqlCommand cmd5 = new SqlCommand(query, con2);
                    cmd5.Connection = con2;
                    SqlDataAdapter da = new SqlDataAdapter(cmd5);
                    DataTable dt = new DataTable("Customer");
                    da.Fill(dt);
                    gridBooked.ItemsSource = dt.DefaultView;
                    con2.Close();
                }
            }
            catch (Exception ss)
            {
                MessageBox.Show(ss.Message.ToString());
            }
        }

        private void GridBooked_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
