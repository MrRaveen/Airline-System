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
using System.IO;
using System.Data.SqlClient;

namespace practical2WPF
{
    /// <summary>
    /// Interaction logic for PackagePicker.xaml
    /// </summary>
    public partial class PackagePicker : UserControl
    {
        public PackagePicker()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string path2 = "StoreTicid.txt";
                int TicID1 = 0;
                using (StreamReader r2 = new StreamReader(path2, true))
                {
                    TicID1 = Convert.ToInt32(r2.ReadLine());
                }
                string sqlquery = "DELETE FROM Ticket WHERE TicketID = @v1;";
                using (SqlConnection con3 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\lenovo\Documents\AirlineBase.mdf;Integrated Security=True;Connect Timeout=30"))
                {
                    con3.Open();
                    using (SqlCommand cmd = new SqlCommand(sqlquery, con3))
                    {
                        cmd.Parameters.AddWithValue("@v1", "T" + TicID1.ToString());
                        cmd.ExecuteNonQuery();
                        string path4 = "ContentShare5.txt";
                        File.WriteAllText(path4, string.Empty);
                        string path3 = "ShareData6.txt";
                        File.WriteAllText(path3, string.Empty);
                        File.WriteAllText(path4, string.Empty);
                        File.WriteAllText(path3, string.Empty);
                       // MessageBox.Show("Ticket Cancelled!!");
                    }
                    con3.Close();
                }
            }
            catch (Exception ll)
            {
                MessageBox.Show(ll.Message.ToString());
            }
            this.Content = new BookNew();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Content = new DataGrid();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                double class_price = 0, tot = 0;
                string stClassPrice;
                string TicID1;
                string path2 = "StoreTicid.txt";
                using (StreamReader r2 = new StreamReader(path2, true))
                {
                    TicID1 = r2.ReadLine();
                }
                using (SqlConnection con2 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\lenovo\Documents\AirlineBase.mdf;Integrated Security=True;Connect Timeout=30"))
                {
                    con2.Open();
                    string query2 = "SELECT ClassPrice FROM Ticket WHERE TicketID = @v1";
                    SqlCommand cmd2 = new SqlCommand(query2, con2);
                    cmd2.Parameters.AddWithValue("@v1", "T" + TicID1);
                    using (SqlDataReader reader = cmd2.ExecuteReader())
                    {
                        if (reader != null)
                        {
                            while (reader.Read())
                            {
                                stClassPrice = reader["ClassPrice"].ToString();
                                class_price = Convert.ToDouble(stClassPrice);
                            }
                        }
                        tot = class_price + 150;
                    }
                    con2.Close();
                }
                string query3 = "UPDATE Ticket SET PriceTot = @v1 WHERE TicketID = @v2";
                using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\lenovo\Documents\AirlineBase.mdf;Integrated Security=True;Connect Timeout=30"))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query3, con))
                    {
                        cmd.Parameters.AddWithValue("@v2", "T" + TicID1);
                        cmd.Parameters.AddWithValue("@v1", tot);
                        cmd.ExecuteNonQuery();
                    }
                    con.Close();
                }




                string query = "UPDATE Ticket SET Package = @v1 WHERE TicketID = @v2";
                using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\lenovo\Documents\AirlineBase.mdf;Integrated Security=True;Connect Timeout=30"))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@v2", "T"+TicID1);
                        cmd.Parameters.AddWithValue("@v1", "Basic");
                        cmd.ExecuteNonQuery();
                    }
                    con.Close();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString());
            }
            this.Content = new TotalBill();

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            try
            {
                double class_price = 0, tot = 0;
                string stClassPrice;
                string TicID1;
                string path2 = "StoreTicid.txt";
                using (StreamReader r2 = new StreamReader(path2, true))
                {
                    TicID1 = r2.ReadLine();
                }
                using (SqlConnection con2 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\lenovo\Documents\AirlineBase.mdf;Integrated Security=True;Connect Timeout=30"))
                {
                    con2.Open();
                    string query2 = "SELECT ClassPrice FROM Ticket WHERE TicketID = @v1";
                    SqlCommand cmd2 = new SqlCommand(query2, con2);
                    cmd2.Parameters.AddWithValue("@v1", "T" + TicID1);
                    using (SqlDataReader reader = cmd2.ExecuteReader())
                    {
                        if (reader != null)
                        {
                            while (reader.Read())
                            {
                                stClassPrice = reader["ClassPrice"].ToString();
                                class_price = Convert.ToDouble(stClassPrice);
                            }
                        }
                        tot = class_price + 250;
                    }
                    con2.Close();
                }
                string query3 = "UPDATE Ticket SET PriceTot = @v1 WHERE TicketID = @v2";
                using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\lenovo\Documents\AirlineBase.mdf;Integrated Security=True;Connect Timeout=30"))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query3, con))
                    {
                        cmd.Parameters.AddWithValue("@v2", "T" + TicID1);
                        cmd.Parameters.AddWithValue("@v1", tot);
                        cmd.ExecuteNonQuery();
                    }
                    con.Close();
                }



                string query = "UPDATE Ticket SET Package = @v1 WHERE TicketID = @v2";
                using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\lenovo\Documents\AirlineBase.mdf;Integrated Security=True;Connect Timeout=30"))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@v2", "T"+TicID1);
                        cmd.Parameters.AddWithValue("@v1", "Traveller");
                        cmd.ExecuteNonQuery();
                    }
                    con.Close();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString());
            }
            this.Content = new TotalBill();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            try
            {
                double class_price = 0, tot = 0;
                string stClassPrice;
                string TicID1;
                string path2 = "StoreTicid.txt";
                using (StreamReader r2 = new StreamReader(path2, true))
                {
                    TicID1 = r2.ReadLine();
                }
                using (SqlConnection con2 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\lenovo\Documents\AirlineBase.mdf;Integrated Security=True;Connect Timeout=30"))
                {
                    con2.Open();
                    string query2 = "SELECT ClassPrice FROM Ticket WHERE TicketID = @v1";
                    SqlCommand cmd2 = new SqlCommand(query2, con2);
                    cmd2.Parameters.AddWithValue("@v1", "T" + TicID1);
                    using (SqlDataReader reader = cmd2.ExecuteReader())
                    {
                        if (reader != null)
                        {
                            while (reader.Read())
                            {
                                stClassPrice = reader["ClassPrice"].ToString();
                                class_price = Convert.ToDouble(stClassPrice);
                            }
                        }
                        tot = class_price + 590;
                    }
                    con2.Close();
                }
                string query3 = "UPDATE Ticket SET PriceTot = @v1 WHERE TicketID = @v2";
                using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\lenovo\Documents\AirlineBase.mdf;Integrated Security=True;Connect Timeout=30"))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query3, con))
                    {
                        cmd.Parameters.AddWithValue("@v2", "T" + TicID1);
                        cmd.Parameters.AddWithValue("@v1", tot);
                        cmd.ExecuteNonQuery();
                    }
                    con.Close();
                }



                string query = "UPDATE Ticket SET Package = @v1 WHERE TicketID = @v2";
                using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\lenovo\Documents\AirlineBase.mdf;Integrated Security=True;Connect Timeout=30"))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@v2","T"+TicID1);
                        cmd.Parameters.AddWithValue("@v1", "Ultimate");
                        cmd.ExecuteNonQuery();
                    }
                    con.Close();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString());
            }
            this.Content = new TotalBill();
        }
    }
}
