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
        
        public Form1()
        {
            InitializeComponent();
            Show_All?.Invoke(this, EventArgs.Empty);
            MinimizeBox = false;
            MaximizeBox = false;
        }

        public int indexBook { get; set; }
        public int indexAuthor { get; set; }
        public string Text { get; set; }
        public string curAuthor { get; set; }

        public string curBook { get; set; }


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

        public void WriteAllBooks(List<string> list)
        {

            listBox1.Items.Clear();
            
            foreach (var item in list)
            {
                listBox1.Items.Add(item);
            }   
        }
        public void WriteAllAuthors(List<string> list)
        {
            comboBox1.Items.Clear();

            foreach (var item in list)
            {
                comboBox1.Items.Add(item);
            }
           
        }
        private void добавитьToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            try
            {

                try
                {
                    Form2 form2 = new Form2("Введите нового Автора");
                    DialogResult result = form2.ShowDialog();

                    if (result == DialogResult.Yes)
                    {
                        Text = form2.newText;
                        Add_Author?.Invoke(this, EventArgs.Empty);
                    }
                    else
                    {
                        throw new Exception("Canceled");
                    }
                }
                catch (Exception mes)
                {

                    MessageBox.Show(mes.Message);
                }
            }
            catch (Exception mes)
            {

                MessageBox.Show(mes.Message);
            }
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Are u sure ?","Warning",MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    Delete_Author?.Invoke(this, EventArgs.Empty);
                }
                else
                {
                    throw new Exception("Canceled");
                }
            }
            catch (Exception mes)
            {

                MessageBox.Show(mes.Message);
            }
        }

        private void редактироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Form2 form2 = new Form2("Введите нового Автора");
                DialogResult result =form2.ShowDialog();
               
                if (result == DialogResult.Yes)
                {
                    Text = form2.newText;
                    Change_Author?.Invoke(this, EventArgs.Empty);
                }
                else
                {
                    throw new Exception("Canceled");
                }
            }
            catch (Exception mes)
            {

                MessageBox.Show(mes.Message);
            }
        }

        private void добавитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {   
                Form2 form2 = new Form2("Введите новую книгу");
                DialogResult result = form2.ShowDialog();
                if (result == DialogResult.Yes)
                {
                    Text = form2.newText;
                    Add_BookName?.Invoke(this, EventArgs.Empty);
                }
                else
                {
                    throw new Exception("Canceled");
                }
            }
            catch (Exception mes)
            {

                MessageBox.Show(mes.Message);
            }
        }

        private void удалитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Are u sure", "Warning", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {

                    Delete_BookName?.Invoke(this, EventArgs.Empty);
                }
                else
                {
                    throw new Exception("Canceled");
                }
            }
            catch (Exception mes)
            {

                MessageBox.Show(mes.Message);
            }
        }

        private void редактироватьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                Form2 form2 = new Form2("Введите новую книгу");
                DialogResult result = form2.ShowDialog();
                if (result == DialogResult.Yes)
                {
                    Text = form2.newText;
                    Change_BookName?.Invoke(this, EventArgs.Empty);
                }
                else
                {
                    throw new Exception("Canceled");
                }
            }
            catch (Exception mes)
            {

                MessageBox.Show(mes.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            indexAuthor=comboBox1.SelectedIndex;
            curAuthor = comboBox1.Text;
            if (checkBox1.Checked)
            {
                Show_BooksA?.Invoke(this, EventArgs.Empty);

            }
       

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            indexBook=listBox1.SelectedIndex;
            if (listBox1.SelectedIndex != -1)
            {
                curBook = listBox1.SelectedItem.ToString();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            curAuthor = comboBox1.Text;
            if (checkBox1.Checked)
            {
                Show_BooksA?.Invoke(this, EventArgs.Empty);

            }
            else
            {
                Show_All?.Invoke(this, EventArgs.Empty);
                indexAuthor = -1;
            }
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Json files(*.json)|*.json";
            if (DialogResult.OK == saveFileDialog.ShowDialog())
            {
                
                Text = saveFileDialog.FileName;
                SaveFile?.Invoke(this, EventArgs.Empty);
            }

        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Json files(*.json)|*.json";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
               

                Text = openFileDialog.FileName;
                LoadFile?.Invoke(this, EventArgs.Empty);
            }
        }

        private void выйтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
