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
    
    public partial class product
    {
        public product()
        {
            this.report_detail = new HashSet<report_detail>();
        }
    
        public int id { get; set; }
        public int product_group_id { get; set; }
        public string full_name { get; set; }
        public string short_name { get; set; }
        public int sortorder { get; set; }
    
        public virtual product_group product_group { get; set; }
        public virtual ICollection<report_detail> report_detail { get; set; }
    }
}