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
    /// Interaction logic for DataGrid.xaml
    /// </summary>
    /// 
  
    public partial class DataGrid : UserControl
    {
        string  d1, s1,p1;
        int passengers = 0,status =0;
       // private readonly DataRowView selectedItem;

        public DataGrid()
        {
            InitializeComponent();
            
        }

        private void UserControl_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {
           
        }

        private void UserControl_ContextMenuOpening_1(object sender, ContextMenuEventArgs e)
        {
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Grid1_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
           // MessageBox.Show("hellow");
           
        }

        private void Grid1_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void Grid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            

        }

        private void Box7_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void Rad1_Checked(object sender, RoutedEventArgs e)
        {
           // status = 1;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrEmpty(box3.Text) || string.IsNullOrEmpty(box5.Text))
            {
                if (string.IsNullOrEmpty(box3.Text))
                {
                    block1.Text = "Fill this field";
                }
                if (string.IsNullOrEmpty(box5.Text))
                {
                    block2.Text = "Fill this field";
                }
            }
            else
            {
                string flightNo, FName;
                flightNo = box3.Text;
                FName = box5.Text;
                try
                {
                    string path = "DataShare2.txt", path2 = "StoreTicid.txt", UID2, TicID1;
                    int TicID = 0;
                    using (StreamReader r1 = new StreamReader(path, true))
                    {
                        UID2 = r1.ReadLine();
                    }
                    using (StreamReader r2 = new StreamReader(path2, true))
                    {
                        TicID1 = r2.ReadLine();
                    }
                    TicID = Convert.ToInt32(TicID1);
                    File.WriteAllText(path2, string.Empty);
                    TicID = TicID + 1;
                    TicID1 = TicID.ToString();
                    using (StreamWriter writer = new StreamWriter(path2, true))
                    {
                        writer.WriteLine(TicID1);
                    }
                    string query = "INSERT INTO Ticket (TicketID,FlightNo,Fname,UserID) VALUES (@v1,@v2,@v3,@v4)";
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
                }//END
                string path4 = "ContentShare5.txt";
                using (StreamWriter writer2 = new StreamWriter(path4, true))
                {
                    writer2.WriteLine(box3.Text);
                }
                this.Content = new BookTicket2UserControl1();
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            string path = "DataSender.txt";
            try
            {
                using (StreamReader r1 = new StreamReader(path, true))
                {
                    d1 = r1.ReadLine();
                    s1 = r1.ReadLine();
                    p1 = r1.ReadLine();
                }
            }
            
            catch (Exception ss)
            {
                MessageBox.Show(ss.Message.ToString());
            }
            try
            {
                passengers = Convert.ToInt32(p1);
                using (SqlConnection con2 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\lenovo\Documents\AirlineBase.mdf;Integrated Security=True;Connect Timeout=30"))
                {
                    con2.Open();
                    string sqlQuery = "SELECT * FROM Flights WHERE Destination = @v2 AND DepatureLocation = @v3 AND (businessSeats >= @v4 OR CommunitySeats >= @v5)";
                    SqlCommand cmd = new SqlCommand(sqlQuery, con2);
                    cmd.Parameters.AddWithValue("@v2", d1);
                    cmd.Parameters.AddWithValue("@v3", s1);
                    cmd.Parameters.AddWithValue("@v4",passengers);
                    cmd.Parameters.AddWithValue("@v5",passengers);
                    cmd.Connection = con2;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable("Flights");
                    da.Fill(dt);
                    grid1.ItemsSource = dt.DefaultView;
                    con2.Close();
                }
            }
            catch (Exception ee)
            {

            }
            // File.Delete(path);
            File.WriteAllText(path, string.Empty);//TO DELETE THE CONTENTS
        }
    }
}
