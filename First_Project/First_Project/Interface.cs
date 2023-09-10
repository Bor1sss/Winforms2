using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_Project
{
    internal class Interface
    {

        public PriceList priceList {  get; set; }
        public Ilog Ilog { get; set; }  
        public ISerealise Iserealise { get; set; }

        public Interface() {
        Ilog=new ConsoleLog();
        Iserealise=new XmlSerialise();
        
        }
        public void ChangeSerialise()
        {
            Console.WriteLine("Choose 1-2 (1-json 2-xml)");
            int i = Convert.ToInt32(Console.ReadLine());
            switch (i)
            {
                case 1: Iserealise = new JsonSerialise(); break;
                case 2: Iserealise = new XmlSerialise(); break;
              
                default: Console.WriteLine("Error"); break;
            }
        }
        public void ChangeLog()
        {
            Console.WriteLine("Choose 1-3 (1-console 2-xmllog 3-filelog)");
            int i=Convert.ToInt32(Console.ReadLine());
            switch (i) {
            case 1:Ilog = new ConsoleLog();break;
            case 2:Ilog = new XmlLog();break;
            case 3:Ilog = new FileLog();break;
            default:Console.WriteLine("Error");break;
            }
        }
        public void Print()
        {
            
            priceList.Print(Ilog);
        }
        public void Add()
        {
            Console.WriteLine("Choose 1-3 (1-Flash 2-HDD 3-DVD)");
            int i = Convert.ToInt32(Console.ReadLine());
            switch (i)
            {
                case 1: priceList.Add(new Flash("FLASH","FLASH MODEL","KG","100mb",2,12.2)); break;
                case 2: priceList.Add(new HDD("HDD", "HDD MODEL", "GA", "12mb", 1, 111.2)); break;
                case 3: priceList.Add(new DVD("DVD", "DVD MODEL", "DVD", "DVD", 1, 112)); ;   break;
                default: Console.WriteLine("Error"); break;
            }
            
        }
        
        public void AddMoreInfo()
        {
            //Метод add перенаправляет нас сюда и тут мы добовляем все поля для hdd flash dvd
        }
        public void Find()
        {
            Console.WriteLine("What you want to find ?");
            string Request = Console.ReadLine();
            priceList.Find(Request,Ilog);


        }
        public void Save()
        {
            Console.WriteLine("TypeFile name");
            string filename = Console.ReadLine();

            priceList.Save(Iserealise,filename);
        }
        public void Load()
        {
            Console.WriteLine("TypeFile name");
            string filename = Console.ReadLine();

            priceList.Load(Iserealise, filename);
        }

        public void Edit()
        {
            try
            {
                Console.WriteLine($"What you want to delete [1-{priceList.list.Count}]");
                int i = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Type what field you want to change");
                string field = Console.ReadLine();
                Console.WriteLine("Type what new you want");
                string NewItem = Console.ReadLine();
                priceList.Edit(field, NewItem, i-1);
            }
            catch (Exception ex) { Console.WriteLine("Error wrong "); }

        }
        public void Remove()
        {
            try
            {



               
                Console.WriteLine($"What you want to delete [1-{priceList.list.Count}]");
                int i = Convert.ToInt32(Console.ReadLine());
                priceList.Remove(priceList.list[i - 1]);
            }
            catch (Exception)
            {

                Console.WriteLine("Invalid numb");
            }
        }
    }
}
