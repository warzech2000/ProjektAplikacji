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
    
    public partial class sprzedaz_sklepy
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public sprzedaz_sklepy()
        {
            this.magazyn_lista = new HashSet<magazyn_lista>();
            this.sprzedaz_pracownicy = new HashSet<sprzedaz_pracownicy>();
            this.sprzedaz_zamowienia = new HashSet<sprzedaz_zamowienia>();
        }
    
        public int sklep_id { get; set; }
        public string sklep_nazwa { get; set; }
        public string telefon { get; set; }
        public string email { get; set; }
        public string ulica { get; set; }
        public string miasto { get; set; }
        public string kod_pocztowy { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<magazyn_lista> magazyn_lista { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<sprzedaz_pracownicy> sprzedaz_pracownicy { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<sprzedaz_zamowienia> sprzedaz_zamowienia { get; set; }
    }
}
