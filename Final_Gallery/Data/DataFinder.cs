using Final_Gallery.Model_Login;
using Final_Gallery.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;
using System.Xml.Serialization;

namespace Final_Gallery.Data
{
    static internal class DataFinder
    {
        public  static bool CheckLoginPassword(string Login,string Password,bool Auth)
        {
            try
            {
                var list = FileManager.LoadLogins();

                if (Auth)
                {
                    foreach (var item in list.Logins)
                    {
                        if (item.Login == Login && item.Password == Password)
                        {
                           
                            return true;
                        }
                    }
                    return false;
                }


                else
                {
                    foreach (var item in list.Logins)
                    {
                        if (item.Login == Login)
                        {
                            MessageBox.Show("Error");
                            return true;
                        }
                    }

                    return false;
                }

            }
            catch
            {
                return false;
            }
          
        }
     
    }
}
