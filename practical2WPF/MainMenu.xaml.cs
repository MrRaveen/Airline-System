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
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.IO;

namespace practical2WPF
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
        string Unam,UID;
        public MainMenu()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TabItem_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void BtnMax_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void BtnMini1_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void BtnMax2_Click(object sender, RoutedEventArgs e)
        {
            if(this.WindowState == WindowState.Normal)
            {
                this.WindowState = WindowState.Maximized;
            }
            else
            {
                this.WindowState = WindowState.Normal;
            }
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
           this.mainContentControl.Content = new Home();
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            this.mainContentControl.Content = new BookedTickets();
        }

        private void RadioButton_Checked_2(object sender, RoutedEventArgs e)
        {
            this.mainContentControl.Content = new BookNew();
        }

        private void RadioButton_Checked_3(object sender, RoutedEventArgs e)
        {
            this.mainContentControl.Content = new History1();
        }

        private void RadioButton_Checked_4(object sender, RoutedEventArgs e)
        {
            this.mainContentControl.Content = new AllFlights1();
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            string path = "DataShare2.txt";
            try
            {
                
                using (StreamReader r1 = new StreamReader(path, true))
                {
                    UID = r1.ReadLine();
                    Unam = r1.ReadLine();
                }
            }

            catch (Exception ss)
            {
                MessageBox.Show(ss.Message.ToString());
            }
            block3.Text = Unam+"("+UID+")"; //USE THE NAME NOT THE ID
            this.mainContentControl.Content = new Home();
        }

        private void Btnclose_Click(object sender, RoutedEventArgs e)
        {
            string path = "DataShare2.txt";
            File.WriteAllText(path, string.Empty);
            string path2 = "ContentShare.txt";
            File.WriteAllText(path2, string.Empty);
            string path3 = "ShareData6.txt";
            File.WriteAllText(path3, string.Empty);
            string path4 = "ContentShare5.txt";
            File.WriteAllText(path4, string.Empty);
            string path5 = "DataSender.txt";
            File.WriteAllText(path5, string.Empty);
            string path6 = "FIDshere.txt";
            File.WriteAllText(path6, string.Empty);
            Application.Current.Shutdown();
        }

        private void RadioButton_Checked_5(object sender, RoutedEventArgs e)
        {
            string path = "DataShare2.txt";
            File.WriteAllText(path, string.Empty);
            string path2 = "ContentShare.txt";
            File.WriteAllText(path2, string.Empty);
            string path3 = "ShareData6.txt";
            File.WriteAllText(path3, string.Empty);
            string path4 = "ContentShare5.txt";
            File.WriteAllText(path4, string.Empty);
            string path5 = "DataSender.txt";
            File.WriteAllText(path5, string.Empty);
            string path6 = "FIDshere.txt";
            File.WriteAllText(path6, string.Empty);
            MainWindow m1 = new MainWindow();
            this.Hide();
            m1.Show();
        }

        private void Btnaximize_Click(object sender, RoutedEventArgs e)
        {
            if(this.WindowState == WindowState.Normal)
            {
                this.WindowState = WindowState.Minimized;
            }
            else
            {
                this.WindowState = WindowState.Normal;
            } //FOR NOW!!
            
        }
    }
}
