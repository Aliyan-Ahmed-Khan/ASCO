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
    
    public partial class Tool
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tool()
        {
            this.Farmer_Tool_RS = new HashSet<Farmer_Tool_RS>();
        }
    
        public int tool_id { get; set; }
        public string tool_name { get; set; }
        public string tool_manufacturer { get; set; }
        public Nullable<int> tool_quantity { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Farmer_Tool_RS> Farmer_Tool_RS { get; set; }
    }
}