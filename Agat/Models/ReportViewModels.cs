using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.WebPages.Html;

namespace Agat.Models
{
    public class ReportViewModel
    {
        private agatEntities db = new agatEntities();
        public List<report> reports = new List<report>();
        public void GetList()
        {
            reports = db.report.ToList();
        }
    }

    public class AddReportViewModel
    {
        private string _AspNetUserID;
        public string AspNetUserID
        {
            get {
                return _AspNetUserID;
            }
            set {
                _AspNetUserID = value;

                if (_AspNetUserID != null && _AspNetUserID != string.Empty)
                {
                    var employees = db.employee.Where(p => p.AspNetUsersID == _AspNetUserID);

                    foreach (var e in employees)
                    {
                        SelectListItem sli = new SelectListItem() { Value = e.id.ToString(), Text = (e.lastname + " " + e.firstname + " " + e.middlename).Trim() };
                        _Employees.Add(sli);
                        subs.Add(e);

                        var sub = db.employee.Where(p => p.chief_id == e.id || p.mag_id == e.id);

                        foreach (var s in sub)
                        {
                            SelectListItem sli1 = new SelectListItem() { Value = s.id.ToString(), Text = (s.lastname + " " + s.firstname + " " + s.middlename).Trim() };
                            _Employees.Add(sli1);
                            subs.Add(s);
                        }
                    }
                }
            }
        }
        public List<employee> subs = new List<employee>();

        private agatEntities db = new agatEntities();
        private List<SelectListItem> _Employees = new List<SelectListItem>();
        public List<SelectListItem> Employees
        {
            get { return _Employees; }
        }
        private List<SelectListItem> _SKKs = new List<SelectListItem>();
        public List<SelectListItem> SKKs
        {
            get { return _SKKs; }
        }
        private List<SelectListItem> _POSes = new List<SelectListItem>();
        public List<SelectListItem> POSes
        {
            get { return _POSes; }
        }
        private List<SelectListItem> _SalesChannels = new List<SelectListItem>();
        public List<SelectListItem> SalesChannels
        {
            get { return _SalesChannels; }
        }

        public int id { get; set; }
        [Display(Name="Сотрудник")]
        [Required]
        public int employee_id { get; set; }
        [Display(Name = "СКК")]
        [Required]
        public int skk_id { get; set; }
        [Display(Name = "Точка продаж")]
        [Required]
        public int pos_id { get; set; }
        [Display(Name = "Канал продаж")]
        [Required]
        public int channel_id { get; set; }
        [Display(Name = "Сумма отчета")]
        [Required]
        public decimal report_sum { get; set; }
        [Display(Name = "Дата отчета")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Required]
        public System.DateTime report_date { get; set; }
        [Display(Name = "LNR")]
        [Required]
        public string LNR { get; set; }
        [Display(Name = "Номер отчета")]
        public int report_number { get; set; }
        public AddReportViewModel()
        {
            var channels = db.sales_channel.ToList();

            foreach (var c in channels)
            {
                SelectListItem sli = new SelectListItem() { Value = c.id.ToString(), Text = c.short_name };
                _SalesChannels.Add(sli);
            }

            var poses = db.POS.ToList();

            foreach (var p in poses)
            {
                SelectListItem sli = new SelectListItem() { Value = p.id.ToString(), Text = p.name };
                _POSes.Add(sli);
            }
        }
        public void Save()
        {
            report r = new report();
            r.employee_id = this.employee_id;
            r.skk_id = this.skk_id;
            r.pos_id = this.pos_id;
            r.channel_id = this.channel_id;
            r.report_sum = this.report_sum;
            r.report_date = this.report_date;
            r.LNR = this.LNR;
            r.report_number = this.report_number;
            db.report.Add(r);
            db.SaveChanges();
        }
    }
    public class EditReportViewModel
    {
        public class Detail
        {
            private agatEntities db = new agatEntities();

            private List<SelectListItem> _Products = new List<SelectListItem>();
            public List<SelectListItem> Products
            {
                get { return _Products; }
            }

            [Display(Name = "Продукт")]
            public int product_id { get; set; }

            [Display(Name = "Кол-во новых договоров")]
            public int new_amt { get; set; }

            [Display(Name = "Сумма новых договоров")]
            public Decimal new_sum { get; set; }

            [Display(Name = "Кол-во возобновленных договоров")]
            public int old_amt { get; set; }

            [Display(Name = "Сумма возобновленных договоров")]
            public Decimal old_sum { get; set; }

