//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Eticarett.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Katagori
    {
        public Katagori()
        {
            this.Urunler = new HashSet<Urunler>();
        }
    
        public int Id { get; set; }
        public string KategoriAdi { get; set; }
    
        public virtual ICollection<Urunler> Urunler { get; set; }
    }
}