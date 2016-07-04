using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Eticarett.Models;

namespace Eticarett.Areas.Admin.Models
{
    public class list
    {
        public String Kategori { get; set; }
        public int KategoriId { get; set; }
        public String Marka { get; set; }
        public int MarkaId { get; set; }
    }
}