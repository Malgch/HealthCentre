//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HealthCentre_
{
    using System;
    using System.Collections.Generic;
    
    public partial class porady_lekarskie
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public porady_lekarskie()
        {
            this.diagnozy = new HashSet<diagnozy>();
        }
    
        public long id_porady { get; set; }
        public long id_lekarzaS { get; set; }
        public long id_pacjenta { get; set; }
        public System.DateTime data { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<diagnozy> diagnozy { get; set; }
        public virtual lekarze_specjalisci lekarze_specjalisci { get; set; }
        public virtual pacjenci pacjenci { get; set; }
    }
}