using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Eticarett.ViewModels
{
    public class Uye
    {

        [Required]
        [StringLength(5)]

        public string Isim { get; set; }

        [DataType(DataType.Password)]
        public string Parola { get; set; }
        public string Test { get; set; }
        public string Soyisim { get; set; }
        public string Adres { get; set; }
        public string Eposta { get; set; }
        public string Tel { get; set; }
      
        public string GuvenlikSorusu { get; set; }
        public string GuvenlikCevabı { get; set; }
    }
}