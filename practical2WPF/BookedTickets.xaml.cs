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
    /// Interaction logic for BookedTickets.xaml
    /// </summary>
    public partial class BookedTickets : UserControl
    {
        public BookedTickets()
        {
            InitializeComponent();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void GridBooked_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            string path = "DataShare2.txt",UID = "";
            try
            {
                using (StreamReader r1 = new StreamReader(path, true))
                {
                    UID = r1.ReadLine();
                }
               
                using (SqlConnection con2 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\lenovo\Documents\AirlineBase.mdf;Integrated Security=True;Connect Timeout=30"))
                {
                    con2.Open();
                    string query = "SELECT TicketID,Class,PriceTot,Passengers,FlightNo,Fname,Package,ClassPrice,CardType FROM Ticket WHERE UserID = @v1";
                    SqlCommand cmd5 = new SqlCommand(query, con2);
                    cmd5.Parameters.AddWithValue("@v1", UID);
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string path1 = "FIDshere.txt";
            if (string.IsNullOrEmpty(box1.Text))
            {
                box1.Text = "Enter the flight number";
            }
            else
            {
                try
                {
                    using (StreamWriter w1 = new StreamWriter(path1, true))
                    {
                        w1.WriteLine(box1.Text);
                    }
                }
                catch (Exception ww)
                {
                    MessageBox.Show(ww.Message.ToString());
                }
                this.Content = new MoreInfo();
            }
           

        }
    }
}
