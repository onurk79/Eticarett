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
    
    public partial class Banka
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Banka()
        {
            this.Taksitler = new HashSet<Taksitler>();
        }
    
        public int Id { get; set; }
        public string BankaAdi { get; set; }
        public byte[] Bankalogo { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Taksitler> Taksitler { get; set; }
    }
}
