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
    
    public partial class Machinery
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Machinery()
        {
            this.Farmer_Machinery_RS = new HashSet<Farmer_Machinery_RS>();
        }
    
        public int machinery_id { get; set; }
        public string machinery_type { get; set; }
        public string machine_manufacturer { get; set; }
        public Nullable<int> machinery_quantity { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Farmer_Machinery_RS> Farmer_Machinery_RS { get; set; }
    }
}
