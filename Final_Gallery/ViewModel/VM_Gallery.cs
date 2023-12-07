using Final_Gallery.Commands;
using Final_Gallery.Data;
using Final_Gallery.Model_Login;
using MaterialDesignThemes.Wpf;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Final_Gallery.ViewModel
{
    internal class VM_Gallery : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private int index;

        public int Index
        {
            get { return index; }
            set
            {
                index = value;
                OnPropertyChanged(nameof(Index));
                OnPropertyChanged(nameof(PhotoFileName));
                OnPropertyChanged(nameof(PhotoOwner));
                OnPropertyChanged(nameof(PhotoDescription));
                OnPropertyChanged(nameof(CurrentPhoto));
                OnPropertyChanged(nameof(PhotoRating));
                OnPropertyChanged(nameof(PhotoScale));
            }
        }

        private Album photo;
        public string PhotoFileName
        {
            get
            {
                if (photo != null && photo.Photos != null && index < photo.Photos.Count)
                {
                    return photo.Photos[index].FileName;
                }
                else
                {
                    return "";
                }
            }
            set
            {
                if (photo != null && photo.Photos != null && index < photo.Photos.Count)
                {
                    photo.Photos[index].FileName = value;
                    OnPropertyChanged(nameof(PhotoFileName));
                }
            }
        }

        public string PhotoOwner
        {
            get
            {
                if (photo != null && photo.Photos != null && index < photo.Photos.Count)
                {
                    return photo.Photos[index].PhotoOwner;
                }
                else
                {
                    return "";
                }
            }
            set
            {
                if (photo != null && photo.Photos != null && index < photo.Photos.Count)
                {
                    photo.Photos[index].PhotoOwner = value;
                    OnPropertyChanged(nameof(PhotoOwner));
                }
            }
        }

        public string PhotoDescription
        {
            get
            {
                if (photo != null && photo.Photos != null && index < photo.Photos.Count)
                {
                    return photo.Photos[index].PhotoDescription;
                }
                else
                {
                    return "";
                }
            }
            set
            {
                if (photo != null && photo.Photos != null && index < photo.Photos.Count)
                {
                    photo.Photos[index].PhotoDescription = value;
                    OnPropertyChanged(nameof(PhotoDescription));
                }
            }
        }

        public double PhotoScale
        {
            get
            {
                if (photo != null && photo.Photos != null && index < photo.Photos.Count)
                {
                    if (photo.Photos[index].PhotoScale == 0)
                    {
                        return 0.07;
                    }
                    else
                    {
                        return photo.Photos[index].PhotoScale;
                    }
                }
                else
                {
                    return 1;
                }
            }
            set
            {
                if (photo != null && photo.Photos != null && index < photo.Photos.Count)
                {
                    photo.Photos[index].PhotoScale = value;
                    OnPropertyChanged(nameof(PhotoScale));
                }
            }
        }

        public int PhotoRating
        {
            get
            {
                if (photo != null && photo.Photos != null && index < photo.Photos.Count)
                {
                    return photo.Photos[index].PhotoRating;
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                if (photo != null && photo.Photos != null && index < photo.Photos.Count)
                {
                    photo.Photos[index].PhotoRating = value;
                    OnPropertyChanged(nameof(PhotoRating));
                }
            }
        }



        public BitmapImage CurrentPhoto
        {
            get {

                if (photo.Photos != null && index < photo.Photos.Count)
                {
                    return PhotoManager.LoadPhoto(photo.Photos[Index]);
                }
                else
                {
                    return null;
                }
            
            }
            set
            {
                OnPropertyChanged(nameof(CurrentPhoto));
            }
        }

        public void SaveAlbum()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Album Files (*.album)|*.album|All Files (*.*)|*.*";
            bool? result = saveFileDialog.ShowDialog();

            if (result.HasValue && result.Value)
            {
                FileManager.SaveAlbum(saveFileDialog.FileName, photo);
            }
        }

        private void AddPhoto()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JPG Files (*.jpg)|*.jpg|All Files (*.*)|*.*";
            openFileDialog.ShowDialog();
            PhotoManager.AddPhoto(openFileDialog.FileName,openFileDialog.SafeFileName,photo.Photos);
            index++;
        }
        private void LoadAlbum()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Album Files (*.album)|*.album|All Files (*.*)|*.*";
            openFileDialog.ShowDialog();
            photo=FileManager.LoadAlbum(openFileDialog.FileName);
            Index = 0;
        }

        private void ExitProg()
        {

            var result = MessageBox.Show("Есть не сохранённые изменения, Сохранить?", "Warning", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                SaveAlbum();
                App.Current.Shutdown();
                
            }
            else
            {
                App.Current.Shutdown();
            }

          
        }



        private Command Next;
        private Command Prev;


        private Command Save;
        private Command Add;
        private Command Exit;
        private Command Load;
        private Command Del;

        private Command NewAlbum;
        public ICommand NewAlbumCommand
        {
            get { return NewAlbum; }
        }
        private void New()
        {

            var result = MessageBox.Show("Вы уверены?", "Warning", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
              
                photo.Photos.Clear();
                Index = 0;

            }
            else
            {
                
            }


        }

        private void Delete()
        {

            var result = MessageBox.Show("Вы точно хотите удалить?", "WARNING", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                PhotoManager.DeletePhoto(index, photo.Photos);
                Index = Index;
            }
           
        }
        public ICommand DelCommand
        {
            get { return Del; }
        }
        public ICommand ExitCommand
        {
            get{return Exit;}
        }
        public ICommand SaveCommand
        {
            get { return Save; }
        }
        public ICommand AddCommand
        {
            get { return Add; }
        }


        public ICommand LoadCommand
        {
            get { return Load; }
        }

        private bool Can()
        {
                return true;
        }



        

        public ICommand NextCommand
        {
            get
            {

                return Next;


            }
        }
        public ICommand PrevCommand
        {
            get
            {

                return Prev;


            }
        }
        private bool CanNext()
        {
            if (photo.Photos.Count > 0){
                if (Index < photo.Photos.Count - 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        private bool CanPrev()
        {
            if (Index > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool CanDel()
        {
            if (Index >= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void NextPhoto()
        {


            Index++;
            
            
        }
        public void PrevPhoto()
        {
            Index--;
        }

        public VM_Gallery()
        {
            Next = new Command(param => NextPhoto(), param => CanNext());
            Prev = new Command(param => PrevPhoto(), param => CanPrev());
            Add = new Command(param => AddPhoto(), param => Can());
            Save = new Command(param => SaveAlbum(), param => Can());
            Load = new Command(param => LoadAlbum(), param => Can());
            Exit = new Command(param => ExitProg(), param => Can());


            Del = new Command(param => Delete(), param => CanDel());
            NewAlbum = new Command(param => New(), param => Can());



            photo = new Album();
        }

    }
}
