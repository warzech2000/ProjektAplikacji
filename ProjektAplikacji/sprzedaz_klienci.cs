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
    
    public partial class sprzedaz_klienci
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public sprzedaz_klienci()
        {
            this.sprzedaz_zamowienia = new HashSet<sprzedaz_zamowienia>();
        }
    
        public int klient_id { get; set; }
        public string imie { get; set; }
        public string nazwisko { get; set; }
        public string telefon { get; set; }
        public string email { get; set; }
        public string ulica { get; set; }
        public string miasto { get; set; }
        public string kod_pocztowy { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<sprzedaz_zamowienia> sprzedaz_zamowienia { get; set; }
    }
}
