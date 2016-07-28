using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.WebPages.Html;

namespace Agat.Models
{
    public class BranchViewModel
    {
        private agatEntities db = new agatEntities();
        public List<branch> branches = new List<branch>();

        [Display(Name="ID")]
        public int id { get; set; }
        [Display(Name = "Полное наименование")]
        [Required]
        public string FullName { get; set; }
        [Display(Name = "Краткое наименование")]
        [Required]
        public string ShortName { get; set; }

        public void GetList()
        {
            branches = db.branch.ToList();
        }
        public bool Get(int id)
        {
            var b = db.branch.First(p => p.id == id);

            if (b != null)
            {
                this.id = b.id;
                this.FullName = b.full_name;
                this.ShortName = b.short_name;
                return true;
            }
            else
                return false;
        }
        public void AddBranch()
        {
            db.AddBranch(FullName, ShortName);
        }
        public void EditBranch()
        {
            db.EditBranch(id, FullName, ShortName);
        }
    }
    public class SKKViewModel
    {
        private agatEntities db = new agatEntities();
        public List<SKK> skks = new List<SKK>();
        private List<SelectListItem> _Branches = new List<SelectListItem>();
        [Display(Name = "Код СКК")]
        [Required]
        public int id { get; set; }
        [Display(Name = "Филиал")]
        [Required]
        public int BranchID { get; set; }
        [Display(Name="Филиал")]
        [Required]
        public List<SelectListItem> Branches
        {
            get { return _Branches; }
        }
        [Display(Name = "Полное наименование")]
        [Required]
        public string FullName { get; set; }
        [Display(Name = "Краткое наименование")]
        [Required]
        public string ShortName { get; set; }
        public SKKViewModel()
        {
            var branches = db.branch.ToList();

            foreach (var b in branches)
            {
                SelectListItem sli = new SelectListItem();
                sli.Value = b.id.ToString();
                sli.Text = b.short_name;
                _Branches.Add(sli);
            }
        }
        public bool Get(int id)
        {
            var SKK = db.SKK.First(p => p.id == id);

            if (SKK == null)
                return false;

            this.id = SKK.id;
            this.BranchID = SKK.branch_id;
            this.FullName = SKK.full_name;
            this.ShortName = SKK.short_name;
            return true;
        }
        public void GetList()
        {
            skks = db.SKK.ToList();
        }
        public void AddSKK()
        {
            db.AddSKK(id, BranchID, FullName, ShortName);
        }
        public void EditSKK()
        {
            db.EditSKK(id, BranchID, FullName, ShortName);
        }
    }
    public class OSPGroupViewModel
    {
        private agatEntities db = new agatEntities();
        public List<GroupOSP> ospgroups = new List<GroupOSP>();
        private List<SelectListItem> _Employees = new List<SelectListItem>();
        [Display(Name="ID")]
        public int id { get; set; }
        [Display(Name = "Название группы ОСП")]
        [Required]
        public string name { get; set; }
        [Display(Name = "Руководитель")]
        [Required]
        public int chief_id { get; set; }
        [Display(Name = "Руководитель")]
        public List<SelectListItem> Employees
        {
            get { return _Employees; }
        }
        public OSPGroupViewModel()
        {
            var employees = db.employee.ToList();

            foreach (var e in employees)
            {
                SelectListItem sli = new SelectListItem();
                sli.Value = e.id.ToString();
                sli.Text = (e.lastname + " " + e.firstname + " " + e.middlename).Trim();
                _Employees.Add(sli);
            }
        }
        public bool Get(int id)
        {
            var GOSP = db.GroupOSP.First(p => p.id == id);

            if (GOSP == null)
                return false;

            this.id = GOSP.id;
            this.name = GOSP.name;
            this.chief_id = GOSP.chief_id;
            return true;
        }
        public void GetList()
        {
            ospgroups = db.GroupOSP.ToList();
        }
        public void AddOSPGroup()
        {
            db.AddGroupOSP(name, chief_id);
        }
        public void EditOSPGroup()
        {
            db.EditGroupOSP(id, name, chief_id);
        }
    }
    public class POSViewModel
    {
        private agatEntities db = new agatEntities();
        public List<POS> poses = new List<POS>();
        public List<SelectListItem> _SKKS = new List<SelectListItem>();
        public List<SelectListItem> _OSPGroups = new List<SelectListItem>();
        public List<SelectListItem> _Employees = new List<SelectListItem>();

        public List<SelectListItem> SKKS
        {
            get { return _SKKS; }
        }
        public List<SelectListItem> OSPGroups
        {
            get { return _OSPGroups; }
        }
        public List<SelectListItem> Employees
        {
            get { return _Employees; }
        }

        [Display(Name="ID")]
        public int id { get; set; }
        [Display(Name = "Название")]
        [Required]
        public string name { get; set; }
        [Display(Name = "СКК")]
        [Required]
        public int SKKID { get; set; }
        [Display(Name = "Адрес")]
        [Required]
        public string address { get; set; }
        [Display(Name = "Телефон")]
        [Required]
        public string phone { get; set; }
        [Display(Name = "Группа ОСП")]
        [Required]
        public int GroupID { get; set; }
        [Display(Name = "Руководитель")]
        [Required]
        public int chief_id { get; set; }

        public POSViewModel()
        {
            var skks = db.SKK.ToList();

            foreach (var s in skks)
            {
                SelectListItem sli = new SelectListItem();
                sli.Value = s.id.ToString();
                sli.Text = s.id.ToString() + " - " + s.short_name;
                _SKKS.Add(sli);
            }
            var ospgroups = db.GroupOSP.ToList();

            foreach (var o in ospgroups)
            {
                SelectListItem sli = new SelectListItem();
                sli.Value = o.id.ToString();
                sli.Text = o.name;
                _OSPGroups.Add(sli);
            }
            var employees = db.employee.ToList();

            foreach (var e in employees)
            {
                SelectListItem sli = new SelectListItem();
                sli.Value = e.id.ToString();
                sli.Text = (e.lastname + " " + e.firstname + " " + e.middlename).Trim();
                _Employees.Add(sli);
            }
        }
        public bool Get(int id)
        {
            var pos = db.POS.First(p => p.id == id);

            if (pos == null)
                return false;

            this.id = pos.id;
            this.name = pos.name;
            this.SKKID = pos.SKK_id;
            this.address = pos.address;
            this.phone = pos.phone;
            this.GroupID = pos.group_id;
            this.chief_id = pos.chief_id;

            var s = _SKKS.First(p => p.Value == this.SKKID.ToString());

            if (s != null)
                s.Selected = true;

            var g = _OSPGroups.First(p => p.Value == this.GroupID.ToString());

            if (s != null)
                g.Selected = true;

            var e = _Employees.First(p => p.Value == this.chief_id.ToString());

            if (e != null)
                e.Selected = true;

            return true;
        }
        public void GetList()
        {
            poses = db.POS.ToList();
        }
        public void AddPOS()
        {
            db.AddPOS(name, SKKID, address, phone, GroupID, chief_id);
        }
        public void EditPOS()
        {
            db.EditPOS(id, name, SKKID, address, phone, GroupID, chief_id);
        }
    }
}