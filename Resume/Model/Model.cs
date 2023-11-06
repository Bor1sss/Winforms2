using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows;

namespace Resume.Model
{
   public class M_Resume:DependencyObject
    {
        private static readonly DependencyProperty FIOProperty;

        private static readonly DependencyProperty AgeProperty;

        private static readonly DependencyProperty FamilyProperty;

        private static readonly DependencyProperty AdressProperty;

        private static readonly DependencyProperty EmailorARGB_Property;


        private static readonly DependencyProperty Technical_Property;
        private static readonly DependencyProperty Language_Property;




        public M_Resume()
        {


       

        }

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

        public M_Resume(string FIO, int Age, string Family, string Adress, string Email,bool tech,bool lang)
        {
            this.FIO = FIO;
            this.Age = Age;
            this.Family = Family;
            this.Adress = Adress;
            this.Email = Email;
            this.TECH = tech;
            this.Language = lang;
        }

        static M_Resume()
        {
            FIOProperty = DependencyProperty.Register("FIO", typeof(string), typeof(M_Resume));
            AgeProperty = DependencyProperty.Register("Age", typeof(int), typeof(M_Resume));
            FamilyProperty = DependencyProperty.Register("Family", typeof(string), typeof(M_Resume));
            AdressProperty = DependencyProperty.Register("Adress", typeof(string), typeof(M_Resume));
            EmailorARGB_Property = DependencyProperty.Register("Email", typeof(string), typeof(M_Resume));

            Technical_Property = DependencyProperty.Register("TECH", typeof(bool), typeof(M_Resume));
            Language_Property = DependencyProperty.Register("Language", typeof(bool), typeof(M_Resume));


        }

    }
}
