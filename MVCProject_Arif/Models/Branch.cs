//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVCProject_Arif.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Branch
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Branch()
        {
            this.AccountHolders = new HashSet<AccountHolder>();
            this.Loans = new HashSet<Loan>();
        }
    
        public int BranchID { get; set; }

        [Required(ErrorMessage ="This Field Is Required")]
        [Display(Name ="Branch Name")]
        public string BranchName { get; set; }

        [Required(ErrorMessage = "This Field Is Required")]
        public string City { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AccountHolder> AccountHolders { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Loan> Loans { get; set; }
    }
}