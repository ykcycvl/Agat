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
    
    public partial class SKK
    {
        public SKK()
        {
            this.POS = new HashSet<POS>();
            this.report = new HashSet<report>();
        }
    
        public int id { get; set; }
        public int branch_id { get; set; }
        public string full_name { get; set; }
        public string short_name { get; set; }
    
        public virtual branch branch { get; set; }
        public virtual ICollection<POS> POS { get; set; }
        public virtual ICollection<report> report { get; set; }
    }
}
