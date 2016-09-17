using Eticarett.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eticarett.Infrastructure
{
    public class PageDataForData
    {
        public List<ViewModels.Urun> Urunler = new List<ViewModels.Urun>();

        private Entitie context = new Entitie();
        public PageDataForData(int page, int postsPerPage, bool Kampanya)
        {
            if (Kampanya)
            {
                var currentPosts = context.Kampanya.Where(p => p.BitisTarihi > DateTime.Now).OrderByDescending(p => p.BaslangıcTarihi)
                    .Skip((page - 1) * postsPerPage)
                    .Take(postsPerPage).ToList();

                foreach (var _urun in currentPosts)
                {
                    ViewModels.Urun urrun = new ViewModels.Urun();
                    Prince Fiyat = new Prince(_urun.UrunFiyat.AlisFiyati, _urun.UrunFiyat.KarOranı, _urun.UrunFiyat.KdvOrani, _urun.IndrimOranı);
                    urrun.Fiyat = Fiyat.Fiyat;
                    ImageLoad Image = new ImageLoad(_urun.UrunFiyat.UrunDetaylari.resim, _urun.UrunFiyat.UrunId, 484, 441);
                    urrun.ResimYolu = Image.ImagePath;
                    urrun.UrunId = _urun.UrunFiyat.UrunId;
                    urrun.UrunAdi = _urun.UrunFiyat.UrunDetaylari.model_cins;
                    urrun.BitisTarihi = _urun.BitisTarihi;
                    urrun.BaslamaTarihi = _urun.BaslangıcTarihi;
                    urrun.Acıklama = _urun.Acıklama;
                    Urunler.Add(urrun);

                }
            }
            else
            {
                var currentPosts = context.UrunDetaylari.OrderByDescending(p => p.urunId)
                  .Skip((page - 1) * postsPerPage)
                  .Take(postsPerPage).ToList();

                foreach (var _urun in currentPosts)
                {
                    foreach (var i in _urun.UrunFiyat)
                    {
                        if (i.Kampanya.Count == 0)
                        {
                            ViewModels.Urun urrun = new ViewModels.Urun();
                            Prince Fiyat = new Prince(i.AlisFiyati, i.KarOranı, i.KdvOrani);
                            urrun.Fiyat = Fiyat.Fiyat;
                            ImageLoad Image = new ImageLoad(i.UrunDetaylari.resim, i.UrunId, 484, 441);
                            urrun.ResimYolu = Image.ImagePath;
                            urrun.UrunId = i.UrunId;
                            urrun.UrunAdi = i.UrunDetaylari.model_cins;
                            urrun.id = i.Id;
                            Urunler.Add(urrun);
                        }
                        else
                        {
                            ViewModels.Urun urrun = new ViewModels.Urun();
                            foreach (var b in i.Kampanya)
                            {
                                Prince Fiyat = new Prince(i.AlisFiyati, i.KarOranı, i.KdvOrani, b.IndrimOranı);
                                urrun.Fiyat = Fiyat.Fiyat;
                            }
                            ImageLoad Image = new ImageLoad(i.UrunDetaylari.resim, i.UrunId, 484, 441);
                            urrun.ResimYolu = Image.ImagePath;
                            urrun.UrunId = i.UrunId;
                            urrun.UrunAdi = i.UrunDetaylari.model_cins;
                            Urunler.Add(urrun);
                        }
                    }


                }
            }
        }
        public PageDataForData(int page, int postsPerPage, int id, bool Markamı)
        {
            if (Markamı)
            {
                var currentPosts = context.UrunDetaylari.Where(x => x.Urunler.Markalar.Id == id).OrderByDescending(p => p.urunId)
                              .Skip((page - 1) * postsPerPage)
                              .Take(postsPerPage).ToList();
                foreach (var _urun in currentPosts)
                {
                    foreach (var i in _urun.UrunFiyat)
                    {
                        if (i.Kampanya.Count == 0)
                        {
                            ViewModels.Urun urrun = new ViewModels.Urun();
                            Prince Fiyat = new Prince(i.AlisFiyati, i.KarOranı, i.KdvOrani);
                            urrun.Fiyat = Fiyat.Fiyat;
                            ImageLoad Image = new ImageLoad(i.UrunDetaylari.resim, i.UrunId, 484, 441);
                            urrun.ResimYolu = Image.ImagePath;
                            urrun.UrunId = i.UrunId;
                            urrun.UrunAdi = i.UrunDetaylari.model_cins;
                            Urunler.Add(urrun);
                        }
                        else
                        {
                            ViewModels.Urun urrun = new ViewModels.Urun();
                            foreach (var b in i.Kampanya)
                            {
                                Prince Fiyat = new Prince(i.AlisFiyati, i.KarOranı, i.KdvOrani, b.IndrimOranı);
                                urrun.Fiyat = Fiyat.Fiyat;
                            }
                            ImageLoad Image = new ImageLoad(i.UrunDetaylari.resim, i.UrunId, 484, 441);
                            urrun.ResimYolu = Image.ImagePath;
                            urrun.UrunId = i.UrunId;
                            urrun.UrunAdi = i.UrunDetaylari.model_cins;
                            Urunler.Add(urrun);
                        }
                    }
                }
            }
            else
            {
                var currentPosts = context.UrunDetaylari.Where(x => x.Urunler.Katagori.Id == id).OrderByDescending(p => p.urunId)
                                 .Skip((page - 1) * postsPerPage)
                                 .Take(postsPerPage).ToList();
                foreach (var _urun in currentPosts)
                {
                    foreach (var i in _urun.UrunFiyat)
                    {
                        if (i.Kampanya.Count == 0)
                        {
                            ViewModels.Urun urrun = new ViewModels.Urun();
                            Prince Fiyat = new Prince(i.AlisFiyati, i.KarOranı, i.KdvOrani);
                            urrun.Fiyat = Fiyat.Fiyat;
                            ImageLoad Image = new ImageLoad(i.UrunDetaylari.resim, i.UrunId, 484, 441);
                            urrun.ResimYolu = Image.ImagePath;
                            urrun.UrunId = i.UrunId;
                            urrun.UrunAdi = i.UrunDetaylari.model_cins;
                            Urunler.Add(urrun);
                        }
                        else
                        {
                            ViewModels.Urun urrun = new ViewModels.Urun();
                            foreach (var b in i.Kampanya)
                            {
                                Prince Fiyat = new Prince(i.AlisFiyati, i.KarOranı, i.KdvOrani, b.IndrimOranı);
                                urrun.Fiyat = Fiyat.Fiyat;
                            }
                            ImageLoad Image = new ImageLoad(i.UrunDetaylari.resim, i.UrunId, 484, 441);
                            urrun.ResimYolu = Image.ImagePath;
                            urrun.UrunId = i.UrunId;
                            urrun.UrunAdi = i.UrunDetaylari.model_cins;
                            Urunler.Add(urrun);
                        }
                    }
                }
            }

        }
        public PageDataForData(int id)
        {
            var currentPosts = context.UrunDetaylari.Where(x => x.Id == id).FirstOrDefault();
            foreach (var i in currentPosts.UrunFiyat)
            {
                if (i.Kampanya.Count == 0)
                {
                    ViewModels.Urun urrun = new ViewModels.Urun();
                    Prince Fiyat = new Prince(i.AlisFiyati, i.KarOranı, i.KdvOrani);
                    urrun.Fiyat = Fiyat.Fiyat;
                    ImageLoad Image = new ImageLoad(i.UrunDetaylari.resim, i.UrunId, 484, 441);
                    urrun.ResimYolu = Image.ImagePath;
                    urrun.UrunId = i.UrunId;
                    urrun.UrunAdi = i.UrunDetaylari.model_cins;
                    urrun.id = i.Id;
                    Urunler.Add(urrun);
                }
                else
                {
                    ViewModels.Urun urrun = new ViewModels.Urun();
                    foreach (var b in i.Kampanya)
                    {
                        Prince Fiyat = new Prince(i.AlisFiyati, i.KarOranı, i.KdvOrani, b.IndrimOranı);
                        urrun.Fiyat = Fiyat.Fiyat;
                    }
                    ImageLoad Image = new ImageLoad(i.UrunDetaylari.resim, i.UrunId, 484, 441);
                    urrun.ResimYolu = Image.ImagePath;
                    urrun.UrunId = i.UrunId;
                    urrun.UrunAdi = i.UrunDetaylari.model_cins;
                    urrun.id = i.Id;
                    Urunler.Add(urrun);
                }
            }


        }


    }
}