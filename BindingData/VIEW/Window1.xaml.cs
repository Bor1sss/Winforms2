using BindingData.MODEL;
using BindingData.VIEWMODEL;
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

namespace BindingData
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public  Contacts contacts {  get; set; }
        public ContactList list {  get; set; }


        public bool isChange {  get; set; }
        public Window1(bool isChanging,Contacts cont)
        {
            InitializeComponent();
            isChange = isChanging;
            contacts= cont;
            if (isChange)
            {
                bt.Click -= bt_Click;
                bt.Click += bt_Change;
                bt.Content = "Change";
                list = Resources["ContactList"] as ContactList;
                list.NameList = contacts.Name;
                list.SurnameList = contacts.Surname;
                list.AdressList = contacts.Adress;
                list.PhoneList = contacts.PhoneNumber;
            }
            else
            {
                bt.Click -= bt_Change;
                bt.Click += bt_Click;
                bt.Content = "Добавить";
            }

        }

        private void bt_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                list = Resources["ContactList"] as ContactList;
                contacts = new Contacts();
                contacts.Name = list.NameList;
                contacts.Adress = list.AdressList;
                contacts.Surname = list.SurnameList;
                contacts.PhoneNumber = list.PhoneList;

               






            }
            catch { }
            this.Close();
        }


        private void bt_Change(object sender, RoutedEventArgs e)
        {
            try
            {

                list = Resources["ContactList"] as ContactList;
                contacts = new Contacts();
                contacts.Name = list.NameList;
                contacts.Adress = list.AdressList;
                contacts.Surname = list.SurnameList;
                contacts.PhoneNumber = list.PhoneList;







            }
            catch { }
            this.Close();
        }

        private void bt_cancel_Click(object sender, RoutedEventArgs e)
        {
            contacts = null;
            this.Close();
        }
    }
}