            public Detail()
            {
                var details = db.product.ToList();

                foreach (var d in details)
                {
                    SelectListItem sli = new SelectListItem() { Value = d.id.ToString(), Text = d.short_name};
                    _Products.Add(sli);
                }
            }
        }

        public Detail detail = new Detail();
        public List<report_detail> details = new List<report_detail>();

        private string _AspNetUserID;
        public string AspNetUserID
        {
            get
            {
                return _AspNetUserID;
            }
            set
            {
                _AspNetUserID = value;

                if (_AspNetUserID != null && _AspNetUserID != string.Empty)
                {
                    var employees = db.employee.Where(p => p.AspNetUsersID == _AspNetUserID);

                    foreach (var e in employees)
                    {
                        SelectListItem sli = new SelectListItem() { Value = e.id.ToString(), Text = (e.lastname + " " + e.firstname + " " + e.middlename).Trim() };
                        _Employees.Add(sli);
                        subs.Add(e);

                        var sub = db.employee.Where(p => p.chief_id == e.id || p.mag_id == e.id);

                        foreach (var s in sub)
                        {
                            SelectListItem sli1 = new SelectListItem() { Value = s.id.ToString(), Text = (s.lastname + " " + s.firstname + " " + s.middlename).Trim() };
                            _Employees.Add(sli1);
                            subs.Add(s);
                        }
                    }
                }
            }
        }
        public List<employee> subs = new List<employee>();

        private agatEntities db = new agatEntities();
        private List<SelectListItem> _Employees = new List<SelectListItem>();
        public List<SelectListItem> Employees
        {
            get { return _Employees; }
        }
        private List<SelectListItem> _SKKs = new List<SelectListItem>();
        public List<SelectListItem> SKKs
        {
            get { return _SKKs; }
        }
        private List<SelectListItem> _POSes = new List<SelectListItem>();
        public List<SelectListItem> POSes
        {
            get { return _POSes; }
        }
        private List<SelectListItem> _SalesChannels = new List<SelectListItem>();
        public List<SelectListItem> SalesChannels
        {
            get { return _SalesChannels; }
        }

        private int _id;
        public int id 
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;

                if (_id != 0)
                {
                    var r = db.report.First(p => p.id == _id);
                    this.employee_id = r.employee_id;
                    this.skk_id = r.skk_id;
                    this.pos_id = r.pos_id;
                    this.channel_id = r.channel_id;
                    this.report_sum = r.report_sum;
                    this.report_date = r.report_date;
                    this.LNR = r.LNR;
                    this.report_number = r.report_number;

                    details = db.report_detail.Where(p => p.report_id == _id).ToList();
                }
            }
        }
        [Display(Name = "Сотрудник")]
        [Required]
        public int employee_id { get; set; }
        [Display(Name = "СКК")]
        [Required]
        public int skk_id { get; set; }
        [Display(Name = "Точка продаж")]
        [Required]
        public int pos_id { get; set; }
        [Display(Name = "Канал продаж")]
        [Required]
        public int channel_id { get; set; }
        [Display(Name = "Сумма отчета")]
        [Required]
        public decimal report_sum { get; set; }
        [Display(Name = "Дата отчета")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Required]
        public System.DateTime report_date { get; set; }
        [Display(Name = "LNR")]
        [Required]
        public string LNR { get; set; }
        [Display(Name = "Номер отчета")]
        public int report_number { get; set; }
        public EditReportViewModel()
        {
            var channels = db.sales_channel.ToList();

            foreach (var c in channels)
            {
                SelectListItem sli = new SelectListItem() { Value = c.id.ToString(), Text = c.short_name };
                _SalesChannels.Add(sli);
            }

            var poses = db.POS.ToList();

            foreach (var p in poses)
            {
                SelectListItem sli = new SelectListItem() { Value = p.id.ToString(), Text = p.name };
                _POSes.Add(sli);
            }
        }
        public void Save()
        {
            report r = db.report.First(p => p.id == this.id);
            r.employee_id = this.employee_id;
            r.skk_id = this.skk_id;
            r.pos_id = this.pos_id;
            r.channel_id = this.channel_id;
            r.report_sum = this.report_sum;
            r.report_date = this.report_date;
            r.LNR = this.LNR;
            r.report_number = this.report_number;
            db.Entry(r).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
        public void AddDetail()
        {
            report_detail d = new report_detail();
            d.report_id = this.id;
            d.new_amt = this.detail.new_amt;
            d.old_amt = this.detail.old_amt;
            d.new_sum = this.detail.new_sum;
            d.old_sum = this.detail.old_sum;
            d.product_id = this.detail.product_id;
            db.report_detail.Add(d);
            db.SaveChanges();
        }
    }
}