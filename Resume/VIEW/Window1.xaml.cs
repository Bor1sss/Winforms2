using Resume.Model;
using Resume.ViewModel;
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

namespace Resume.VIEW
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public M_Resume contacts { get; set; }
        public VM_Resume list { get; set; }
        public Window1(M_Resume cont)
        {
            InitializeComponent();
            contacts= cont;
            list = Resources["Resume"] as VM_Resume;
            list.FIO = contacts.FIO;
            list.Age = contacts.Age;
            list.Adress = contacts.Adress;
            list.Email = contacts.Email;
            list.Family = contacts.Family;


            list.TECH = contacts.TECH;
            list.Language = contacts.Language;


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                list = Resources["Resume"] as VM_Resume;

                contacts = new M_Resume();


                contacts.FIO = list.FIO;
                contacts.Age = list.Age;
                contacts.Adress = list.Adress;
                contacts.Email = list.Email;
                contacts.Family = list.Family;
                contacts.TECH = list.TECH;
                contacts.Language = list.Language;








            }
            catch { }
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
