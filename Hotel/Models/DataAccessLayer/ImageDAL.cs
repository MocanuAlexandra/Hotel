using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using Hotel.Models.EntityLayer;
using Hotel.DBContext;

namespace Hotel.Models.DataAccessLayer
{
    public static class ImageDAL
    {
        //given a path for image, transform it to byte array
        public static byte[] GetImagetoByteArray(string path)
            
        {           
            byte[] b = null;
            if (File.Exists(path))
            {
                b = File.ReadAllBytes(path);            
            }
            return b;
        }

        //given a byte array, tranform it to image
        public static Image ByteArrayToImage(byte[] byteArrayIn)
        {
            using (var ms = new MemoryStream(byteArrayIn))
            {
                var returnImage = Image.FromStream(ms);

                return returnImage;
            }
        }

        // given a byte array, create a new image entity and the save it to database
        public static void SaveImageToDB(byte[] image, string imageName)
        {
            var imageEntity = new RoomImage()
            {
                Name = imageName,              
                Content = image,
                IsActive = true
            };

            using (var context = new HotelDBContext())
            {
                context.Images.Add(imageEntity);
                context.SaveChanges();
            }
        }

    }
}
