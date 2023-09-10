namespace First_Project
{
    public interface Ilog
    {
        void Print(string s);

    }


    public class ConsoleLog : Ilog
    {
        public void Print(string s)
        {
            Console.WriteLine(s);
        }
    }
    public  class XmlLog : Ilog
    {   
        
        public void Print(string s) 
        {
            Console.WriteLine("Xml+" + s); 
        }
    }
    public class FileLog : Ilog
    {
        public void Print(string s)
        {   File.AppendAllText("../../../../log.txt", "| " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " |\n");
            File.AppendAllText("../../../../log.txt", s);
        }
    }
}