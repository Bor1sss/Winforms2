using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form3 : Form
    {
        public Form3(List<Book> books,ref int Ind)
        {
            MaximizeBox = false;

            List = books;
            InitializeComponent();
            int i = 0;
            foreach (Book book in books)
            {
                i++;
                listBox1.Items.Add($"Book {i}: {book.Name}  | {book.Author}");
            }
            Index = Ind;

            
        }
        
       public List<Book> List {  get; set; }
        public int Index {  get; set; }
        private void button1_Click(object sender, EventArgs e)
        {
             Index = listBox1.SelectedIndex;
            
             this.Close();
        }
    }
}
