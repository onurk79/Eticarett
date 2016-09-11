using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eticarett.ViewModels
{
    public class Sepet
    {
        public int Id { get; set; }
        public int Adet { get; set; }
        public string UrunAdi { get; set; }
        public string ResimYolu { get; set; }
        public string Fiyat { get; set; }
        public decimal Kdv { get; set; }
        public decimal Indirim { get; set; }
        public decimal Sepett { get; set; }
        public string ToplamFiyat { get; set; }
    }
}