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
    
    public partial class SiparisDurumu
    {
        public SiparisDurumu()
        {
            this.Siparisler = new HashSet<Siparisler>();
        }
    
        public int Id { get; set; }
        public string Durum { get; set; }
    
        public virtual ICollection<Siparisler> Siparisler { get; set; }
    }
}
