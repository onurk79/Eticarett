using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Helpers;

namespace Eticarett.ViewModels
{
    public class Marka
    {
        public int Id { get; set; }
        public string MarkaAdi { get; set; }
        public string MarkaAcıklmasi { get; set; }
        public byte[] MarkaLogo { get; set; }
        public WebImage Image { get; set; }
        public string imagePath { get; set; }
    }
}