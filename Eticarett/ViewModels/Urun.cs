﻿using System.Web.Mvc;
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
    public class DigerUrunler
    {
        public decimal Fiyat { get; set; }
        public string ResimYolu { get; set; }
        public string UrunAdi { get; set; }
        public int UrunId { get; set; }
    }
    public class KampanyalıUrunler
    {
        public PageData<DigerUrunler> kampanyalıUrunler { get; set; }
        public IList<ViewModels.Marka> Marka { get; set; }
        public IEnumerable<Katagori> Kategori { get; set; }
    }
   
}