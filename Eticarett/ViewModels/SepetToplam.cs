using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eticarett.ViewModels
{
    public class SepetToplam
    {
        public decimal Kdv { get; set; }
        public decimal Sepet { get; set; }
        public decimal Indirim { get; set; }
        public decimal Toplam { get; set; }
    }
}