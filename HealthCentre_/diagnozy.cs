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
    
    public partial class diagnozy
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public diagnozy()
        {
            this.medykamenty_zalecone = new HashSet<medykamenty_zalecone>();
        }
    
        public long id_diagnozy { get; set; }
        public string id_choroby { get; set; }
        public long id_porady { get; set; }
    
        public virtual choroby choroby { get; set; }
        public virtual porady_lekarskie porady_lekarskie { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<medykamenty_zalecone> medykamenty_zalecone { get; set; }
    }
}
