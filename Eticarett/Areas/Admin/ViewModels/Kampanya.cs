using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eticarett.Areas.Admin.ViewModels
{
    public class Kampanya
    {
        public int MarkaId { get; set; }
        public int KategoriId { get; set; }
        public int UrunId { get; set; }
        public int IndirimOranı { get; set; }
        public DateTime BaslangicTarihi { get; set; }
        public DateTime BitisTarihi { get; set; }
        public string Aciklama { get; set; }
        public int Id { get; set; }
    }
}