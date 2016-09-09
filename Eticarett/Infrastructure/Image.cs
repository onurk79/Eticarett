using System.IO;
using System.Web;
using System.Web.Helpers;

namespace Eticarett.Infrastructure
{
    public class ImageLoad
    {

        public string ImagePath { get; set; }
        public ImageLoad(byte[] images, int ıd, int width, int height)
        {
            MemoryStream ms = new MemoryStream(images, 0, images.Length);
            ms.Write(images, 0, images.Length);
            WebImage image = new WebImage(ms);
            image.Resize(width, height, false);
            var upload = "~\\images\\Database\\" + ıd + width + height;
            image.Save(upload);
            ImagePath = "/images/Database/" + ıd + width + height + "." + image.ImageFormat;


        }
        public ImageLoad(byte[] images, int ıd)
        {
            MemoryStream ms = new MemoryStream(images, 0, images.Length);
            ms.Write(images, 0, images.Length);
            WebImage image = new WebImage(ms);
        
            var upload = "~\\images\\Database\\" + ıd ;
            image.Save(upload);
            ImagePath = "/images/Database/" + ıd  + "." + image.ImageFormat;


        }
    }

    public class ImageSave
    {
        public byte[] Image { get; set; }
        public ImageSave(HttpPostedFileBase fileUploader)
        {
            string fileName = string.Empty;
            string destinationPath = string.Empty;
            fileName = Path.GetFileName(fileUploader.FileName);
            BinaryReader br = new BinaryReader(fileUploader.InputStream);
            Image = br.ReadBytes((int)fileUploader.InputStream.Length);

        }
    }
}