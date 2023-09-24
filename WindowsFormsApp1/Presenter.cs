using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Presenter
    {
        private readonly IModel _iModel;

        private readonly IView _IView;

        public int Index;
        public string Text;

      
        public Presenter(IModel iModel, IView iView)
        {

        
            Text = " ";
            _iModel = iModel;
            _IView = iView;
            _IView.LoadFile += new EventHandler<EventArgs>(LoadFile);


            _IView.Delete_Author += new EventHandler<EventArgs>(Delete_Author);
            _IView.Delete_Author += new EventHandler<EventArgs>(ShowAll);


            _IView.Add_BookName += new EventHandler<EventArgs>(Add_book);
            _IView.Add_BookName += new EventHandler<EventArgs>(ShowAll);


            _IView.Show_All += new EventHandler<EventArgs>(ShowAll);


            _IView.Add_Author += new EventHandler<EventArgs>(Add_Author);
            _IView.Add_Author += new EventHandler<EventArgs>(ShowAll);


            _IView.Change_BookName += new EventHandler<EventArgs>(Change_BookName);
            _IView.Change_BookName += new EventHandler<EventArgs>(ShowAll);

            _IView.Delete_BookName += new EventHandler<EventArgs>(Delete_BookName);
            _IView.Delete_BookName += new EventHandler<EventArgs>(ShowAll);



            _IView.Change_Author += new EventHandler<EventArgs>(Change_Author);
            _IView.Change_Author += new EventHandler<EventArgs>(ShowAll);

            _IView.SaveFile += new EventHandler<EventArgs>(SAVE);
            _IView.SaveFile += new EventHandler<EventArgs>(ShowAll);
           

            _IView.LoadFile += new EventHandler<EventArgs>(LoadFile);
            _IView.LoadFile += new EventHandler<EventArgs>(ShowAll);
        }

        public void SAVE(object sender,EventArgs e)
        {

            try
            {
                _iModel.SaveFile(_IView.Text);
            }
            catch (Exception mes)
            {

                _IView.ShowErrorMessages(mes.Message);
            }


        }


        public void ChangeForms()
        {
            Form3 form3 = new Form3(_iModel.books, ref Index);
            form3.Text = "Change";
            form3.ShowDialog();
            _IView.index = form3.Index;

            Form2 form2 = new Form2(ref Text);
            form2.Text = "";
            form2.ShowDialog();
            _IView.Text = form2.Text;
            
        }
        
        public void DeleteForms()
        {
            Form3 form3 = new Form3(_iModel.books, ref Index);
            form3.Text = "Delete";
            form3.ShowDialog();
            _IView.index = form3.Index;
        }
        public void AddForms()
        {
            Form2 form2 = new Form2(ref Text);
            form2.ShowDialog();

            _IView.Text = form2.Text;

        }
        public void Change_BookName(object sender, EventArgs e)
        {
            try
            {
                ChangeForms();
                _iModel.Change_BookName(_IView.index, _IView.Text);
            }
            catch (Exception mes)
            {
                _IView.ShowErrorMessages(mes.Message);
                throw;
            }
        }
        public void Change_Author(object sender, EventArgs e)
        {
            try
            {
                ChangeForms();
                _iModel.Change_Author(_IView.index, _IView.Text);
            }
            catch (Exception mes)
            {
                _IView.ShowErrorMessages(mes.Message);
                throw;
            }
        }

        public void Add_Author(object sender, EventArgs e)
        {
            try
            {

             ChangeForms();

             _iModel.Add_Author(Index, _IView.Text);

            }
            catch (Exception mes)
            {

                _IView.ShowErrorMessages(mes.Message);
            }


        }
        public void ShowAll(object sender, EventArgs e)
        {
            _IView.WriteAllBooks(_iModel.books);
        }
        public void Add_book(object sender, EventArgs e)
        {
            try
            {

          
            AddForms();
            _iModel.Add_BookName(_IView.Text);
            }
            catch (Exception mes)
            {
                _IView.ShowErrorMessages(mes.Message);
                throw;
            }

        }
        public void Delete_BookName(object sender, EventArgs e)
        {
            try
            {

                DeleteForms();
                _iModel.Delete_BookName(_IView.index);
            }
            catch (Exception mes)
            {

                _IView.ShowErrorMessages(mes.Message);
            }

        }
        public void Delete_Author(object sender, EventArgs e)
        {
            try
            {

                DeleteForms();
                _iModel.Delete_Author(_IView.index);
            }
            catch(Exception mes) {

                _IView.ShowErrorMessages(mes.Message);
            }

        }

        private void LoadFile(object sender, EventArgs e)
        {
            
            try
            {
                _iModel.LoadFile(_IView.Text);
            }
            catch (Exception mes)
            {

                _IView.ShowErrorMessages(mes.Message);
            }
          

        }



    }

    
}
