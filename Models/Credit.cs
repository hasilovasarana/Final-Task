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
    
    public partial class Credit
    {
        public int credit_id { get; set; }
        public Nullable<int> credit_bank_acc_id { get; set; }
        public Nullable<int> credit_amount { get; set; }
    
        public virtual Bank_Account Bank_Account { get; set; }
    }
}
