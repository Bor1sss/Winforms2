using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json;
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
using System.Xml.Serialization;

namespace BindingData
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 



 



    public partial class MainWindow : Window
    {
  
        public bool isChanging {  get; set; }


        public ListBox ListBox { get; set; }
        public MainWindow()
        {

            ListBox = ls;
            InitializeComponent();
            
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
      


        }


/*
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            ContactList contactList = Resources["ContactList"] as ContactList;
            if (contactList.SelectedIndex != -1)
            {
                MessageBoxResult res = MessageBox.Show("Вы уверены что хотите удалить элемент?", "Точно?",
                    MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (res == MessageBoxResult.Yes) contactList.Contacts.RemoveAt(contactList.SelectedIndex);

            }

        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {


        }




        private void Add(object sender, RoutedEventArgs e)
        {






            Contacts contact = new Contacts();
            ContactList list = Resources["ContactList"] as ContactList;

            Window1 window1 = new Window1(false, contact);


            window1.ShowDialog();
            if (window1.contacts != null)
            {
                list.Contacts.Add(window1.contacts);
            }


        }
        private void Change(object sender, RoutedEventArgs e)
        {

            ContactList list = Resources["ContactList"] as ContactList;
            if (list.SelectedIndex == -1)
                return;
            try
            {
                Contacts cont = list.Contacts[list.SelectedIndex];
                list.NameList = cont.Name;
                list.AdressList = cont.Adress;
                list.PhoneList = cont.PhoneNumber;
                list.SurnameList = cont.Surname;
                Window1 window1 = new Window1(true, cont);

                window1.list = list;

                window1.ShowDialog();
                list.Contacts[list.SelectedIndex] = (window1.contacts);
            }
            catch
            {
                return;
            }


        }
        private void Exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void LoadFromFileClick(object sender, RoutedEventArgs e)
        {
            ContactList list = Resources["ContactList"] as ContactList;

            XmlSerializer xs = new XmlSerializer(typeof(ObservableCollection<Contacts>));
            try
            {
                using (StreamReader wr = new StreamReader($"{GetOpenFileName()}"))
                {
                    list.Contacts = xs.Deserialize(wr) as ObservableCollection<Contacts>;
                }
                Dispatcher.Invoke(() => ls.ItemsSource = list.Contacts);

            }
            catch (Exception)
            {

                throw;
            }
        }
        private void SaveToFileClick(object sender, RoutedEventArgs e)
        {
            ContactList list = Resources["ContactList"] as ContactList;

            try
            {


                XmlSerializer xs = new XmlSerializer(typeof(ObservableCollection<Contacts>));
                using (StreamWriter wr = new StreamWriter($"{GetSaveFileName()}"))
                {
                    xs.Serialize(wr, list.Contacts);
                }

            }
            catch (Exception)
            {


            }
        }

*/



        public string GetOpenFileName()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "xml Files | *.xml";
            openFileDialog.ShowDialog();
            return openFileDialog.FileName;
           
        }
        public string GetSaveFileName()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.ShowDialog();
            saveFileDialog.Filter = "xml Files | *.xml";
            return saveFileDialog.FileName;
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }




  

  




}
