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
    
    public partial class Knowledge
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Knowledge()
        {
            this.Manage_Knowledge = new HashSet<Manage_Knowledge>();
        }
    
        public int knowledge_id { get; set; }
        public Nullable<int> knowledge_blog_cat_id { get; set; }
        public string knowledge_title { get; set; }
        public string knowledge_detail { get; set; }
        public Nullable<System.DateTime> knowledge_date { get; set; }
    
        public virtual Blog_Category Blog_Category { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Manage_Knowledge> Manage_Knowledge { get; set; }
    }
}
