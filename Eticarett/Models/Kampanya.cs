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
    
    public partial class Kampanya
    {
        public int Id { get; set; }
        public int UrunId { get; set; }
        public float IndrimOranı { get; set; }
        public System.DateTime BaslangıcTarihi { get; set; }
        public System.DateTime BitisTarihi { get; set; }
        public string Acıklama { get; set; }
    
        public virtual Urunler Urunler { get; set; }
    }
}
