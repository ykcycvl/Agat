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
    
    public partial class report_detail
    {
        public long id { get; set; }
        public int report_id { get; set; }
        public int product_id { get; set; }
        public decimal new_amt { get; set; }
        public decimal new_sum { get; set; }
        public int old_amt { get; set; }
        public decimal old_sum { get; set; }
    
        public virtual product product { get; set; }
        public virtual report report { get; set; }
    }
}
