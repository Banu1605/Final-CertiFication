//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FinalCertification.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class User
    {
        public string User_ID { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public Nullable<int> Employee_ID { get; set; }
        public string Project_ID { get; set; }
        public string Task_ID { get; set; }
    
        public virtual Project Project { get; set; }
        public virtual Task Task { get; set; }
    }
}