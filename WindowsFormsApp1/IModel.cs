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
        void Add_Author(string a);
        void Change_Author(int i, string a);
        void Delete_Author(int i);
        void Add_BookName(int i,string newBookName);
        void Change_BookName(int i,string a, string curBook);
        void Delete_BookName(int i, string BookName);
        List<string> Show_All();
        List<string> Show_AllAuthors();
        List<string> Show_BooksA(string A);

     
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
        public void Add_Author(string newAuthor)
        {
            
               
                books.Add(new Book("", "title", newAuthor));



        }

        public void Add_BookName(int i, string newA)
        {
          
            if (i < 0 || i > books.Count()||books.Count<1) { throw new Exception("No Author Exist"); }

            books[i].Name.Add(newA);
            
          
        }

        public void Change_Author(int i, string newAuthor)
        {
            if (i < 0 || i > books.Count()||books.Count<1) { throw new Exception("Nothing happend"); }
            books[i].Author = newAuthor;

        }

        public void Change_BookName(int i, string newBookName,string curBook)
        {
            if (i < 0 || i > books.Count() || books.Count < 1) { throw new Exception("Something went wrong"); }


            foreach (var item in books)
            {

                if (item.Name.Contains(curBook))
                {
                    item.Name[item.Name.IndexOf(curBook)] = newBookName;
                }


            }



        }



        public void Delete_Author(int i)
        {
            
            if (i < 0 || i > books.Count()||books.Count()==0) { throw new Exception("Nothing heppend"); }
            books.RemoveAt(i);

        }

        public void Delete_BookName(int i,string BookName)
        {
            if (i > books.Count()) { throw new Exception("Something went wrong"); }
        
                foreach (var item in books)
                {
                    if (item.Name.Contains(BookName))
                    {
                        item.Name.Remove(BookName);
                    }
                }
      
            


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

        public List<string> Show_All()
        {
            List<string> list = new List<string>();
            foreach (var item in books)
            {
                foreach (var item2 in item.Name)
                {
                    if (item2 != "")
                    {
                        list.Add(item2);
                    }
                }
                    
                
            }
            return list;
        }

        public List<string> Show_BooksA(string a)
        {
            List<string> list = new List<string>();
            foreach (var item in books)
            {
                foreach (var item2 in item.Name)
                {
                    if (item.Author.Contains(a))
                    {
                        if (item2 != "")
                        {
                            list.Add(item2);
                        }
                    }
                }
              
            }
            return list;
        }
        public List<string> Show_AllAuthors()
        {
            List<string> list = new List<string>();
            foreach (var item in books)
            {
                if (!list.Contains(item.Author))
                {
                    list.Add(item.Author);
                }
            }
            return list;
        }
    }


    
}
