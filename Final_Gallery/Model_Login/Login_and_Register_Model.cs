using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Final_Gallery.Model_Login
{
    [Serializable]
    public class M_Login
    {
        [NonSerialized]
        private static M_Login _instance;
        public static M_Login Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new M_Login();
                return _instance;
            }
        }

        public string Login;
        public string Password;
        public string Name;
        public string Surname;
        private M_Login()
        {
            Login = string.Empty;
            Password = string.Empty;
            Name = string.Empty;
            Surname = string.Empty;
        }
    }
    [DataContract]
    public class M_LoginCollection
    {
        [DataMember]
        public List<M_Login> Logins { get; set; }
    }

}
