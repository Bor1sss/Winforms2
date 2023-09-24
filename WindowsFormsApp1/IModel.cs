using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;



namespace WindowsFormsApp1
{
        public interface IModel
        {
        
        List<Book> books { get; set; }
        void Add_Author(int i, string a);
        void Change_Author(int i, string a);
        void Delete_Author(int i);
        void Add_BookName(string newBookName);
        void Change_BookName(int i,string a);
        void Delete_BookName(int i);
        List<Book> Show_All();
        List<Book> Show_BooksA(string A);

     
        void SaveFile(string name);
        void LoadFile(string name);

        }


    public class Books_Program : IModel
    {

        public List<Book> books { get; set; }   
        public string filename {  get; set; }

        public Books_Program() {
        
        books=new List<Book>();
        }
        public void Add_Author(int i,string newAuthor)
        {
            
                if (i < 0 || i > books.Count()) { throw new Exception("Eror ror"); }
                books[i].Author=newAuthor;


            
        }

        public void Add_BookName(string newBookName)
        {
            books.Add(new Book(newBookName, "title", " "));
        }

        public void Change_Author(int i, string newAuthor)
        {
            if (i < 0 || i > books.Count()) { throw new Exception("Wrong"); }
            books[i].Author = newAuthor;

        }

        public void Change_BookName(int i, string newBookName)
        {
            if (i < 0 || i > books.Count()) { throw new Exception(); }
            books[i].Name = newBookName;

        }



        public void Delete_Author(int i)
        {
            
            if (i < 0 || i > books.Count()||books.Count()==0) { throw new Exception("Nothing heppend"); }
            books[i].Author=" ";

        }

        public void Delete_BookName(int i)
        {
            if (i < 0 || i > books.Count()) { throw new Exception("Something went wrong"); }
            books.RemoveAt(i);


        }

        public void LoadFile(string name)
        {
            string jsonFromFile = File.ReadAllText($"{name}");
            books=JsonSerializer.Deserialize<List<Book>>(jsonFromFile);


        }

        public void SaveFile(string name)
        {
            string json=JsonSerializer.Serialize(books);
            File.WriteAllText($"{name}.json", json);



        }

        public List<Book> Show_All()
        {
            return books;
        }

        public List<Book> Show_BooksA(string A)
        {
            List<Book> list = new List<Book>();
            foreach (var item in books)
            {
                if (item.Author.Contains(A))
                {
                    list.Add(item);
                }
            }
            return list;
        }
    }


    
}
