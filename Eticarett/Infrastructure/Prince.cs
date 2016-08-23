using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eticarett.Infrastructure
{
    public class Prince
    {
        public decimal Fiyat { get; set; }
        public Prince(decimal alıs, float karOranı, float kdvOranı, float indirimOranı)
        {

            decimal kar = alıs * Convert.ToDecimal(karOranı) / 100;
            decimal kdv = (kar + alıs) * Convert.ToDecimal(kdvOranı) / 100;
            decimal fiyat = kar + kdv + alıs;
            decimal indirim = fiyat * Convert.ToDecimal(indirimOranı) / 100;
            Fiyat = fiyat - indirim;
        }

        public Prince(decimal alıs, float karOranı, float kdvOranı)
        {

            decimal kar = alıs * Convert.ToDecimal(karOranı) / 100;
            decimal kdv = (kar + alıs) * Convert.ToDecimal(kdvOranı) / 100;
            Fiyat = kar + kdv + alıs;



        }
    }
}