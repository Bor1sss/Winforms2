using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Resume.Commands;
using System.Windows.Input;
using Resume.Model;
using System.Diagnostics.CodeAnalysis;
using Resume.VIEW;

namespace Resume.ViewModel
{
    public class VM_Resume:DependencyObject
    {
        public ObservableCollection<M_Resume> Contacts { get; set; } = new ObservableCollection<M_Resume>();

        private static readonly DependencyProperty SelectedIndexProperty;

        private static readonly DependencyProperty FIOProperty;

        private static readonly DependencyProperty AgeProperty;

        private static readonly DependencyProperty FamilyProperty;

        private static readonly DependencyProperty AdressProperty;

        private static readonly DependencyProperty EmailorARGB_Property;


        private static readonly DependencyProperty Technical_Property;
        private static readonly DependencyProperty Language_Property;

        public bool TECH
        {
            get { return (bool)GetValue(Technical_Property); }
            set { SetValue(Technical_Property, value); }
        }

        public bool Language
        {
            get { return (bool)GetValue(Language_Property); }
            set { SetValue(Language_Property, value); }
        }



        private AddCommand addComand;
        private AddCommand cancelCommand;
        private AddCommand deleteCommand;

        private AddCommand fullCommand;

        public ICommand FullCommand
        {
            get { return fullCommand; }
        }

        public ICommand AddCommand
        {
            get { return addComand; }
        }

        public ICommand CancelCommand
        {
            get { return cancelCommand; }
        }
        public ICommand DeleteCommand
        {
            get { return deleteCommand; }
        }

        private bool CanFull()
        {
            if (SelectedIndex != -1&&Contacts.Count>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void Full()
        {

            


            Window1 window1 = new Window1(Contacts[SelectedIndex]);


            window1.ShowDialog();

            Contacts[SelectedIndex] = (window1.contacts);

        }


        private bool CanAdd()
        {


            if (FIO != null && Adress != null && Age>0&&Family!=null&&Email!=null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    
        private void Add()
        {
            Contacts.Add(new M_Resume(FIO, Age, Family, Adress, Email,TECH,Language));
            CancelCommand.Execute(this);
        }


 
        private void Cancel()
        {
            FIO = "";
            Age = 0;
            Family = "";
            Adress = "";
            Email = "";
        }


        private bool CanCancel()
        {

            return true;
        }

        private void Del()
        {
            MessageBoxResult res = MessageBox.Show("Вы уверены что хотите удалить элемент?", "Точно?",
             MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (res == MessageBoxResult.Yes) Contacts.RemoveAt(SelectedIndex);


        }


        private bool CanDel()
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

        public int SelectedIndex
        {
            get { return (int)GetValue(SelectedIndexProperty); }
            set { SetValue(SelectedIndexProperty, value); }
        }

        public VM_Resume()
        {
            addComand = new AddCommand(param => Add(), param => CanAdd());
            cancelCommand = new AddCommand(param => Cancel(), param => CanCancel());
            deleteCommand = new AddCommand(param => Del(), param => CanDel());
            fullCommand = new AddCommand(param => Full(), param => CanFull());
        }
        public string FIO
        {
            get { return (string)GetValue(FIOProperty); }
            set { SetValue(FIOProperty, value); }
        }

        public int Age
        {
            get { return (int)GetValue(AgeProperty); }
            set { SetValue(AgeProperty, value); }
        }

        public string Family
        {
            get { return (string)GetValue(FamilyProperty); }
            set { SetValue(FamilyProperty, value); }
        }
        public string Adress
        {
            get { return (string)GetValue(AdressProperty); }
            set { SetValue(AdressProperty, value); }
        }

        public string Email
        {
            get { return (string)GetValue(EmailorARGB_Property); }
            set { SetValue(EmailorARGB_Property, value); }
        }

        public VM_Resume(string FIO, int red, string green, string blue, string col)
        {
            this.FIO = FIO;
            Age = red;
            Family = green;
            Adress = blue;
            Email = col;
        }

        static VM_Resume()
        {
            FIOProperty = DependencyProperty.Register("FIO", typeof(string), typeof(VM_Resume));
            AgeProperty = DependencyProperty.Register("Age", typeof(int), typeof(VM_Resume));
            FamilyProperty = DependencyProperty.Register("Family", typeof(string), typeof(VM_Resume));
            AdressProperty = DependencyProperty.Register("Adress", typeof(string), typeof(VM_Resume));
            EmailorARGB_Property = DependencyProperty.Register("Email", typeof(string), typeof(VM_Resume));
            SelectedIndexProperty = DependencyProperty.Register("SelectedIndex", typeof(int), typeof(VM_Resume));

            Technical_Property = DependencyProperty.Register("TECH", typeof(bool), typeof(VM_Resume));
            Language_Property = DependencyProperty.Register("Language", typeof(bool), typeof(VM_Resume));
        }


    }
}
