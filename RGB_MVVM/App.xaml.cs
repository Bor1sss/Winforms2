using RGB_MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace RGB_MVVM
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void OnStartup(object sender, StartupEventArgs e)
        {
        

            MainWindow view = new MainWindow();

           /* ARGB_ViewModel viewModel = new ARGB_ViewModel();
            view.DataContext = viewModel;*/
            view.Show();
        }
    }
}
