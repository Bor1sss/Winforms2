using RGB_MVVM.ViewModel;
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
using System.Drawing;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media;

namespace RGB_MVVM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

           
           
        }

        private void ListBoxItem_MouseEnter(object sender, MouseEventArgs e)
        {
            if (sender is Button button)
            {
                DependencyObject parent = VisualTreeHelper.GetParent(button);

                while (parent != null && !(parent is ListBoxItem))
                {
                    parent = VisualTreeHelper.GetParent(parent);
                }

                if (parent is ListBoxItem listBoxItem)
                {
                    ListBoxItem ls = (ListBoxItem)parent;
                    ls.IsSelected = true;
                    
                }
            }
        }
    }
}
