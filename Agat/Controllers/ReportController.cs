using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Agat.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Agat.Controllers
{
    public class ReportController : Controller
    {
        // GET: Report
        public ActionResult Index()
        {
            ReportViewModel model = new ReportViewModel();
            model.GetList();
            return View(model);
        }
        public ActionResult Add()
        {
            AddReportViewModel model = new AddReportViewModel() { AspNetUserID = User.Identity.GetUserId() };
            return View(model);
        }
        [HttpPost]
        public ActionResult Add(AddReportViewModel model)
        {
            if(!ModelState.IsValid)
                return View(model);

            model.Save();
            return RedirectToAction("Edit", new { id = model.id });
        }
        public ActionResult Edit(int id)
        {
            EditReportViewModel model = new EditReportViewModel() { AspNetUserID = User.Identity.GetUserId(), id = id };
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(EditReportViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            model.Save();
            return RedirectToAction("Index");
        }
        /*[HttpPost]
        public ActionResult AddDetail(int id, int detail_product_id, int detail_new_amt, decimal detail_new_sum, int detail_old_amt, int detail_old_sum)
        {
            EditReportViewModel model = new EditReportViewModel() { AspNetUserID = User.Identity.GetUserId(), id = id };
            model.detail.product_id = detail_product_id;
            model.detail.new_sum = detail_new_sum;
            model.detail.old_sum = detail_old_sum;
            model.detail.new_amt = detail_new_amt;
            model.detail.old_amt = detail_old_amt;
            model.AddDetail();
            return RedirectToAction("Edit", new { id = id });
        }*/
        [HttpPost]
        public ActionResult AddDetail(EditReportViewModel model)
        {
            //model.AddDetail();
            return RedirectToAction("Edit");
        }
    }
}