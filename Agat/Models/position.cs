//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Agat.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class position
    {
        public position()
        {
            this.employee = new HashSet<employee>();
            this.sales_channel_position = new HashSet<sales_channel_position>();
        }
    
        public int id { get; set; }
        public string name { get; set; }
    
        public virtual ICollection<employee> employee { get; set; }
        public virtual ICollection<sales_channel_position> sales_channel_position { get; set; }
    }
}