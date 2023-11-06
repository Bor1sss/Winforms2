using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using System.Xml.Serialization;
using BindingData.MODEL;
using BindingData.Commands;

namespace BindingData.VIEWMODEL
{
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

        public ContactList()
        {


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


            if (SelectedIndex >= 0 && Contacts.Count > 0)
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
