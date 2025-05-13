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
    /// Interaction logic for MoreInfo.xaml
    /// </summary>
    public partial class MoreInfo : UserControl
    {
        string plane = "";
        public MoreInfo()
        {
            InitializeComponent();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                string path = "FIDshere.txt";
                using (StreamReader r1 = new StreamReader(path, true))
                {
                    plane = r1.ReadLine();
                }
                using (SqlConnection con2 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\lenovo\Documents\AirlineBase.mdf;Integrated Security=True;Connect Timeout=30"))
                {
                    con2.Open();
                    box1.Text = plane;
                    string query = "SELECT DateAvailable,Destination,DepatureLocation,DepTime,arrivalTime FROM Flights WHERE FlightNumber = @v1 ";
                    SqlCommand cmd = new SqlCommand(query,con2);
                    cmd.Parameters.AddWithValue("@v1",plane);
                    using (SqlDataReader dataRead = cmd.ExecuteReader())
                    {
                        if(dataRead != null)
                        {
                            while (dataRead.Read())
                            {
                                box2.Text = dataRead["Destination"].ToString();
                                box3.Text = dataRead["DepatureLocation"].ToString();
                                box4.Text = dataRead["DepTime"].ToString();
                                box5.Text = dataRead["arrivalTime"].ToString();
                            }
                        }
                    }
                    con2.Close();
                }
            }
            catch (Exception ee)
            {
                //MessageBox.Show(ee.Message.ToString());
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Content = new BookedTickets();
        }
    }
}
