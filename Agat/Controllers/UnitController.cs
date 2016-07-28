using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Agat.Models;

namespace Agat.Controllers
{
    public class UnitController : Controller
    {
        // GET: Unit
        public ActionResult Index()
        {
            return View();
        }
        #region Branch
        public ActionResult Branch()
        {
            BranchViewModel model = new BranchViewModel();
            model.GetList();
            return View(model);
        }
        public ActionResult BranchDetails(int id)
        {
            BranchViewModel model = new BranchViewModel();
            model.Get(id);
            return View(model);
        }
        public ActionResult AddBranch()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddBranch(BranchViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            model.AddBranch();
            return RedirectToAction("Branch");
        }
        public ActionResult EditBranch(int? id)
        {
            if (id == null)
                return RedirectToAction("Branch");

            BranchViewModel model = new BranchViewModel();

            if (!model.Get((int)id))
                return RedirectToAction("Branch");

            return View(model);
        }
        [HttpPost]
        public ActionResult EditBranch(BranchViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            model.EditBranch();
            return RedirectToAction("Branch");
        }
        #endregion
        #region SKK
        public ActionResult SKK()
        {
            SKKViewModel model = new SKKViewModel();
            model.GetList();
            return View(model);
        }
        public ActionResult SKKDetails(int id)
        {
            SKKViewModel model = new SKKViewModel();
            model.Get(id);
            return View(model);
        }
        public ActionResult AddSKK()
        {
            SKKViewModel model = new SKKViewModel();
            return View(model);
        }
        [HttpPost]
        public ActionResult AddSKK(SKKViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            model.AddSKK();
            return RedirectToAction("SKK");
        }
        public ActionResult EditSKK(int? id)
        {
            if (id == null)
                return RedirectToAction("SKK");

            SKKViewModel model = new SKKViewModel();

            if (!model.Get((int)id))
                return RedirectToAction("SKK");

            return View(model);
        }
        [HttpPost]
        public ActionResult EditSKK(SKKViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            model.EditSKK();
            return RedirectToAction("SKK");
        }
        #endregion
        #region OSPGroup
        public ActionResult OSPGroup()
        {
            OSPGroupViewModel model = new OSPGroupViewModel();
            model.GetList();
            return View(model);
        }
        public ActionResult OSPGroupDetails(int id)
        {
            OSPGroupViewModel model = new OSPGroupViewModel();
            model.Get(id);
            return View(model);
        }
        public ActionResult AddOSPGroup()
        {
            OSPGroupViewModel model = new OSPGroupViewModel();
            return View(model);
        }
        [HttpPost]
        public ActionResult AddOSPGroup(OSPGroupViewModel model)
        {
            if(!ModelState.IsValid)
                return View(model);

            model.AddOSPGroup();
            return RedirectToAction("OSPGroup");
        }
        public ActionResult EditOSPGroup(int id)
        {
            OSPGroupViewModel model = new OSPGroupViewModel();
            model.Get(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult EditOSPGroup(OSPGroupViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            model.EditOSPGroup();
            return RedirectToAction("OSPGroup");
        }
        #endregion
        #region POS
        public ActionResult POS()
        {
            POSViewModel model = new POSViewModel();
            model.GetList();
            return View(model);
        }
        public ActionResult POSDetails(int id)
        {
            POSViewModel model = new POSViewModel();
            model.Get(id);
            return View(model);
        }
        public ActionResult AddPOS()
        {
            POSViewModel model = new POSViewModel();
            return View(model);
        }
        [HttpPost]
        public ActionResult AddPOS(POSViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            model.AddPOS();
            return RedirectToAction("POS");
        }
        public ActionResult EditPOS(int id)
        {
            POSViewModel model = new POSViewModel();
            model.Get(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult EditPOS(POSViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            model.EditPOS();
            return RedirectToAction("POS");
        }
        #endregion
    }
}