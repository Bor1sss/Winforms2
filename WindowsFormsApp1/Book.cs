using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    [DataContract]
    [Serializable]
    public class Book
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string Author {  get; set; }    

        public Book()
        {
            Name = "";
            Title = "";
            Author = "";
        }
        public Book(string name, string title, string author)
        {
            Name = name;
            Title = title;
            Author = author;
        }

    

    }
}
