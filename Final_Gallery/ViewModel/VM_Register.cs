using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Navigation;
using System.Windows;
using System.ComponentModel;
using Final_Gallery.Commands;
using Final_Gallery.Model_Login;
using Final_Gallery.Data;
using Final_Gallery.View;

namespace Final_Gallery.ViewModel
{
    internal class VM_Register:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }



        private Command SignUp;
        private Command Cancel;
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
        private string repPass;
        public string RepeatPassword
        {
            get { return repPass; }
            set
            {
                repPass = value;
                OnPropertyChanged(nameof(RepeatPassword));
            }
        }
        public string Name
        {
            get { return user.Name; }
            set
            {
                user.Name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public string Surname
        {
            get { return user.Surname; }
            set
            {
                user.Surname = value;
                OnPropertyChanged(nameof(Surname));
            }
        }
        public ICommand SignUpCommand
        {
            get
            {

                return SignUp;
              
               
            }
        }
        public ICommand CancelCommand
        {
            get
            {

                return Cancel;
            }
        }
        private bool CanCancel()
        {
            return true;
        }
        private void CANCEL()
        {
            MainWindow mainWindow = new MainWindow();
            App.Current.Windows[0].Close();

            mainWindow.Show();
        }
        private bool CanSignUp()
        {
            return true;
        }
        private void Sign()
        {
          
            if (Surname.Length < 3 ||
                Name.Length < 3 ||
                Login.Length < 3 ||
                Password.Length <= 8)
            {
                MessageBox.Show("Fields must not be empty", "Error", MessageBoxButton.OK);
                return;
            }
            if (Password != RepeatPassword)
            {
                MessageBox.Show("Password mismatch", "Error", MessageBoxButton.OK);
                return;
            }
      
            if (DataFinder.CheckLoginPassword(Login,Password,false))
            {
                MessageBox.Show("Пользователь с таким логином уже существует.", "Error", MessageBoxButton.OK);

            }
            else
            {

                Gallery g = new Gallery();
                FileManager.AddM_Login(M_Login.Instance);
                App.Current.Windows[0].Close();
               
                g.Show();
            }
           
        }

        public VM_Register()
        {
            SignUp = new Command(param => Sign(), param => CanSignUp());
            Cancel = new Command(param => CANCEL(), param => CanCancel());
            user = M_Login.Instance;
        }
    }
}

