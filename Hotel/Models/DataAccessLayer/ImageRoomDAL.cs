using Hotel.DBContext;
using Hotel.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Hotel.Models.DataAccessLayer
{
    public class ImageRoomDAL
    {
        // adds image to database, dont modify roomtypes 

        public static void AddImage(ImageRoom image, RoomType roomType)
        {
            image.RoomType = roomType;
            using (var context = new HotelDBContext())
            {
                context.RoomTypes.Attach(roomType);
                context.Images.Add(image);
                context.SaveChanges();
            }
        }


        // gets all images from database into observable collection
        // includes room types      
        public static ObservableCollection<ImageRoom> GetAllImages()
        {
            using (var context = new HotelDBContext())
            {
                var images = context.Images.
                    Include(rt => rt.RoomType)
                    .ToList();
                return new ObservableCollection<ImageRoom>(images);
            }
        }

        // deletes a image from database
        public static void DeleteImage(ImageRoom image)
        {
            using (var context = new HotelDBContext())
            {
                context.Images.Attach(image);
                context.Images.Remove(image);
                context.SaveChanges();
            }
        }


    }
}
