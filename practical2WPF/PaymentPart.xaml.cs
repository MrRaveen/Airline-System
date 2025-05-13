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
    /// Interaction logic for PaymentPart.xaml
    /// </summary>
    public partial class PaymentPart : UserControl
    {
        string Currency = "", CrdType = "";
        public PaymentPart()
        {
            InitializeComponent();
            combo1.Items.Add(new ComboBoxItem() { Content = "Sri Lankan Rupees" });
            combo1.Items.Add(new ComboBoxItem() { Content = "US dollers" });
            combo1.Items.Add(new ComboBoxItem() { Content = "Inian Rupees" });
            combo1.Items.Add(new ComboBoxItem() { Content = "Autralian dollers" });
            combo1.Items.Add(new ComboBoxItem() { Content = "Euro" });
            combo1.SelectedItem = combo1.Items[0];
            combo2.Items.Add(new ComboBoxItem() { Content = "Visa" });
            combo2.Items.Add(new ComboBoxItem() { Content = "Master Card" });
            combo2.Items.Add(new ComboBoxItem() { Content = "American Express" });
            combo2.Items.Add(new ComboBoxItem() { Content = "Discover" });
            combo2.Items.Add(new ComboBoxItem() { Content = "Union Pay" });
            combo2.SelectedItem = combo2.Items[0];
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string query2 = "UPDATE Ticket SET Currency = @v1, CardType = @v2,CardNo = @v3,ExpDate = @v4,HolderMail = @v5,PostalCode = @v6,HolderPhone = @v7,City = @v8,Country = @v9 WHERE TicketID = @v10";
                string path4 = "StoreTicid.txt";
                int TicID = 0;
                string TicID2, selected_date;
                using (StreamReader r3 = new StreamReader(path4, true))
                {
                    TicID = Convert.ToInt32(r3.ReadLine());
                }
                TicID2 = TicID.ToString();
                DateTime? d1 = picker1.SelectedDate;
                selected_date = d1.Value.ToString("d");//d = convert to string in short date format


                //BASE WRITTER START
                using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\lenovo\Documents\AirlineBase.mdf;Integrated Security=True;Connect Timeout=30"))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query2, con))
                    {
                        cmd.Parameters.AddWithValue("@v10","T"+TicID2);
                        cmd.Parameters.AddWithValue("@v1", Currency);
                        cmd.Parameters.AddWithValue("@v2", CrdType);
                        cmd.Parameters.AddWithValue("@v3",Convert.ToInt32(box1.Text));
                        cmd.Parameters.AddWithValue("@v4", selected_date);
                        cmd.Parameters.AddWithValue("@v5", box2.Text);
                        cmd.Parameters.AddWithValue("@v6",Convert.ToInt32( box3.Text));
                        cmd.Parameters.AddWithValue("@v7", Convert.ToInt32(box5.Text));
                        cmd.Parameters.AddWithValue("@v8", box6.Text);
                        cmd.Parameters.AddWithValue("@v9", box4.Text);
                        cmd.ExecuteNonQuery();
                    }
                    con.Close();
                    MeBox m1 = new MeBox();
                    m1.Show();
                }
                //BASE WRITTER END 
            }
            catch (Exception ww) {
                MessageBox.Show(ww.Message.ToString());
            }
            

        }

        private void Combo1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Currency = ((ComboBoxItem)(((ComboBox)sender).SelectedItem)).Content.ToString();
        }

        private void Combo2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CrdType = ((ComboBoxItem)(((ComboBox)sender).SelectedItem)).Content.ToString();
        }
    }
}
