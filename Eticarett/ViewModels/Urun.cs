using System.Web.Mvc;
using Eticarett.Models;
using System;
using System.Linq;
using System.Web;
using System.Collections.Generic;
using System.IO;
using Eticarett.ViewModels;
using System.Web.Helpers;
using Eticarett.Infrastructure;

namespace Eticarett.ViewModels
{
    public class Urun
    {
        public string Fiyat { get; set; }
        public string ResimYolu { get; set; }
        public string UrunAdi { get; set; }
        public int UrunId { get; set; }
    }
    public class KampanyalıUrunler
    {
        public PageData<Urun> kampanyalıUrunler { get; set; }
        public IList<ViewModels.Marka> Marka { get; set; }
        public IEnumerable<Katagori> Kategori { get; set; }
        public int Page { get; set; }
    }
    public class Urunler
    {
        public PageData<Urun> UrunlerList { get; set; }
        public IList<ViewModels.Marka> Marka { get; set; }
        public IEnumerable<Katagori> Kategori { get; set; }
        public int Page { get; set; }
        public bool  Markamı { get; set; }
        public int id { get; set; }
    }
    public class Detay
    {
        public IList<ViewModels.Marka> Marka { get; set; }
        public IEnumerable<Katagori> Kategori { get; set; }
        public OzellikDetay detay { get; set; }
        public string Fiyat { get; set; }
    }

}