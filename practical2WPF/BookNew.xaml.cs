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
using System.Windows.Controls;
using System.IO;

namespace practical2WPF
{
    /// <summary>
    /// Interaction logic for BookNew.xaml
    /// </summary>
    /// 
    
    public partial class BookNew : UserControl
    {
        string test5,test8,text9;
      
        public BookNew()
        {
            InitializeComponent();
        }
       
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int status = 0;
            if (string.IsNullOrEmpty(box1.Text) || string.IsNullOrEmpty(box2.Text) || string.IsNullOrEmpty(box3.Text))
            {
                // MessageBox.Show("ERROR");
                if (string.IsNullOrEmpty(box1.Text))
                {
                    lbl1.Content = "Fill this field";
                }
                
                if (string.IsNullOrEmpty(box2.Text))
                {
                    lbl2.Content = "Fill this field";
                }

                if (string.IsNullOrEmpty(box3.Text))
                {
                    lbl3.Content = "Fill this field";
                }
                if (box1.Text.Any(char.IsDigit))
                {
                    lbl1.Content = "Do not enter numbers";
                }
                if (box2.Text.Any(char.IsDigit))
                {
                    lbl2.Content = "Do not enter numbers";
                }
            }
            else if (box1.Text.Any(char.IsDigit) || box2.Text.Any(char.IsDigit))
            {
                if (box1.Text.Any(char.IsDigit))
                {
                    lbl1.Content = "Do not enter numbers";
                }

                if (box2.Text.Any(char.IsDigit))
                {
                    lbl2.Content = "Do not enter numbers";
                }
            }
            else
            {
                lbl1.Content = "";
                lbl2.Content = "";
                lbl3.Content = "";
                test5 = box1.Text;
                test8 = box2.Text;
                text9 = box3.Text;
                string path = "DataSender.txt";//to store the destination and departure
                string path2 = "ShareData6.txt";//to store the number of passengers
                try
                {
                    using (StreamWriter writer = new StreamWriter(path, true))
                    {
                        writer.WriteLine(test5 + "\n" + test8 + "\n" + text9);
                    }
                    using (StreamWriter writer2 = new StreamWriter(path2, true))
                    {
                        writer2.WriteLine(box3.Text);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR");
                }
                try
                {
                    // this.Content = new DataGrid();
                    // this.mainContentControl2.Content = new DataGrid();
                    string destination = box1.Text, source = box2.Text;
                    using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\lenovo\Documents\AirlineBase.mdf;Integrated Security=True;Connect Timeout=30"))
                    {
                        con.Open();
                        string sqlQuery = "SELECT FlightNumber FROM Flights WHERE Destination = @v1 AND DepatureLocation = @v3 ";
                        SqlCommand cmd = new SqlCommand(sqlQuery, con);
                        cmd.Parameters.AddWithValue("@v1", box1.Text);
                        cmd.Parameters.AddWithValue("@v3", box2.Text);
                        using (SqlDataReader dataRead = cmd.ExecuteReader())
                        {
                            if (dataRead != null)
                            {
                                int count = 0;
                                while (dataRead.Read())
                                {
                                    string planeID = dataRead["FlightNumber"].ToString();
                                    //MessageBox.Show(planeID);
                                    count++;
                                }
                                // MessageBox.Show(count.ToString() + " Result found");
                                this.Content = new DataGrid();
                            }
                        }
                        con.Close();
                    }
                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee.Message.ToString());
                }
            }
            
           
        }
        
    }
}
