using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Eticarett.ViewModels
{
    public class Uye
    {     
        public string Isim { get; set; }
        public string Parola { get; set; }
        public string ParolaTekrar { get; set; }
        public string Test { get; set; }
        public string Soyisim { get; set; }
        public string Adres { get; set; }
        public string Eposta { get; set; }
        public string Tel { get; set; }
        public string GuvenlikSorusu { get; set; }
        public string GuvenlikCevabı { get; set; }
    }
}