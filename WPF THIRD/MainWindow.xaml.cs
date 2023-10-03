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

namespace WPF_THIRD
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Matrix=new double[3,3];
        }
        public double[,] Matrix {  get; set; }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Matrix[0, 0] = Convert.ToDouble(t1.Text);
                Matrix[0, 1] = Convert.ToDouble(t2.Text);
                Matrix[0, 2] = Convert.ToDouble(t3.Text);

                Matrix[1, 0] = Convert.ToDouble(t4.Text);
                Matrix[1, 1] = Convert.ToDouble(t5.Text);
                Matrix[1, 2] = Convert.ToDouble(t6.Text);

                Matrix[2, 0] = Convert.ToDouble(t7.Text);
                Matrix[2, 1] = Convert.ToDouble(t8.Text);
                Matrix[2, 2] = Convert.ToDouble(t9.Text);
                double determinant = 0;

                determinant = Matrix[0, 0] * (Matrix[1, 1] * Matrix[2, 2] - Matrix[1, 2] * Matrix[2, 1]) -
                              Matrix[0, 1] * (Matrix[1, 0] * Matrix[2, 2] - Matrix[1, 2] * Matrix[2, 0]) +
                              Matrix[0, 2] * (Matrix[1, 0] * Matrix[2, 1] - Matrix[1, 1] * Matrix[2, 0]);
                textblock1.Text = Convert.ToString(determinant);
            }
            catch (Exception ex){ 
            
                MessageBox.Show(ex.Message);
            
            }
        }
    }
}
