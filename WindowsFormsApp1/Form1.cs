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
    public partial class Form1 : Form, IView
    {
        Presenter presenter;
        public Form1()
        {
            InitializeComponent();
            Show_All?.Invoke(this, EventArgs.Empty);
            presenter= new Presenter(new Books_Program(),this);
        }
        public string Text {  get; set; }
        public int index { get; set; }

        public event EventHandler<EventArgs> Show_All;
        public event EventHandler<EventArgs> Add_Author;
        public event EventHandler<EventArgs> Change_Author;
        public event EventHandler<EventArgs> Delete_Author;
        public event EventHandler<EventArgs> Add_BookName;
        public event EventHandler<EventArgs> Change_BookName;
        public event EventHandler<EventArgs> Delete_BookName;
        public event EventHandler<EventArgs> Show_BooksA;
        public event EventHandler<EventArgs> SaveFile;
        public event EventHandler<EventArgs> LoadFile;

        public void ShowErrorMessages(string mes)
        {

            MessageBox.Show(mes);
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
        
            Delete_Author?.Invoke(this, EventArgs.Empty);

        }
        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Json files(*.json)|*.json"; 
            openFileDialog.ShowDialog();
            Text = openFileDialog.FileName;
            LoadFile?.Invoke(this, EventArgs.Empty);

        }
        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
             saveFileDialog.Filter = "Json files(*.json)|*.json";
            saveFileDialog.ShowDialog();
             Text = saveFileDialog.FileName;
             SaveFile?.Invoke(this, EventArgs.Empty);

        }

        private void добавитьКнигуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Add_BookName?.Invoke(this, EventArgs.Empty);
            
        }

        public void WriteAllBooks(List<Book>list)
        {
            comboBox1.Items.Clear();
            listBox1.Items.Clear();
            foreach (Book book in list)
            {
               comboBox1.Items.Add(book.Author);
            }
            if (!checkBox1.Checked)
            {
                foreach (Book book in list)
                {
                    listBox1.Items.Add(book.Name);
                }
            }
            else
            {
                foreach (Book book in list)
                {
                    if (comboBox1.Text.Contains(book.Author))
                    {
                        listBox1.Items.Add(book.Name);
                    }
                }
            }
        }

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Add_Author?.Invoke(this, EventArgs.Empty);  
        }

        private void редактироватьКнигуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Change_BookName?.Invoke(this, EventArgs.Empty);
        }

        private void удалитьКнигуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Delete_BookName?.Invoke(this, EventArgs.Empty);
        }

        private void редактироватьАвтораToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Change_Author?.Invoke(this, EventArgs.Empty);
        }

        private void выйтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Show_All?.Invoke(this, EventArgs.Empty);
        }
    }
}
