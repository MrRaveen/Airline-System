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
    /// Interaction logic for AllFlights1.xaml
    /// </summary>
    public partial class AllFlights1 : UserControl
    {
        public AllFlights1()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string selected_date;
            DateTime? d1 = picker1.SelectedDate;
            selected_date = d1.Value.ToString("d");
            block1.Text = "";
            block1.Text = selected_date;
            try
            {
                using (SqlConnection con2 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\lenovo\Documents\AirlineBase.mdf;Integrated Security=True;Connect Timeout=30"))
                {
                    con2.Open();
                    string sqlQuery = "SELECT * FROM Flights WHERE DateAvailable = @v1 ";
                    SqlCommand cmd = new SqlCommand(sqlQuery, con2);
                    cmd.Parameters.AddWithValue("@v1",selected_date);
                    cmd.Connection = con2;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable("Flights");
                    da.Fill(dt);
                    gridAll.ItemsSource = dt.DefaultView;
                    con2.Close();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString());
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                using (SqlConnection con2 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\lenovo\Documents\AirlineBase.mdf;Integrated Security=True;Connect Timeout=30"))
                {
                    con2.Open();
                    string sqlQuery = "SELECT * FROM Flights";
                    SqlCommand cmd = new SqlCommand(sqlQuery, con2);
                    cmd.Connection = con2;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable("Flights");
                    da.Fill(dt);
                    gridAll.ItemsSource = dt.DefaultView;
                    con2.Close();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString());
            }
        }
    }
}
