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
using System.IO;

namespace practical2WPF
{
    /// <summary>
    /// Interaction logic for ErrorWindow2.xaml
    /// </summary>
    public partial class ErrorWindow2 : Window
    {
        public ErrorWindow2()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}
