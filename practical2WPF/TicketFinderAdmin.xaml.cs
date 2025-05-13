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
    /// Interaction logic for TicketFinderAdmin.xaml
    /// </summary>
    public partial class TicketFinderAdmin : UserControl
    {
        public TicketFinderAdmin()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
                /* using (SqlConnection con2 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\lenovo\Documents\AirlineBase.mdf;Integrated Security=True;Connect Timeout=30"))
                    {
                        con2.Open();
                        string query2 = "SELECT Destination,DepatureLocation,DateAvailable,DepTime FROM Flights WHERE FlightNumber = @v2";
                        SqlCommand cmd2 = new SqlCommand(query2, con2);
                        cmd2.Parameters.AddWithValue("@v2", FlightNO);
                        using (SqlDataReader dataRead = cmd2.ExecuteReader())
                        {
                            if (dataRead != null)
                            {
                                while (dataRead.Read())
                                {
                                    Desti = dataRead["Destination"].ToString();
                                    Departure = dataRead["DepatureLocation"].ToString();
                                    AviDate = dataRead["DateAvailable"].ToString();
                                    TimeDepart = dataRead["DepTime"].ToString();
                                }
                            }*/
                string path = "DataShare2.txt", UID = "";
            try
            {

                using (SqlConnection con2 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\lenovo\Documents\AirlineBase.mdf;Integrated Security=True;Connect Timeout=30"))
                {
                    con2.Open();
                    string query = "SELECT TicketID,Class,PriceTot,Passengers,FlightNo,Fname,Package,ClassPrice,CardType FROM Ticket WHERE UserID = @v1";
                    SqlCommand cmd5 = new SqlCommand(query, con2);
                    cmd5.Parameters.AddWithValue("@v1", box1.Text);
                    cmd5.Connection = con2;
                    SqlDataAdapter da = new SqlDataAdapter(cmd5);
                    DataTable dt = new DataTable("Ticket");
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
