//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjektAplikacji
{
    using System;
    using System.Collections.Generic;
    
    public partial class magazyn_kategorie
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public magazyn_kategorie()
        {
            this.magazyn_produkty = new HashSet<magazyn_produkty>();
        }
    
        public int kategoria_id { get; set; }
        public string kategoria_nazwa { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<magazyn_produkty> magazyn_produkty { get; set; }
    }
}
