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
    
    public partial class Expence_Transaction
    {
        public int transaction_id { get; set; }
        public Nullable<int> transac_bank_acc_id { get; set; }
        public Nullable<int> transaction_amount { get; set; }
        public string purpose_note { get; set; }
        public Nullable<System.DateTime> purpose_date { get; set; }
    
        public virtual Bank_Account Bank_Account { get; set; }
    }
}
