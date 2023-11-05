using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BindingData.MODEL
{
    [Serializable]
    [DataContract]

    public class Contacts : DependencyObject
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
}
