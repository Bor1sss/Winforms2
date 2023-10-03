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

namespace WPF_SECOND
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public string Password {  get; set; }
        public MainWindow()
        {
            InitializeComponent();
            
            Password = "1234";
            Window1.Title = Password;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text += '7';
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            textBox.Text += '8';
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            textBox.Text += '9';
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            textBox.Text += '4';
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            textBox.Text += '5';
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            textBox.Text += '6';
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            textBox.Text += '1';
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            textBox.Text += '2';
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            textBox.Text += '3';
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            textBox.Clear();
        }

        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            textBox.Text += '0';
        }

        private void Button_Click_11(object sender, RoutedEventArgs e)
        {
            CheckForPassword();
        }



        private void CheckForPassword()
        {
            if (Password == textBox.Text)
            {
                MessageBox.Show("Correct Password");
            }
            else
            {
                MessageBox.Show("Incorrect Password");
            }
        }
    }
}
