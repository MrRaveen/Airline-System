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
    /// Interaction logic for CustomerInfoPicker.xaml
    /// </summary>
    public partial class CustomerInfoPicker : UserControl
    {
        int status = 0,count = 1;
        bool condition = true;
        string gender = "";
        public CustomerInfoPicker()
        {
            InitializeComponent();
            combo1.Items.Add(new ComboBoxItem() { Content = "Male" });
            combo1.Items.Add(new ComboBoxItem() { Content = "Female" });
            combo1.Items.Add(new ComboBoxItem() { Content = "Not Mentioned" });
            combo1.SelectedItem = combo1.Items[0];
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
        public static void process()
        {            
            string path2 = "ShareData6.txt";
            int passengers = 0, count = 1;
            using (StreamReader r2 = new StreamReader(path2, true))
            {
                passengers = Convert.ToInt32(r2.ReadLine());
            }
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            lblcontent.Content = "";
            string path2 = "ShareData6.txt";
            int passengers = 0,difference = 0,num1 = 0;
            num1 = count;
            num1 = num1 - 1;
            using (StreamReader r2 = new StreamReader(path2, true))
            {
                passengers = Convert.ToInt32(r2.ReadLine());
            }
           
            if (count <= passengers)
            {
                difference = passengers - num1;
                if(difference == 1)
                {
                    lblconfirm.Content = "Click again to confirm";
                }
                try
                {
                    string path3 = "", selected_date = "", TicID = "";
                    string path = "StoreCusID.txt", UserID1 = "";
                    int CusID;
                    DateTime? d1 = picker1.SelectedDate;
                    selected_date = d1.Value.ToString("d");//d = convert to string in short date format
                    using (StreamReader r2 = new StreamReader(path, true))
                    {
                        CusID = Convert.ToInt32(r2.ReadLine());
                    }
                    File.WriteAllText(path, string.Empty);
                    CusID = CusID + 1;
                    using (StreamWriter writer = new StreamWriter(path, true))
                    {
                        writer.WriteLine(CusID.ToString());
                    }
                    path3 = "DataShare2.txt";
                    using (StreamReader r2 = new StreamReader(path3, true))
                    {
                        UserID1 = r2.ReadLine();
                    }
                    string path4 = "StoreTicid.txt";
                    using (StreamReader r3 = new StreamReader(path4, true))
                    {
                        TicID = r3.ReadLine();
                    }
                    string query = "INSERT INTO Customer (CusID,Fname,Lname,DOB,Gender,FrequentFlyierNo,Phone,CountryCallingCode,UserID,TicketID,Email) VALUES (@v1,@v2,@v3,@v4,@v5,@v6,@v7,@v8,@v9,@v10,@v11)";
                    using (SqlConnection con2 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\lenovo\Documents\AirlineBase.mdf;Integrated Security=True;Connect Timeout=30"))
                    {
                        con2.Open();
                        using (SqlCommand cmd = new SqlCommand(query, con2))
                        {
                            cmd.Parameters.AddWithValue("@v1", "C" + CusID.ToString());
                            cmd.Parameters.AddWithValue("@v2", box1.Text);
                            cmd.Parameters.AddWithValue("@v3", box2.Text);
                            cmd.Parameters.AddWithValue("@v4", selected_date);
                            cmd.Parameters.AddWithValue("@v5", gender);
                            cmd.Parameters.AddWithValue("@v6", box3.Text);
                            cmd.Parameters.AddWithValue("@v7", box6.Text);
                            cmd.Parameters.AddWithValue("@v8", box5.Text);
                            cmd.Parameters.AddWithValue("@v9", UserID1);
                            cmd.Parameters.AddWithValue("@v10", "T" + TicID);
                            cmd.Parameters.AddWithValue("@v11", box4.Text);
                            cmd.ExecuteNonQuery();
                        }
                        box1.Clear();
                        box3.Clear();
                        box5.Clear();
                        box2.Clear();
                        box4.Clear();
                        box6.Clear();
                        check1.IsChecked = false;
                        lblcontent.Content = "Saved - Customer " + count;
                        count = count + 1;
                        con2.Close(); 
                    }

                }
                catch (Exception ss)
                {
                    if (string.IsNullOrEmpty(box1.Text))
                    {
                        // num1 = 1;
                        lbl_error2.Content = "Please fill this field";
                    }
                    else
                    {
                        lbl_error2.Content = "";
                    }

                    if (string.IsNullOrEmpty(box2.Text))
                    {
                        // num2 = 1;
                        lbl_error3.Content = "Please fill this field";
                    }
                    else
                    {
                        lbl_error3.Content = "";
                    }

                    if (picker1.SelectedDate == null)
                    {
                        //  num3 = 1;
                        lbl_error9.Content = "Please fill this field";
                        condition = false;
                    }
                    else
                    {
                        lbl_error9.Content = "";
                    }

                    if (combo1.SelectedItem == null)
                    {
                        //   num4 = 1;
                        lbl_error8.Content = "Please fill this field";
                    }
                    else
                    {
                        lbl_error8.Content = "";
                    }

                    if (string.IsNullOrEmpty(box3.Text))
                    {
                        // num5 = 1;
                        lbl_error4.Content = "Please fill this field";
                    }
                    else
                    {
                        lbl_error4.Content = "";
                    }

                    if (string.IsNullOrEmpty(box4.Text))
                    {
                        // num6 = 1;
                        lbl_error5.Content = "Please fill this field";
                    }
                    else
                    {
                        lbl_error5.Content = "";
                    }

                    if (string.IsNullOrEmpty(box5.Text))
                    {
                        // num7 = 1;
                        lbl_error6.Content = "Please fill this field";
                    }
                    else
                    {
                        lbl_error6.Content = "";
                    }

                    if (string.IsNullOrEmpty(box6.Text))
                    {
                        // num8 = 1;
                        lbl_error7.Content = "Please fill this field";
                    }
                    else
                    {
                        lbl_error7.Content = "";
                    }

                    if (status != 1)
                    {
                        // num9 = 1;
                        lbl_error1.Content = "Please select this box";
                    }
                    else
                    {
                        lbl_error1.Content = "";
                    }
                    /////////////////
                    /*if (box1.Text.Any(char.IsDigit))
                    {
                        // num1 = 1;
                        lbl_error2.Content = "don't enter numbers";
                    }
                    else if (string.IsNullOrEmpty(box1.Text))
                    {
                        lbl_error2.Content = "Please fill this field";
                    }
                    else
                    {
                        lbl_error2.Content = "";
                    }
                    if (box2.Text.Any(char.IsDigit))
                    {
                        // num1 = 1;
                        lbl_error3.Content = "don't enter numbers";
                    }
                    else if (string.IsNullOrEmpty(box2.Text))
                    {
                        lbl_error3.Content = "Please fill this field";
                    }
                    else
                    {
                        lbl_error3.Content = "";
                    }

                    if (box6.Text.Any(char.IsDigit))
                    {
                        lbl_error7.Content = "";
                    }
                    else if (string.IsNullOrEmpty(box6.Text))
                    {
                        lbl_error7.Content = "Please fill this field";
                    }
                    else
                    {
                        lbl_error7.Content = "don't enter text";
                    }
                    if (box5.Text.Any(char.IsDigit))
                    {
                        lbl_error6.Content = "don't enter numbers";
                    }
                    else if (string.IsNullOrEmpty(box5.Text))
                    {
                        lbl_error6.Content = "Please fill this field";
                    }
                    else
                    {
                        lbl_error6.Content = "";
                    }*/
                }
            }
            else
            {
                this.Content = new PaymentPart();
            }
        }
        private void Check1_Checked(object sender, RoutedEventArgs e)
        {
            status = 1;
        }

        private void Combo1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            gender = ((ComboBoxItem)(((ComboBox)sender).SelectedItem)).Content.ToString();
        }
    }
}
