//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Eticarett.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class UrunDetaylari
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UrunDetaylari()
        {
            this.OzellikDetay = new HashSet<OzellikDetay>();
            this.Sepet = new HashSet<Sepet>();
            this.Siparisler = new HashSet<Siparisler>();
            this.Taksitler = new HashSet<Taksitler>();
            this.UrunFiyat = new HashSet<UrunFiyat>();
        }
    
        public int Id { get; set; }
        public Nullable<int> urunId { get; set; }
        public string renk { get; set; }
        public Nullable<int> stokSayisi { get; set; }
        public byte[] resim { get; set; }
        public string model_cins { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OzellikDetay> OzellikDetay { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sepet> Sepet { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Siparisler> Siparisler { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Taksitler> Taksitler { get; set; }
        public virtual Urunler Urunler { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UrunFiyat> UrunFiyat { get; set; }
    }
}