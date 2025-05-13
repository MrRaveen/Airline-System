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
    /// Interaction logic for TotalBill.xaml
    /// </summary>
    public partial class TotalBill : UserControl
    {
        string TicID1 = "";
        public TotalBill()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            string path2 = "StoreTicid.txt";
            try
            {
                using (StreamReader r2 = new StreamReader(path2, true))
                {
                    TicID1 = r2.ReadLine();
                }
            }
            catch(Exception ss)
            {
                MessageBox.Show(ss.Message.ToString());
            }
            try
            {
                string FlightNO = "", PassengerNO = "", Class = "", Package = "";
                string tot = "";
                using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\lenovo\Documents\AirlineBase.mdf;Integrated Security=True;Connect Timeout=30"))
                {
                    con.Open();
                    string query = "SELECT FlightNo,Passengers,Class,Package,PriceTot FROM Ticket WHERE TicketID = @v1";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@v1", "T" + TicID1);
                    using (SqlDataReader dataRead = cmd.ExecuteReader())
                    {
                        if (dataRead != null)
                        {
                            while (dataRead.Read())
                            {
                                FlightNO = dataRead["FlightNo"].ToString();
                                PassengerNO = dataRead["Passengers"].ToString();
                                Class = dataRead["Class"].ToString();
                                Package  = dataRead["Package"].ToString();
                                tot = dataRead["PriceTot"].ToString();
                            }
                        }
                    }
                    lbl4.Content = PassengerNO;
                    lbl5.Content = FlightNO;
                    lbl9.Content = Class;
                    lbl10.Content = Package;
                    lbl11.Content = tot+"$";
                    lbl6.Content = "T" + TicID1;
                    con.Close();
                }
                string busSeats = "", ComSeats = "";
                using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\lenovo\Documents\AirlineBase.mdf;Integrated Security=True;Connect Timeout=30"))
                {
                    con.Open();
                    string query4 = "SELECT businessSeats,CommunitySeats FROM Flights WHERE FlightNumber = @v1";
                    SqlCommand cmd = new SqlCommand(query4, con);
                    cmd.Parameters.AddWithValue("@v1",FlightNO);
                    using (SqlDataReader dataRead = cmd.ExecuteReader())
                    {
                        if (dataRead != null)
                        {
                            while (dataRead.Read())
                            {
                               busSeats = dataRead["businessSeats"].ToString();
                               ComSeats = dataRead["CommunitySeats"].ToString();
                            }
                        }
                    }
                    con.Close();
                }
                int NewSeats = 0, bseats = 0, Cseats = 0,passengers = 0;
                bseats = Convert.ToInt32(busSeats);
                Cseats = Convert.ToInt32(ComSeats);
                passengers = Convert.ToInt32(PassengerNO);
                if (Class == "Business")
                {
                    NewSeats = bseats - passengers;
                    string query4 = "UPDATE Flights SET businessSeats = @v1 WHERE FlightNumber = @v2";
                    using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\lenovo\Documents\AirlineBase.mdf;Integrated Security=True;Connect Timeout=30"))
                    {
                        con.Open();
                        using (SqlCommand cmd = new SqlCommand(query4, con))
                        {
                            cmd.Parameters.AddWithValue("@v1", NewSeats);
                            cmd.Parameters.AddWithValue("@v2", FlightNO);
                            cmd.ExecuteNonQuery();
                        }
                        con.Close();
                    }

                }
                else
                {
                    NewSeats = Cseats - passengers;
                    string query4 = "UPDATE Flights SET CommunitySeats = @v1 WHERE FlightNumber = @v2";
                    using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\lenovo\Documents\AirlineBase.mdf;Integrated Security=True;Connect Timeout=30"))
                    {
                        con.Open();
                        using (SqlCommand cmd = new SqlCommand(query4, con))
                        {
                            cmd.Parameters.AddWithValue("@v1", NewSeats);
                            cmd.Parameters.AddWithValue("@v2", FlightNO);
                            cmd.ExecuteNonQuery();
                        }
                        con.Close();
                    }
                }
                    // string query4 = "UPDATE Flights SET PriceTot = @v1 WHERE TicketID = @v2";
                    string Desti = "", Departure = "", AviDate = "", TimeDepart = "";
                using (SqlConnection con2 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\lenovo\Documents\AirlineBase.mdf;Integrated Security=True;Connect Timeout=30"))
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
                        }
                        lbl1.Content = Desti;
                        lbl2.Content = Departure;
                        lbl7.Content = AviDate;
                        lbl8.Content = TimeDepart;
                    }
                    con2.Close();

                }
                string path3 = "DataShare2.txt",UID = "";
                using (StreamReader r2 = new StreamReader(path3, true))
                {
                    UID = r2.ReadLine();
                }
            }
            catch(Exception ee)
            {
                MessageBox.Show(ee.Message.ToString());
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Content = new CustomerInfoPicker();
        }

        private void Btn2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string path2 = "StoreTicid.txt";
                using (StreamReader r2 = new StreamReader(path2, true))
                {
                    TicID1 = r2.ReadLine();
                }
                string sqlquery = "DELETE FROM Ticket WHERE TicketID = @v1;";
                using (SqlConnection con3 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\lenovo\Documents\AirlineBase.mdf;Integrated Security=True;Connect Timeout=30"))
                {
                    con3.Open();
                    using (SqlCommand cmd = new SqlCommand(sqlquery, con3))
                    {
                        cmd.Parameters.AddWithValue("@v1", "T"+TicID1);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Ticket Cancelled!!");
                    }
                    con3.Close();
                }
            }
            catch (Exception ll)
            {
                MessageBox.Show(ll.Message.ToString());
            }
        }
    }
}
