using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using PagedList;
using System.Web.WebPages.Html;

namespace Agat.Models
{
    public class EmployeeViewModel
    {
        private agatEntities db = new agatEntities();
        public List<employee> employees = new List<employee>();
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
        public void GetList()
        {
            employees = db.employee.OrderBy(p => p.lastname).ToList();
        }
    }
    public class AddEmployeeViewModel
    {
        private agatEntities db = new agatEntities();
        private List<SelectListItem> _Employees = new List<SelectListItem>();
        private List<SelectListItem> _POSES = new List<SelectListItem>();
        private List<SelectListItem> _Positions = new List<SelectListItem>();
        public List<SelectListItem> Employees
        {
            get { return _Employees; }
        }
        public List<SelectListItem> POSES
        {
            get { return _POSES; }
        }
        public List<SelectListItem> Positions
        {
            get { return _Positions; }
        }

        public int id { get; set; }
        [Display(Name="Фамилия")]
        [Required]
        public string lastname { get; set; }
        [Display(Name = "Имя")]
        [Required]
        public string firstname { get; set; }
        [Display(Name = "Отчество")]
        [Required]
        public string middlename { get; set; }
        [Display(Name = "Дата рождения")]
        [Required]
        public Nullable<System.DateTime> DOB { get; set; }
        [Display(Name = "Дата увольнения")]
        public Nullable<System.DateTime> DOD { get; set; }
        [Display(Name = "Email")]
        public string email { get; set; }
        [Display(Name = "Должность")]
        public int position_id { get; set; }
        [Display(Name = "Категория")]
        public byte category { get; set; }
        [Display(Name = "Точка продаж")]
        public Nullable<int> pos_id { get; set; }
        [Display(Name = "Руководитель")]
        public Nullable<int> chief_id { get; set; }
        [Display(Name = "МАГ")]
        public Nullable<int> mag_id { get; set; }
        [Display(Name = "Табельный номер")]
        [Required]
        public string personnel_number { get; set; }
        public string AspNetUsersID { get; set; }

        public AddEmployeeViewModel()
        {
            var emps = db.employee.ToList();

            foreach (var e in emps)
            {
                SelectListItem sli = new SelectListItem();
                sli.Value = e.id.ToString();
                sli.Text = (e.lastname + " " + e.firstname + " " + e.middlename).Trim();
                _Employees.Add(sli);
            }

            var poses = db.POS.ToList();

            foreach (var p in poses)
            {
                SelectListItem sli = new SelectListItem();
                sli.Value = p.id.ToString();
                sli.Text = p.name;
                _POSES.Add(sli);
            }

            var positions = db.position.ToList();

            foreach (var p in positions)
            {
                SelectListItem sli = new SelectListItem();
                sli.Value = p.id.ToString();
                sli.Text = p.name;
                _Positions.Add(sli);
            }
        }
        public void AddEmployee()
        {
            db.AddEmployee(lastname, firstname, middlename, DOB, DOD, email, position_id, category, pos_id, chief_id, mag_id, personnel_number, AspNetUsersID, null);
        }
    }
    public class AddEmployeeUserViewModel
    {
        private agatEntities db = new agatEntities();
        private List<SelectListItem> _Employees = new List<SelectListItem>();
        private List<SelectListItem> _POSES = new List<SelectListItem>();
        private List<SelectListItem> _Positions = new List<SelectListItem>();
        private List<SelectListItem> _Roles = new List<SelectListItem>();
        public List<SelectListItem> Employees
        {
            get { return _Employees; }
        }
        public List<SelectListItem> POSES
        {
            get { return _POSES; }
        }
        public List<SelectListItem> Positions
        {
            get { return _Positions; }
        }
        public List<SelectListItem> Roles
        {
            get { return _Roles; }
        }

        public int id { get; set; }
        [Display(Name = "Фамилия")]
        [Required]
        public string lastname { get; set; }
        [Display(Name = "Имя")]
        [Required]
        public string firstname { get; set; }
        [Display(Name = "Отчество")]
        [Required]
        public string middlename { get; set; }
        [Display(Name = "Дата рождения")]
        [Required]
        public Nullable<System.DateTime> DOB { get; set; }
        [Display(Name = "Дата увольнения")]
        public Nullable<System.DateTime> DOD { get; set; }
        [Display(Name = "Email")]
        [Required]
        public string email { get; set; }
        [Display(Name = "Должность")]
        public int position_id { get; set; }
        [Display(Name = "Категория")]
        public byte category { get; set; }
        [Display(Name = "Точка продаж")]
        public Nullable<int> pos_id { get; set; }
        [Display(Name = "Руководитель")]
        public Nullable<int> chief_id { get; set; }
        [Display(Name = "МАГ")]
        public Nullable<int> mag_id { get; set; }
        [Display(Name = "Табельный номер")]
        [Required]
        public string personnel_number { get; set; }
        public string AspNetUsersID { get; set; }

