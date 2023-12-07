using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Final_Gallery.Data
{
    [DataContract]
    public class Album
    {
        [DataMember]
        public List<Photo> Photos { get; set; } 
        public Album() { 
        

            Photos = new List<Photo>();

            PhotoManager.MakeExamples(Photos);
        }
    }
    [Serializable]
    public class Photo
    {
        public string FileName { get; set; }
        public string PhotoOwner { get; set; }
        public string PhotoDescription { get; set; }
        public int PhotoRating { get; set; }
        public double PhotoScale { get; set; }
        public string ImagePath { get; set; }
    }
    static internal class PhotoManager
    {
      

        static public BitmapImage LoadPhoto(Photo photo)
        {
            if (photo.ImagePath != null)
            {
                return new BitmapImage(new Uri(photo.ImagePath));
            }
            else
            {
                return null;
            }

            
        }


        static public void AddPhoto(string uri,string fname, List<Photo> photo)
        {

            var p = new Photo
            {
                FileName = fname,
                PhotoOwner = "",
                PhotoDescription = "",
                PhotoRating = 1,
                PhotoScale = 1,
                ImagePath = uri
            };
            photo.Add(p);
        }

        static public void DeletePhoto(int index,List<Photo> photo)
        {

           
            photo.RemoveAt(index);
        }

        static public void MakeExamples(List<Photo>photo)
        {
         
            var p1 = new Photo
            {
                FileName = "1.jpg",
                PhotoOwner = "John Doe",
                PhotoDescription = "Beautiful landscape",
                PhotoRating = 0,
                ImagePath = "D:\\1STEP\\Final_Gallery\\Images\\1.jpg"
            };
            var p2 = new Photo
            {
                FileName = "2.jpg",
                PhotoOwner = "John Doe",
                PhotoDescription = "Beautiful landscape",
                PhotoRating = 4,
                ImagePath = "D:\\1STEP\\Final_Gallery\\Images\\2.jpg"
            };
            var p3 = new Photo
            {
                FileName = "3.jpg",
                PhotoOwner = "John Doe",
                PhotoDescription = "Beautiful asd",
                PhotoRating = 4,
                ImagePath = "D:\\1STEP\\Final_Gallery\\Images\\3.jpg"
            };


            var p4 = new Photo
            {
                FileName = "4.jpg",
                PhotoOwner = "babaa baba",
                PhotoDescription = "b landscape",
                PhotoRating = 2,
                ImagePath = "D:\\1STEP\\Final_Gallery\\Images\\4.jpg"
            };
            var p5 = new Photo
            {
                FileName = "5.jpg",
                PhotoOwner = "asda Dodaasde",
                PhotoDescription = "Beautiful landscape",
                PhotoRating = 4,
                ImagePath = "D:\\1STEP\\Final_Gallery\\Images\\5.jpg"
            };

            var p6 = new Photo
            {
                FileName = "6.jpg",
                PhotoOwner = "John sad",
                PhotoDescription = "Beautiful landscape",
                PhotoRating = 1,
                ImagePath = "D:\\1STEP\\Final_Gallery\\Images\\6.jpg"
            };

            var p7 = new Photo
            {
                FileName = "7.jpg",
                PhotoOwner = "aa Doe",
                PhotoDescription = "dsadas",
                PhotoRating = 3,
                ImagePath = "D:\\1STEP\\Final_Gallery\\Images\\7.jpg"
            };






            photo.Add(p1);
            photo.Add(p2);
            photo.Add(p3);
            photo.Add(p4);
            photo.Add(p5);
            photo.Add(p6);
            photo.Add(p7);

        }



    }
}
