using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eticarett.Infrastructure
{
    public class Prince
    {
        public string Fiyat { get; set; }
        public decimal Kdv { get; set; }
        public decimal Indirim { get; set; }
        public Prince(decimal alıs, float karOranı, float kdvOranı, float indirimOranı)
        {
            decimal kar = alıs * Convert.ToDecimal(karOranı) / 100;
            Kdv = (kar + alıs) * Convert.ToDecimal(kdvOranı) / 100;
            decimal fiyat = kar + Kdv + alıs;
            Indirim = fiyat * Convert.ToDecimal(indirimOranı) / 100;
            Fiyat = string.Format("{0:0,0.00}", fiyat - Indirim);

        }
        public Prince(decimal alıs, float karOranı, float kdvOranı)
        {
            decimal kar = alıs * Convert.ToDecimal(karOranı) / 100;
            Kdv = (kar + alıs) * Convert.ToDecimal(kdvOranı) / 100;
            Fiyat = string.Format("{0:0,0.00}", (kar + Kdv + alıs));
        }


    }
}