        [Required]
        [Display(Name = "Логин")]
        public string Login { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Пароль должен содержать не менее {0} символов.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Подтверждение пароля")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "Уровень доступа")]
        public string role_id { get; set; }

        public AddEmployeeUserViewModel()
        {
            var emps = db.employee.ToList();

            foreach (var e in emps)
            {
                SelectListItem sli = new SelectListItem();
                sli.Value = e.id.ToString();
                sli.Text = (e.lastname + " " + e.firstname + " " + e.middlename).Trim();
                _Employees.Add(sli);
            }

            var poses = db.POS.ToList();

            foreach (var p in poses)
            {
                SelectListItem sli = new SelectListItem();
                sli.Value = p.id.ToString();
                sli.Text = p.name;
                _POSES.Add(sli);
            }

            var positions = db.position.ToList();

            foreach (var p in positions)
            {
                SelectListItem sli = new SelectListItem();
                sli.Value = p.id.ToString();
                sli.Text = p.name;
                _Positions.Add(sli);
            }

            var roles = db.AspNetRoles.ToList();

            foreach (var r in roles)
            {
                SelectListItem sli = new SelectListItem();
                sli.Value = r.Id;
                sli.Text = r.Name;
                _Roles.Add(sli);
            }
        }
        public void AddEmployee(string userid)
        {
            AspNetUsersID = userid;
            db.AddEmployee(lastname, firstname, middlename, DOB, DOD, email, position_id, category, pos_id, chief_id, mag_id, personnel_number, AspNetUsersID, null);
        }
    }
    public class EditEmployeeViewModel
    {
        private agatEntities db = new agatEntities();
        private List<SelectListItem> _MAGs = new List<SelectListItem>();
        private List<SelectListItem> _Chiefs = new List<SelectListItem>();
        private List<SelectListItem> _POSES = new List<SelectListItem>();
        private List<SelectListItem> _Positions = new List<SelectListItem>();
        public List<SelectListItem> MAGS
        {
            get { return _MAGs; }
        }
        public List<SelectListItem> Chiefs
        {
            get { return _Chiefs; }
        }
        public List<SelectListItem> POSES
        {
            get { return _POSES; }
        }
        public List<SelectListItem> Positions
        {
            get { return _Positions; }
        }

        public int id { get; set; }
        [Display(Name="Фамилия")]
        [Required]
        public string lastname { get; set; }
        [Display(Name = "Имя")]
        [Required]
        public string firstname { get; set; }
        [Display(Name = "Отчество")]
        [Required]
        public string middlename { get; set; }
        [Display(Name = "Дата рождения")]
        [Required]
        public Nullable<System.DateTime> DOB { get; set; }
        [Display(Name = "Дата увольнения")]
        public Nullable<System.DateTime> DOD { get; set; }
        [Display(Name = "Email")]
        public string email { get; set; }
        [Display(Name = "Должность")]
        public int position_id { get; set; }
        [Display(Name = "Категория")]
        public byte category { get; set; }
        [Display(Name = "Точка продаж")]
        public Nullable<int> pos_id { get; set; }
        [Display(Name = "Руководитель")]
        public Nullable<int> chief_id { get; set; }
        [Display(Name = "МАГ")]
        public Nullable<int> mag_id { get; set; }
        [Display(Name = "Табельный номер")]
        [Required]
        public string personnel_number { get; set; }
        public string AspNetUsersID { get; set; }

        public EditEmployeeViewModel()
        {
            var emps = db.employee.ToList();

            foreach (var e in emps)
            {
                SelectListItem sli = new SelectListItem();
                sli.Value = e.id.ToString();
                sli.Text = (e.lastname + " " + e.firstname + " " + e.middlename).Trim();
                _MAGs.Add(sli);
                _Chiefs.Add(sli);
            }

            var poses = db.POS.ToList();

            foreach (var p in poses)
            {
                SelectListItem sli = new SelectListItem();
                sli.Value = p.id.ToString();
                sli.Text = p.name;
                _POSES.Add(sli);
            }

            var positions = db.position.ToList();

            foreach (var p in positions)
            {
                SelectListItem sli = new SelectListItem();
                sli.Value = p.id.ToString();
                sli.Text = p.name;
                _Positions.Add(sli);
            }
        }

        public bool Get(int id)
        {
            var ei = db.employee.First(p => p.id == id);

            if (ei == null)
                return false;

            var position = _Positions.Find(p => p.Value == ei.position_id.ToString());

            if (position != null)
                position.Selected = true;

            var pos = _POSES.Find(p => p.Value == ei.pos_id.ToString());

            if (pos != null)
                pos.Selected = true;

            var chief = _Chiefs.Find(p => p.Value == ei.chief_id.ToString());

            if (chief != null)
                chief.Selected = true;

            var mag = _MAGs.Find(p => p.Value == ei.mag_id.ToString());

            if (mag != null)
                mag.Selected = true;

            this.id = ei.id;
            this.lastname = ei.lastname;
            this.firstname = ei.firstname;
            this.middlename = ei.middlename;
            this.DOB = ei.DOB;
            this.DOD = ei.DOD;
            this.email = ei.email;
            this.position_id = ei.position_id;
            this.category = ei.category;
            this.pos_id = ei.pos_id;
            this.chief_id = ei.chief_id;
            this.mag_id = ei.mag_id;
            this.personnel_number = ei.tabel.personnel_number;
            this.AspNetUsersID = ei.AspNetUsersID;

            return true;
        }
        public void EditEmployee()
        {
            db.EditEmployee(id, lastname, firstname, middlename, DOB, DOD, email, position_id, category, pos_id, chief_id, mag_id, personnel_number, AspNetUsersID, null);
        }
    }
}