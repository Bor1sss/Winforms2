using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public interface IView
    {


        event EventHandler<EventArgs> Show_All;
        event EventHandler<EventArgs> Add_Author;
        event EventHandler<EventArgs> Change_Author;
        event EventHandler<EventArgs> Delete_Author;
        event EventHandler<EventArgs> Add_BookName;
        event EventHandler<EventArgs> Change_BookName;
        event EventHandler<EventArgs> Delete_BookName;
        event EventHandler<EventArgs> Show_BooksA;
        event EventHandler<EventArgs> SaveFile;
        event EventHandler<EventArgs> LoadFile;

      
         int indexBook { get; set; }
         int indexAuthor { get; set; }
            
            string Text {  get; set; }  
            string curAuthor {  get; set; }  
            string curBook {  get; set; }  
        void ShowErrorMessages(string message);

        void WriteAllBooks(List<string> list);
        void WriteAllAuthors(List<string> list);

    }
}
