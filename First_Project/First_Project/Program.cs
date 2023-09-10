namespace First_Project
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Interface @interface = new Interface();
            PriceList price = new PriceList();
            @interface.ChangeLog();
            @interface.ChangeSerialise();
          
            
            @interface.priceList = price;
            @interface.Add();
            @interface.Add();
            // @interface.Find();
            
            //@interface.Remove();
            @interface.Print();
            @interface.Edit();
            @interface.Print();
            //@interface.Save();
        /*    @interface.Load();
            @interface.Print();*/
        }
    }
}