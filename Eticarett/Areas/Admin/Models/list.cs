using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Eticarett.Models;

namespace Eticarett.Areas.Admin.Models
{
    public class list
    {
        public class dblist
        {
            public Kampanya kampanya { get; set; }
            public Üye üye { get; set; }
            public Banka banka { get; set; }
            public Kargo kargo { get; set; }
            public Katagori katagori { get; set; }
            public Markalar markalar { get; set; }
            public OdemeSecenekleri odemeSecenekleri { get; set; }
            public OzellikDetay ozellikDetay { get; set; }
            public Resimler resimler { get; set; }
            public Roller roller { get; set; }
            public Sepet sepet { get; set; }
            public SiparisDurumu siparisDurumu { get; set; }
            public Siparisler siparisler { get; set; }
            public Taksitler taksitler { get; set; }
            public TaksitTaplosu taksitTaplosu { get; set; }
            public UrunFiyat urunFiyat { get; set; }
            public Urunler urunler { get; set; }
            public UrunOzellikler urunOzellikler { get; set; }
        }
        public class dbname
        {
            public String name { get; set; }
        }
    }
}