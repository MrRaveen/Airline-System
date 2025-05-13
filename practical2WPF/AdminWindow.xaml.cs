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

namespace practical2WPF
{
    /// <summary>
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            this.mainContentControl.Content = new FlightEnter();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            ErrorMessage e1 = new ErrorMessage();
            e1.Show();
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            this.mainContentControl.Content = new TicketFinderAdmin();
        }

        private void RadioButton_Checked_2(object sender, RoutedEventArgs e)
        {
            this.mainContentControl.Content = new CusView();
        }

        private void Btnaximize_Click(object sender, RoutedEventArgs e)
        {
            ErrorMessage e1 = new ErrorMessage();
            e1.Show();
        }

        private void Btnaximize_Click_1(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
            {
                this.WindowState = WindowState.Minimized;
            }
            else
            {
                this.WindowState = WindowState.Normal;
            }
        }

        private void RadioButton_Checked_3(object sender, RoutedEventArgs e)
        {
            MainWindow m1 = new MainWindow();
            this.Hide();
            m1.Show();
        }

        private void RadioButton_Checked_4(object sender, RoutedEventArgs e)
        {
            this.Content = new FeatureEditor();
        }
    }
}
