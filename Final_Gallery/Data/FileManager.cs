using Final_Gallery.Model_Login;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;

namespace Final_Gallery.Data
{
    internal class FileManager
    {
        public static void AddM_Login(M_Login newLogin)
        {
            M_LoginCollection loginCollection = new M_LoginCollection();

            if (File.Exists("data.xml"))
            {
                loginCollection = LoadLogins();
            }
            else
            {
                loginCollection.Logins = new List<M_Login>();
            }

            loginCollection.Logins.Add(newLogin);

            SaveLogins(loginCollection);
        }

        private static void SaveLogins(M_LoginCollection loginCollection)
        {
            try
            {
                DataContractSerializer serializer = new DataContractSerializer(typeof(M_LoginCollection));

                using (FileStream fileStream = new FileStream("data.xml", FileMode.Create))
                {
                    using (XmlWriter xmlWriter = XmlWriter.Create(fileStream))
                    {
                        serializer.WriteObject(xmlWriter, loginCollection);
                    }
                }
            }
            catch (Exception)
            {
                
            }
        }

        public static M_LoginCollection LoadLogins()
        {
            try
            {
                M_LoginCollection loginCollection = new M_LoginCollection();

                if (File.Exists("data.xml"))
                {
                    DataContractSerializer serializer = new DataContractSerializer(typeof(M_LoginCollection));

                    using (FileStream fileStream = new FileStream("data.xml", FileMode.Open))
                    {
                        using (XmlReader xmlReader = XmlReader.Create(fileStream))
                        {
                            loginCollection = (M_LoginCollection)serializer.ReadObject(xmlReader);
                        }
                    }
                }
                return loginCollection;
            }
            catch {

                throw new Exception();
            }
           
        }




        
        public static void SaveAlbum(string filename,Album album) {

            try
            {
                DataContractSerializer serializer = new DataContractSerializer(typeof(Album));

                using (FileStream fileStream = new FileStream(filename, FileMode.Create))
                {
                    using (XmlWriter xmlWriter = XmlWriter.Create(fileStream))
                    {
                        serializer.WriteObject(xmlWriter, album);
                    }
                }
            }
            catch (Exception)
            {

            }

        }
        public static Album LoadAlbum(string filename)
        {

            try
            {
                Album album = new Album();

                if (File.Exists(filename))
                {
                    DataContractSerializer serializer = new DataContractSerializer(typeof(Album));

                    using (FileStream fileStream = new FileStream(filename, FileMode.Open))
                    {
                        using (XmlReader xmlReader = XmlReader.Create(fileStream))
                        {
                            album = (Album)serializer.ReadObject(xmlReader);
                        }
                    }
                }
                return album;
            }
            catch
            {

                throw new Exception();
            }

        }

    }
}
