using System.Runtime.Serialization.Json;
using System.Xml.Serialization;

namespace First_Project
{
    public interface ISerealise
    {

        void Save(List<StorageInfo> storages, string filename);
        List<StorageInfo> Load(string filename);


    }


    public class JsonSerialise : ISerealise
    {

        public List<StorageInfo> Load(string filename)
        {
            List<StorageInfo> ls = new List<StorageInfo>();
            var storage = new StorageInfo[1];

            FileStream stream = new FileStream("device2.json", FileMode.Open);
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(StorageInfo[]));
            storage = (StorageInfo[])jsonFormatter.ReadObject(stream);
            for (int i = 0; i < storage.Length; i++)
            {
                ls.Add(storage[i]);

            }
            Console.WriteLine();
            stream.Close();
            return ls;
        }

        public void Save(List<StorageInfo> storages, string filename)
        {


            var storage = new StorageInfo[3];


            FileStream stream = new FileStream("device2.json", FileMode.Create);
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(StorageInfo[]));
            jsonFormatter.WriteObject(stream, storages.ToArray());

            stream.Close();
            Console.WriteLine("Сериализация успешно выполнена!");
        }
    }
    public class XmlSerialise : ISerealise
    {
        public List<StorageInfo> Load(string filename)
        {
            List<StorageInfo> ls = new List<StorageInfo>();
            var storage = new StorageInfo[1];
            FileStream stream = new FileStream("device2.xml", FileMode.Open);
            XmlSerializer jsonFormatter = new XmlSerializer(typeof(StorageInfo[]));
            storage = (StorageInfo[])jsonFormatter.Deserialize(stream);
            for (int i = 0; i < storage.Length; i++)
            {
                ls.Add(storage[i]);

            }
            Console.WriteLine();
            stream.Close();
            return ls;
        }

        public void Save(List<StorageInfo> storages, string filename)
        {




            FileStream stream = new FileStream("device2.xml", FileMode.Create);
            XmlSerializer jsonFormatter = new XmlSerializer(typeof(StorageInfo[]));
            jsonFormatter.Serialize(stream, storages.ToArray());

            stream.Close();
            Console.WriteLine("Сериализация успешно выполнена!");
        }


    }
}