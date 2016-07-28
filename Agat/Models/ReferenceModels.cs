using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.WebPages.Html;

namespace Agat.Models
{
    public class ProductViewModel
    {
        private agatEntities db = new agatEntities();
        public List<product> products = new List<product>();
        private List<SelectListItem> _ProductGroups = new List<SelectListItem>();

        public int id { get; set; }
        [Display(Name="Группа продуктов")]
        [Required]
        public int ProductGroupID { get; set; }
        [Display(Name = "Группа продуктов")]
        public List<SelectListItem> ProductGroups
        {
            get { return _ProductGroups; }
        }
        [Display(Name = "Полное наименование")]
        [Required]
        public string FullName { get; set; }
        [Display(Name = "Краткое наименование")]
        [Required]
        public string ShortName { get; set; }
        [Display(Name="Порядок сортировки")]
        public int sortorder { get; set; }

        public ProductViewModel()
        {
            var pgs = db.product_group;

            foreach (var pg in pgs)
            {
                SelectListItem sli = new SelectListItem();
                sli.Value = pg.id.ToString();
                sli.Text = pg.short_name;
                _ProductGroups.Add(sli);
            }
        }
        public bool Get(int id)
        {
            var product = db.product.First(p => p.id == id);

            if (product == null)
                return false;
            
            this.id = product.id;
            this.ProductGroupID = product.product_group_id;
            this.FullName = product.full_name;
            this.ShortName = product.short_name;
            this.sortorder = product.sortorder;
            return true;
        }
        public void GetList()
        {
            products = db.product.ToList();
        }
        public void AddProduct()
        {
            db.AddProduct(ProductGroupID, FullName, ShortName, sortorder);
        }
        public void EditProduct()
        {
            db.EditProduct(id, ProductGroupID, FullName, ShortName, sortorder);
        }
    }
    public class ProductGroupViewModel
    {
        private agatEntities db = new agatEntities();
        public List<product_group> product_groups = new List<product_group>();
        [Display(Name = "ID")]
        public int id { get; set; }
        [Display(Name = "ФП")]
        [Required]
        public string FP { get; set; }
        [Display(Name = "Полное наименование")]
        [Required]
        public string FullName { get; set; }
        [Display(Name = "Краткое наименование")]
        [Required]
        public string ShortName { get; set; }
        [Display(Name="Вес группы")]
        public byte GroupWeight { get; set; }
        public void GetList()
        {
            product_groups = db.product_group.ToList();
        }
        public bool Get(int id)
        {
            var pg = db.product_group.First(p => p.id == id);

            if (pg == null)
                return false;

            this.id = pg.id;
            this.FP = pg.FP;
            this.FullName = pg.full_name;
            this.ShortName = pg.short_name;
            this.GroupWeight = pg.group_weight;
            return true;
        }
        public void AddPropductGroup()
        {
            db.AddProductGroup(FP, FullName, ShortName, GroupWeight);
        }
        public void EditProductGroup()
        {
            db.EditProductGroup(id, FP, FullName, ShortName, GroupWeight);
        }
    }
    public class PositionViewModel
    {
        private agatEntities db = new agatEntities();
        public List<position> positions = new List<position>();
        [Display(Name="ID")]
        public int id { get; set; }
        [Display(Name = "Должность")]
        [Required]
        public string name { get; set; }
        public bool Get(int id)
        {
            var pos = db.position.First(p => p.id == id);

            if (pos == null)
                return false;

            this.id = pos.id;
            this.name = pos.name;
            return true;
        }
        public void GetList()
        {
            this.positions = db.position.ToList();
        }
        public void AddPosition()
        {
            db.AddPosition(name);
        }
        public void EditPosition()
        {
            db.EditPosition(id, name);
        }
    }
    public class SalesChannelViewModel
    {
        private agatEntities db = new agatEntities();
        public List<sales_channel> sales_channels = new List<sales_channel>();

        [Display(Name="ID")]
        public int id { get; set; }
        [Display(Name = "Полное наименование")]
        [Required]
        public string FullName { get; set; }
        [Display(Name = "Краткое наименование")]
        [Required]
        public string ShortName { get; set; }
        public bool Get(int id)
        {
            var sc = db.sales_channel.First(p => p.id == id);

            if (sc == null)
                return false;

            this.id = sc.id;
            this.FullName = sc.full_name;
            this.ShortName = sc.short_name;
            return true;
        }
        public void GetList()
        {
            this.sales_channels = db.sales_channel.ToList();
        }
        public void AddSalesChannel()
        {
            db.AddSalesChannel(FullName, ShortName);
        }
        public void EditSalesChannel()
        {
            db.EditSalesChannel(id, FullName, ShortName);
        }
    }
}