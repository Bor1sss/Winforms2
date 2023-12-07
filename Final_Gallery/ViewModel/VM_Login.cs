using Final_Gallery.Commands;
using Final_Gallery.Data;
using Final_Gallery.Model_Login;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using System.Windows.Navigation;
using Final_Gallery.ViewModel_Login;
using Final_Gallery.View;

namespace Final_Gallery.ViewModel
{
    internal class VM_Login:INotifyPropertyChanged
    {



        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        private Command SignIn;
        private Command Register;
        private M_Login user;
        public string Login
        {
            get { return user.Login; }
            set
            {
                user.Login = value;
                OnPropertyChanged(nameof(Login));
            }
        }
        public string Password
        {
            get { return user.Password; }
            set
            {
                user.Password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

    
        public ICommand SignInCommand
        {
            get
            {

                return SignIn;


            }
        }
        public ICommand RegCommand
        {
            get
            {

                return Register;


            }
        }
        private bool CanRegister()
        {
            return true;
        }

        private void Reg()
        {
            RegisterWindow reg = new RegisterWindow();
            App.Current.Windows[0].Close();

            reg.Show();
        }
        private bool CanSignIn()
        {
            return true;
        }
        private void Sign()
        {
            try
            {
                
                if (Login.Length < 3 ||
                    Password.Length <= 8)
                {
                    throw new Exception("Fields must not be empty");
                }
                if (DataFinder.CheckLoginPassword(Login, Password,true))
                {
                    Gallery g = new Gallery();
                    App.Current.MainWindow.Close();
                
                    g.Show();
                }
                else
                {
                    MessageBox.Show("Passwor or Username is incorrect try again or Register","Warning");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK);
            }

        }

        public VM_Login()
        {
            SignIn = new Command(param => Sign(), param => CanSignIn());
            Register = new Command(param => Reg(), param => CanRegister());
            user = M_Login.Instance;
        }
    }
}
