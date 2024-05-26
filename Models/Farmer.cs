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
    using System.ComponentModel.DataAnnotations;

    public partial class Farmer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Farmer()
        {
            this.Farmer_Fertilizer_RS = new HashSet<Farmer_Fertilizer_RS>();
            this.Farmer_Loan_RS = new HashSet<Farmer_Loan_RS>();
            this.Farmer_Machinery_RS = new HashSet<Farmer_Machinery_RS>();
            this.Farmer_Seed_RS = new HashSet<Farmer_Seed_RS>();
            this.Farmer_Tool_RS = new HashSet<Farmer_Tool_RS>();
        }
    
        public int farmer_id { get; set; }

        [Required(ErrorMessage = "Username cannot be empty")]
        [Display(Name = "Username")]
        public string farmer_name { get; set; }
        public string farmer_address { get; set; }
        public string farmer_contact { get; set; }

        [Required(ErrorMessage = "This field cannot be empty")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string farmer_password { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Farmer_Fertilizer_RS> Farmer_Fertilizer_RS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Farmer_Loan_RS> Farmer_Loan_RS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Farmer_Machinery_RS> Farmer_Machinery_RS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Farmer_Seed_RS> Farmer_Seed_RS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Farmer_Tool_RS> Farmer_Tool_RS { get; set; }
    }
}
