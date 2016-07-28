using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Agat.Models;

namespace Agat.Controllers
{
    public class ReferenceController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Product()
        {
            ProductViewModel model = new ProductViewModel();
            model.GetList();
            return View(model);
        }
        public ActionResult AddProduct()
        {
            ProductViewModel model = new ProductViewModel();
            return View(model);
        }
        [HttpPost]
        public ActionResult AddProduct(ProductViewModel model)
        {
            if(!ModelState.IsValid)
                return View(model);

            model.AddProduct();
            return RedirectToAction("Product");
        }
        public ActionResult EditProduct(int id)
        {
            ProductViewModel model = new ProductViewModel();
            model.Get(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult EditProduct(ProductViewModel model)
        {
            if(!ModelState.IsValid)
                return View(model);

            model.EditProduct();
            return RedirectToAction("Product");
        }
        public ActionResult ProductGroup()
        {
            ProductGroupViewModel model = new ProductGroupViewModel();
            model.GetList();
            return View(model);
        }
        public ActionResult AddProductGroup()
        {
            ProductGroupViewModel model = new ProductGroupViewModel();
            return View(model);
        }
        [HttpPost]
        public ActionResult AddProductGroup(ProductGroupViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            model.AddPropductGroup();
            return RedirectToAction("ProductGroup");
        }
        public ActionResult EditProductGroup(int id)
        {
            ProductGroupViewModel model = new ProductGroupViewModel();
            model.Get(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult EditProductGroup(ProductGroupViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            model.EditProductGroup();
            return RedirectToAction("ProductGroup");
        }
        public ActionResult Position()
        {
            PositionViewModel model = new PositionViewModel();
            model.GetList();
            return View(model);
        }
        public ActionResult AddPosition()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddPosition(PositionViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            model.AddPosition();
            return RedirectToAction("Position");
        }
        public ActionResult EditPosition(int id)
        {
            PositionViewModel model = new PositionViewModel();
            model.Get(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult EditPosition(PositionViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            model.EditPosition();
            return RedirectToAction("Position");
        }
        public ActionResult SalesChannel()
        {
            SalesChannelViewModel model = new SalesChannelViewModel();
            model.GetList();
            return View(model);
        }
        public ActionResult AddSalesChannel()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddSalesChannel(SalesChannelViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            model.AddSalesChannel();
            return RedirectToAction("SalesChannel");
        }
        public ActionResult EditSalesChannel(int id)
        {
            SalesChannelViewModel model = new SalesChannelViewModel();
            model.Get(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult EditSalesChannel(SalesChannelViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            model.EditSalesChannel();
            return RedirectToAction("SalesChannel");
        }
    }
}