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
    
    public partial class employee
    {
        public employee()
        {
            this.employee1 = new HashSet<employee>();
            this.employee11 = new HashSet<employee>();
            this.GroupOSP = new HashSet<GroupOSP>();
            this.POS1 = new HashSet<POS>();
            this.report = new HashSet<report>();
        }
    
        public int id { get; set; }
        public string lastname { get; set; }
        public string firstname { get; set; }
        public string middlename { get; set; }
        public Nullable<System.DateTime> DOB { get; set; }
        public Nullable<System.DateTime> DOD { get; set; }
        public string email { get; set; }
        public int position_id { get; set; }
        public byte category { get; set; }
        public Nullable<int> pos_id { get; set; }
        public Nullable<int> chief_id { get; set; }
        public Nullable<int> mag_id { get; set; }
        public Nullable<int> personnel_number_id { get; set; }
        public string AspNetUsersID { get; set; }
    
        public virtual ICollection<employee> employee1 { get; set; }
        public virtual employee employee2 { get; set; }
        public virtual ICollection<employee> employee11 { get; set; }
        public virtual employee employee3 { get; set; }
        public virtual tabel tabel { get; set; }
        public virtual POS POS { get; set; }
        public virtual position position { get; set; }
        public virtual ICollection<GroupOSP> GroupOSP { get; set; }
        public virtual ICollection<POS> POS1 { get; set; }
        public virtual ICollection<report> report { get; set; }
    }
}
