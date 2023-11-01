using RGB_MVVM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using RGB_MVVM.Commands;
using System.Drawing;
using System.Windows.Media;
using Color = System.Windows.Media.Color;
using System.ComponentModel;
using System.Windows.Documents;
using System.Windows.Controls;

namespace RGB_MVVM.ViewModel
{
    class ARGB_ViewModel :INotifyPropertyChanged
    {

        public MyCommands addComand;
        public MyCommands delComand;

        public ICommand AddCommand
        {
            get { return addComand; }
        }


        public ICommand DelCommand
        {
            get { return delComand; }
        }

        private int _SelectedIndex;
        public int SelectedIndex
        {
            get { return _SelectedIndex; }
            set
            {
                if (!value.Equals(_SelectedIndex))
                {
                    _SelectedIndex = value;
                    OnPropertyChanged("SelectedIndex");
                }
            }
        }



        private bool _Check1;
        public bool Check1
        {
            get { return _Check1; }
            set
            {
                if (!value.Equals(_Check1))
                {
                    _Check1 = value;
                    Alpha = 0;
                    OnPropertyChanged("Check1");
                    
                }
            }
        }

        private bool _Check2;
        public bool Check2
        {
            get { return _Check2; }
            set
            {
                if (!value.Equals(_Check2))
                {
                    _Check2 = value;
                    Red = 0;
                    OnPropertyChanged("Check2");

                }
            }
        }

        private bool _Check3;
        public bool Check3
        {
            get { return _Check3; }
            set
            {
                if (!value.Equals(_Check3))
                {
                    _Check3 = value;
                    Green = 0;
                    OnPropertyChanged("Check3");

                }
            }
        }
        private bool _Check4;
        public bool Check4
        {
            get { return _Check4; }
            set
            {
                if (!value.Equals(_Check4))
                {
                    _Check4 = value;
                    Blue = 0;
                    OnPropertyChanged("Check4");

                }
            }
        }
        public ObservableCollection<ARGB> ARGB { get; set; } = new ObservableCollection<ARGB>();


        private SolidColorBrush _colorARGB;
        public SolidColorBrush ColorARGB
        {
            get { return _colorARGB; }
            set
            {
                if (!value.Equals(_colorARGB))
                {
                    _colorARGB = value;
                    OnPropertyChanged("ColorARGB");
                }
            }
        }

        private int _alpha;
        public int Alpha
        {
            get { return _alpha; }
            set
            {
                if (_alpha != value)
                {
                    _alpha = value;
                    OnPropertyChanged("Alpha");
                    UpdateButtonColor();
                }
            }
        }

        private int _red;
        public int Red
        {
            get { return _red; }
            set
            {
                if (_red != value)
                {
                    _red = value;
                    OnPropertyChanged("Red");
                    UpdateButtonColor();
                }
            }
        }

        private int _green;
        public int Green
        {
            get { return _green; }
            set
            {
                if (_green != value)
                {
                    _green = value;
                    OnPropertyChanged("Green");
                    UpdateButtonColor();
                }
            }
        }

        private int _blue;
        public int Blue
        {
            get { return _blue; }
            set
            {
                if (_blue != value)
                {
                    _blue = value;
                    OnPropertyChanged("Blue");
                    UpdateButtonColor();
                }
            }
        }

        public ARGB_ViewModel()
        {
            UpdateButtonColor();

            addComand = new MyCommands(param => Add(), param => CanAdd());
            delComand = new MyCommands(param => Del(), param => CanDel());

        }

        public void Add()
        {

            ARGB cl = new ARGB(Alpha,Red,Green,Blue,ColorARGB);
            
            ARGB.Add(cl);
            
            

          
        }

        public bool CanAdd()
        {
            foreach (var item in ARGB)
            {
                if (item.Alpha == Alpha && item.Green == Green && item.Red == Red && item.Blue == Blue)
                {
                    return false;
                }
            }
           
            return true;
        }

        public void Del()
        {


            MessageBoxResult res = MessageBox.Show("Вы уверены что хотите удалить элемент?", "Точно?",
            MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (res == MessageBoxResult.Yes) ARGB.RemoveAt(SelectedIndex);



        }

        public bool CanDel()
        {
            if (ARGB.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void UpdateButtonColor()
        {
            ColorARGB = new SolidColorBrush(Color.FromArgb((byte)Alpha, (byte)Red, (byte)Green, (byte)Blue));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }



      
    }
}
