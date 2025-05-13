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
    /// Interaction logic for FlightEnter.xaml
    /// </summary>
    public partial class FlightEnter : UserControl
    {
        public FlightEnter()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            //
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(box1.Text) || string.IsNullOrEmpty(box2.Text) || string.IsNullOrEmpty(box10.Text) || string.IsNullOrEmpty(box9.Text) || string.IsNullOrEmpty(box8.Text) || string.IsNullOrEmpty(box7.Text) || string.IsNullOrEmpty(box6.Text) || string.IsNullOrEmpty(box5.Text) || string.IsNullOrEmpty(box4.Text) || string.IsNullOrEmpty(box3.Text))
            {
                MessageBox.Show("Please enter data to relavant fields");
            }
            else
            {
                string path = "PlaneIDstore.txt";
                int FlightID = 0;
                using (StreamReader reader = new StreamReader(path, true))
                {
                    FlightID = Convert.ToInt32(reader.ReadLine());
                }
                FlightID++;
                File.WriteAllText(path, string.Empty);
                using (StreamWriter writer = new StreamWriter(path, true))
                {
                    writer.WriteLine(FlightID.ToString());
                }
                lbl1.Content = "F" + FlightID;
                string query = "INSERT INTO Flights (FlightNumber,Name,DateAvailable,Destination,businessSeats,CommunitySeats,PriceBusiness,priceCommunity,DepatureLocation,DepTime,arrivalTime) VALUES (@v1,@v2,@v3,@v4,@v5,@v6,@v7,@v8,@v9,@v10,@v11)";
                using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\lenovo\Documents\AirlineBase.mdf;Integrated Security=True;Connect Timeout=30"))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@v1", lbl1.Content);
                        cmd.Parameters.AddWithValue("@v2", box1.Text);
                        cmd.Parameters.AddWithValue("@v3", box2.Text);
                        cmd.Parameters.AddWithValue("@v4", box10.Text);
                        cmd.Parameters.AddWithValue("@v5", Convert.ToInt32(box9.Text));
                        cmd.Parameters.AddWithValue("@v6", Convert.ToInt32(box8.Text));
                        cmd.Parameters.AddWithValue("@v7", Convert.ToDouble(box7.Text));
                        cmd.Parameters.AddWithValue("@v8", Convert.ToDouble(box6.Text));
                        cmd.Parameters.AddWithValue("@v9", box5.Text);
                        cmd.Parameters.AddWithValue("@v10", box4.Text);
                        cmd.Parameters.AddWithValue("@v11", box3.Text);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Data Saved");
                    }
                    con.Close();
                }
            }
           
                /*string query = "INSERT INTO Ticket (TicketID,FlightNo,Fname,UserID) VALUES (@v1,@v2,@v3,@v4)";
                        using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\lenovo\Documents\AirlineBase.mdf;Integrated Security=True;Connect Timeout=30"))
                        {
                            con.Open();
                            using (SqlCommand cmd = new SqlCommand(query, con))
                            {
                                cmd.Parameters.AddWithValue("@v1", "T" + TicID1);
                                cmd.Parameters.AddWithValue("@v2", flightNo);
                                cmd.Parameters.AddWithValue("@v3", FName);
                                cmd.Parameters.AddWithValue("@v4", UID2);
                                cmd.ExecuteNonQuery();
                            }
                            con.Close();
                        }
                    }
                    catch (Exception ee)
                    {
                        MessageBox.Show(ee.Message.ToString());
                    }*/
            }
    }
}
