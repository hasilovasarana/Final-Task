//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace crm_system.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Manage_Supplier
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Manage_Supplier()
        {
            this.Supply_Management = new HashSet<Supply_Management>();
        }
    
        public int manage_supp_id { get; set; }
        public string supplier_name { get; set; }
        public string supplier_mobile { get; set; }
        public string supplier_email { get; set; }
        public string supplier_address { get; set; }
        public string supplier_product_item { get; set; }
        public Nullable<System.DateTime> supply_date { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Supply_Management> Supply_Management { get; set; }
        public virtual Report Report { get; set; }
    }
}
