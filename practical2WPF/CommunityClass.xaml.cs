﻿using System;
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
    /// Interaction logic for CommunityClass.xaml
    /// </summary>
    public partial class CommunityClass : UserControl
    {
        int Num_passengers = 0;
        public CommunityClass()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string path4 = "ContentShare5.txt";
            File.WriteAllText(path4, string.Empty);
            string path3 = "ShareData6.txt";
            File.WriteAllText(path3, string.Empty);
            File.WriteAllText(path4, string.Empty);
            File.WriteAllText(path3, string.Empty);
            this.Content = new BookNew();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                string TicID1;
                string path2 = "StoreTicid.txt";
                using (StreamReader r2 = new StreamReader(path2, true))
                {
                    TicID1 = r2.ReadLine();
                }
                string query2 = "UPDATE Ticket SET ClassPrice = @v1 WHERE TicketID = @v2";
                using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\lenovo\Documents\AirlineBase.mdf;Integrated Security=True;Connect Timeout=30"))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query2, con))
                    {
                        cmd.Parameters.AddWithValue("@v2", "T"+TicID1);
                        cmd.Parameters.AddWithValue("@v1", Convert.ToDouble(box2.Text));
                        cmd.ExecuteNonQuery();
                    }
                    con.Close();
                }
                string query = "UPDATE Ticket SET Class = @v1 WHERE TicketID = @v2";
                using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\lenovo\Documents\AirlineBase.mdf;Integrated Security=True;Connect Timeout=30"))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@v2", "T"+TicID1);
                        cmd.Parameters.AddWithValue("@v1", "Community");
                        cmd.ExecuteNonQuery();
                    }
                    con.Close();
                }
                //UPDATE THE PASSENGERS COUNT
                string query4 = "UPDATE Ticket SET Passengers = @v1 WHERE TicketID = @v2";
                using (SqlConnection con4 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\lenovo\Documents\AirlineBase.mdf;Integrated Security=True;Connect Timeout=30"))
                {
                    con4.Open();
                    using (SqlCommand cmd = new SqlCommand(query4, con4))
                    {
                        cmd.Parameters.AddWithValue("@v2", "T" + TicID1);
                        cmd.Parameters.AddWithValue("@v1", Num_passengers);
                        cmd.ExecuteNonQuery();
                    }
                    con4.Close();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString());
            }
            this.Content = new PackagePicker();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            string PID;
            string path = "ContentShare5.txt";
            string path2 = "ShareData6.txt", passengers;
            double price = 0;
            using (StreamReader r1 = new StreamReader(path, true))
            {
                PID = r1.ReadLine();
            }
            try
            {

                using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\lenovo\Documents\AirlineBase.mdf;Integrated Security=True;Connect Timeout=30"))
                {
                    con.Open();
                    string sqlQuery = "SELECT priceCommunity FROM Flights WHERE FlightNumber = @v1";
                    SqlCommand cmd = new SqlCommand(sqlQuery, con);
                    cmd.Parameters.AddWithValue("@v1", PID);
                    using (SqlDataReader dataRead = cmd.ExecuteReader())
                    {
                        if (dataRead != null)
                        {
                            while (dataRead.Read())
                            {
                                string TablePrice = dataRead["priceCommunity"].ToString();
                                price = Convert.ToDouble(TablePrice);
                            }
                        }
                    }
                    con.Close();
                }
                box1.Text = price.ToString();
                using (StreamReader r2 = new StreamReader(path2, true))
                {
                    passengers = r2.ReadLine();
                }
                Num_passengers = Convert.ToInt32(passengers);
                double tot = price * Num_passengers;
                box2.Text = tot.ToString();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString());
            }
        }
    }
}
