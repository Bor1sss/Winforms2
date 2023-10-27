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



   
    public class AddCommand : ICommand
    {
        Action<object> _execute;
        Predicate<object> _canExecute;
        protected internal object sender;



        public AddCommand(Action<object> execute, Predicate<object> canExecute)
        {
            _execute = execute ?? throw new ArgumentNullException("execute");
            _canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object? parameter)
        {
            return _canExecute == null ? true : _canExecute(parameter);
        }

        public void Execute(object? parameter)
        {
            sender = parameter;
            _execute(parameter);
        }


    }



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




    [Serializable]
    [DataContract]
   
    public class Contacts:DependencyObject
    {
      
        private static readonly DependencyProperty NameProperty;
     
        private static readonly DependencyProperty SurnameProperty;
     
        private static readonly DependencyProperty AdressProperty;

        private static readonly DependencyProperty PhoneNumberProperty;

       

        static Contacts()
        {
            NameProperty = DependencyProperty.Register("Name", typeof(string), typeof(Contacts));
            SurnameProperty = DependencyProperty.Register("Surname", typeof(string), typeof(Contacts));
            AdressProperty = DependencyProperty.Register("Adress", typeof(string), typeof(Contacts));
            PhoneNumberProperty = DependencyProperty.Register("Phone", typeof(string), typeof(Contacts));

           
        }
        [DataMember]
        public string Name
        {
            get { return (string)GetValue(NameProperty); }
            set { SetValue(NameProperty, value); }
        }
        [DataMember]
        public string Surname
        {
            get { return (string)GetValue(SurnameProperty); }
            set { SetValue(SurnameProperty, value); }
        }
        [DataMember]
        public string Adress
        {
            get { return (string)GetValue(AdressProperty); }
            set { SetValue(AdressProperty, value); }
        }
        [DataMember]
        public string PhoneNumber
        {
            get { return (string)GetValue(PhoneNumberProperty); }
            set { SetValue(PhoneNumberProperty, value); }
        }


    }

    [Serializable]
    public class ContactList : DependencyObject
    {
        public ObservableCollection<Contacts> Contacts { get; set; } = new ObservableCollection<Contacts>();


        private static readonly DependencyProperty SelectedIndexProperty;
        private static readonly DependencyProperty NameListProperty;
        private static readonly DependencyProperty SurnameListProperty;
        private static readonly DependencyProperty AdressListProperty;
        private static readonly DependencyProperty PhoneNumberListProperty;

        public AddCommand addComand;
        public AddCommand DeleteCommand;
        public AddCommand SaveCommand;
        public AddCommand LoadCommand;
        public AddCommand ChangeCommand;

        public ContactList(){


            addComand = new AddCommand(param => Add(), param => CanAdd());
            DeleteCommand = new AddCommand(param => Delete(), param => CanDelete());
            SaveCommand = new AddCommand(param => SaveC(), param => CanSave());
            LoadCommand = new AddCommand(param => LoadC(), param => CanAdd());
            ChangeCommand = new AddCommand(param => ChangeC(), param => CanDelete());

        }
        public ICommand AddCommand
        {
            get { return addComand; }
        }
        public ICommand Del
        {
            get { return DeleteCommand; }
        }
        public ICommand Save
        {
            get { return SaveCommand; }
        }
        public ICommand Load
        {
            get { return LoadCommand; }
        }
        public ICommand Change
        {
            get { return ChangeCommand; }
        }
      
        static ContactList()
        {
            SelectedIndexProperty = DependencyProperty.Register("SelectedIndex", typeof(int), typeof(ContactList));
            NameListProperty = DependencyProperty.Register("NameList", typeof(string), typeof(ContactList));
            SurnameListProperty = DependencyProperty.Register("SurnameList", typeof(string), typeof(ContactList));
            AdressListProperty = DependencyProperty.Register("AdressList", typeof(string), typeof(ContactList));
            PhoneNumberListProperty = DependencyProperty.Register("PhoneList", typeof(string), typeof(ContactList));

       

                
        }

        public int SelectedIndex
        {
            get { return (int)GetValue(SelectedIndexProperty); }
            set { SetValue(SelectedIndexProperty, value); }
        }

        public string NameList
        {
            get { return (string)GetValue(NameListProperty); }
            set { SetValue(NameListProperty, value); }
        }
        public string SurnameList
        {

            get { return (string)GetValue(SurnameListProperty); }
            set { SetValue(SurnameListProperty, value); }


        }
        public string AdressList
        {

            get { return (string)GetValue(AdressListProperty); }
            set { SetValue(AdressListProperty, value); }


        }
        public string PhoneList
        {

            get { return (string)GetValue(PhoneNumberListProperty); }
            set { SetValue(PhoneNumberListProperty, value); }


        }

         private void Add()
        {
            Contacts contact = new Contacts();
       

            Window1 window1 = new Window1(false, contact);

           
            window1.ShowDialog();
            if (window1.contacts != null)
            {
               
                Contacts.Add(window1.contacts);
            }


        }
        private bool CanAdd()
        {


            return true;
        }
        private void Delete()
        {

               MessageBoxResult res = MessageBox.Show("Вы уверены что хотите удалить элемент?", "Точно?",
              MessageBoxButton.YesNo, MessageBoxImage.Question);
              if (res == MessageBoxResult.Yes) Contacts.RemoveAt(SelectedIndex);

        }



        private void ChangeC()
        {



         
            if (SelectedIndex == -1)
                return;
            try
            {
                Contacts cont = Contacts[SelectedIndex];
                NameList = cont.Name;
                AdressList = cont.Adress;
                PhoneList = cont.PhoneNumber;
               SurnameList = cont.Surname;
                Window1 window1 = new Window1(true, cont);

                window1.list = this;

                window1.ShowDialog();
                Contacts[SelectedIndex] = (window1.contacts);
            }
            catch
            {
                return;
            }


        }
     

        private void SaveC()
        {
        

            try
            {


                XmlSerializer xs = new XmlSerializer(typeof(ObservableCollection<Contacts>));
                using (StreamWriter wr = new StreamWriter($"{GetSaveFileName()}"))
                {
                    xs.Serialize(wr, Contacts);
                }

            }
            catch (Exception)
            {


            }
        }


        private void LoadC()
        {

            ObservableCollection<Contacts> list;
             XmlSerializer xs = new XmlSerializer(typeof(ObservableCollection<Contacts>));
            try
            {
                using (StreamReader wr = new StreamReader($"{GetOpenFileName()}"))
                {
                   list = xs.Deserialize(wr) as ObservableCollection<Contacts>;

                }
                foreach (var item in list)
                {
                    Contacts.Add(item);
                }
             

            }
            catch (Exception)
            {

                throw;
            }
        }

        private bool CanDelete()
            {


            if (SelectedIndex >= 0 && Contacts.Count>0)
            {
                return true;
            }
            else
            {
                return false;
            }


           }

        private bool CanSave()
        {


            if (Contacts.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }


        }

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


    }





}
