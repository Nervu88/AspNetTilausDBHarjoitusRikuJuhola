//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AspNetTilausDB
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tuotteet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tuotteet()
        {
            this.Tilausrivits = new HashSet<Tilausrivit>();
        }
    
        public int TuoteID { get; set; }
        public string Nimi { get; set; }
        public Nullable<decimal> Ahinta { get; set; }
        public string ImageLink { get; set; }
        public Nullable<short> VarastoSaldo { get; set; }
        public string AlkuperaMaa { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tilausrivit> Tilausrivits { get; set; }
        public virtual Region Region { get; set; }
    }
}
