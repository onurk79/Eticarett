using Eticarett.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eticarett.ViewModels
{
    public class Lists
    {
        public class MarkaKategori
        {
            public IList<ViewModels.Marka> Marka{ get; set; }
            public IEnumerable< Katagori> Kategori { get; set; }
            public IList<Urunler> Urunler { get; set; }
        } 
    }
}