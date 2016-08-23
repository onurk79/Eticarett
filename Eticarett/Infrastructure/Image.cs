using System.IO;
using System.Web.Helpers;

namespace Eticarett.Infrastructure
{
    public class Image
    {
        public string ImagePath { get; set; }
        public  Image(byte[]images, int ıd, int width, int height)
        {
            MemoryStream ms = new MemoryStream(images, 0,images.Length);
            ms.Write(images, 0,images.Length);
            WebImage image = new WebImage(ms);
            image.Resize(width, height, false);
            var upload = "~\\images\\Database\\" + ıd + width + height;
            image.Save(upload);
            ImagePath=  "/images/Database/" + ıd + width + height + "." + image.ImageFormat;
           
             
        }
    }
}