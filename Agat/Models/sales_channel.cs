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
    
    public partial class sales_channel
    {
        public sales_channel()
        {
            this.report = new HashSet<report>();
            this.sales_channel_position = new HashSet<sales_channel_position>();
        }
    
        public int id { get; set; }
        public string full_name { get; set; }
        public string short_name { get; set; }
    
        public virtual ICollection<report> report { get; set; }
        public virtual ICollection<sales_channel_position> sales_channel_position { get; set; }
    }
}