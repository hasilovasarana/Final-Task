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
    
    public partial class Manage_Project
    {
        public int manage_project_id { get; set; }
        public int manage_proj_project_id { get; set; }
    
        public virtual Project Project { get; set; }
    }
}
