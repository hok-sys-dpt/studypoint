using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudyPoints.Models;

namespace StudyPoints.Controllers
{
    public class PointItemController : Controller
    {
        private ApplicationDbContext context;

        public PointItemController()
        {
            context = new ApplicationDbContext();
            context.Configuration.LazyLoadingEnabled = false;
        }

        // GET: PointItem
        public ActionResult Index()
        {
            if (User.IsInRole("CanManagePointItem"))
                return View("List");
            return View("ReadOnlyList");
        }

        // GET: 
        public ActionResult New()
        {
            var model = new PointItem();
            return View(model);
        }

        // POST:
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Insert(PointItem model)
        {
            var value = new PointItem
            {
                Name = model.Name,
                Points = model.Points
            };
            context.PointItems.Add(value);
            context.SaveChanges();
            return RedirectToAction("Index", "PointItem");
        }
    }
}