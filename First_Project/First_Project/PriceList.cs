using System.Reflection;

namespace First_Project
{
    [Serializable]
    internal class PriceList
    {
        public List<StorageInfo> list;

    public PriceList() { 
            list = new List<StorageInfo>();
        
    }

    public void Add(StorageInfo storage)
        {
            list.Add(storage);
        }
        public void Remove(StorageInfo storage)
        {
            list.Remove(storage);
        }
        public void Edit(string obj,string NewItem,int i)
        {
           
             
                    Type myType = typeof(StorageInfo);
                    PropertyInfo[] myField = myType.GetProperties();
                    foreach (var fields in myField)
                    {

                        if (fields.Name.Contains(obj))
                        {
                            Console.WriteLine("Find By \t" + fields.Name + '\n' + '\n');
                            fields.SetValue(list[i], NewItem);
                        }
                    }
                
            
        }

        public void Print(Ilog ilog)
        {
            foreach (StorageInfo storage in list)
            {
                storage.Print(ilog);
            }
        }
        public void Find(string Request,Ilog ilog)
        {
       
            foreach (var item in list)
            {
                Type myType = typeof(StorageInfo);
                PropertyInfo[] myField = myType.GetProperties();
                foreach (var fields in myField)
                {

                    if (fields.GetValue(item).ToString().Contains(Request))
                    {
                        Console.WriteLine("Find By \t" + fields.Name +'\n'+'\n') ;
                        item.Print(ilog);
                    }
                }
            }
        }
        public void Save(ISerealise serealise,string filename)
        {
            serealise.Save(list,filename);
        }
        public void Load(ISerealise serealise, string filename)
        {
            list=serealise.Load(filename);
        }



    }
}
