//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ASCO.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Fertilizer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Fertilizer()
        {
            this.Farmer_Fertilizer_RS = new HashSet<Farmer_Fertilizer_RS>();
        }
    
        public int fertilizer_id { get; set; }
        public string fertilizer_name { get; set; }
        public string fertilizer_company { get; set; }
        public string fertilizer_quality { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Farmer_Fertilizer_RS> Farmer_Fertilizer_RS { get; set; }
    }
}
