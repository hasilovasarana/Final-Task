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
    
    public partial class Balance
    {
        public int balance_id { get; set; }
        public Nullable<int> balance_customer_id { get; set; }
        public string balance_amount { get; set; }
        public string balance_note { get; set; }
    
        public virtual Customer Customer { get; set; }
    }
}
