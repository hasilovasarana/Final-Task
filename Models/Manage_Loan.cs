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
    
    public partial class Manage_Loan
    {
        public int manage_loan_id { get; set; }
        public Nullable<int> manage_loan_personal_loan_id { get; set; }
    
        public virtual Personal_Loan Personal_Loan { get; set; }
    }
}
