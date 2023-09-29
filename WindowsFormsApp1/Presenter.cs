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
            _IView.LoadFile += new EventHandler<EventArgs>(ShowAllAuthor);
            _IView.LoadFile += new EventHandler<EventArgs>(ShowAllBooks);


            _IView.Delete_Author += new EventHandler<EventArgs>(Delete_Author);
            _IView.Delete_Author += new EventHandler<EventArgs>(ShowAllAuthor);
            _IView.Delete_Author += new EventHandler<EventArgs>(ShowAllBooks);


            _IView.Add_BookName += new EventHandler<EventArgs>(Add_book);
  
            _IView.Add_BookName += new EventHandler<EventArgs>(ShowAllBooks);


            _IView.Show_All += new EventHandler<EventArgs>(ShowAllAuthor);
            _IView.Show_All += new EventHandler<EventArgs>(ShowAllBooks);


            _IView.Add_Author += new EventHandler<EventArgs>(Add_Author);
            _IView.Add_Author += new EventHandler<EventArgs>(ShowAllAuthor);
      


            _IView.Change_BookName += new EventHandler<EventArgs>(Change_BookName);

            _IView.Change_BookName += new EventHandler<EventArgs>(ShowAllBooks);

            _IView.Delete_BookName += new EventHandler<EventArgs>(Delete_BookName);
  
            _IView.Delete_BookName += new EventHandler<EventArgs>(ShowAllBooks);



            _IView.Change_Author += new EventHandler<EventArgs>(Change_Author);
            _IView.Change_Author += new EventHandler<EventArgs>(ShowAllAuthor);


            _IView.SaveFile += new EventHandler<EventArgs>(SAVE);
            _IView.SaveFile += new EventHandler<EventArgs>(ShowAllAuthor);
            _IView.SaveFile += new EventHandler<EventArgs>(ShowAllBooks);
           

            _IView.LoadFile += new EventHandler<EventArgs>(LoadFile);
            _IView.LoadFile += new EventHandler<EventArgs>(ShowAllAuthor);
            _IView.LoadFile += new EventHandler<EventArgs>(ShowAllBooks);


            _IView.Show_BooksA += new EventHandler<EventArgs>(ShowAllBooks_A);

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


        public void Change_BookName(object sender, EventArgs e)
        {
            try
            {
             
                _iModel.Change_BookName(_IView.indexBook, _IView.Text,_IView.curBook);
            }
            catch (Exception mes)
            {
                _IView.ShowErrorMessages(mes.Message);
               
            }
        }
        public void Change_Author(object sender, EventArgs e)
        {
            try
            {
                
                _iModel.Change_Author(_IView.indexAuthor, _IView.Text);
            }
            catch (Exception mes)
            {
                _IView.ShowErrorMessages(mes.Message);
               
            }
        }

        public void Add_Author(object sender, EventArgs e)
        {
           
           
             _iModel.Add_Author(_IView.Text);

        


        }
        public void ShowAllAuthor(object sender, EventArgs e)
        {
             
            _IView.WriteAllAuthors(_iModel.Show_AllAuthors());
        }
        public void ShowAllBooks(object sender, EventArgs e)
        {
       
            _IView.WriteAllBooks(_iModel.Show_All());
        }
        public void ShowAllBooks_A(object sender, EventArgs e)
        {

            _IView.WriteAllBooks(_iModel.Show_BooksA(_IView.curAuthor));
        }
        public void Add_book(object sender, EventArgs e)
        {
            try
            {

          
         
            _iModel.Add_BookName(_IView.indexAuthor,_IView.Text);


            }
            catch (Exception mes)
            {
                _IView.ShowErrorMessages(mes.Message);
                
            }

        }
        public void Delete_BookName(object sender, EventArgs e)
        {
            try
            {

               
                _iModel.Delete_BookName(_IView.indexAuthor,_IView.curBook);
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

           
                _iModel.Delete_Author(_IView.indexAuthor);
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
