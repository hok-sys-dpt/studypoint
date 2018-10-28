using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudyPoints.Models;
using Microsoft.AspNet.Identity;

namespace StudyPoints.Controllers
{
    public class PointListController : Controller
    {
        private ApplicationDbContext context;

        public PointListController()
        {
            context = new ApplicationDbContext();
            context.Configuration.LazyLoadingEnabled = false;
        }

        // GET: PointList
        public ActionResult Index()
        {
            if (User.IsInRole("CanManagePointItem"))
                return View("ListForAdmin");
            return View("List");
        }


        public ActionResult New()
        {
            var results = context.PointItems.ToList();
            var viewModel = new PointListViewModels
            {
                PointList = new PointList(),
                PointItems = results
            };
            return View(viewModel);
        }

        // POST: Insert
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Insert(PointListViewModels model)
        {
            string userId = User.Identity.GetUserId();
            string userName = User.Identity.GetUserName();
            var result = context.PointItems.FirstOrDefault(c => c.Id == model.PointList.PointItemId);
            var value = new PointList
            {
                UserId = userId,
                UserName = userName,
                PointItemId = model.PointList.PointItemId,
                PointItemName = result.Name,
                Points = model.PointList.Points,
                Remark = model.PointList.Remark,
                DateAdded = DateTime.Now
            };
            context.PointLists.Add(value);
            context.SaveChanges();
            return RedirectToAction("Index", "PointList");
        }
    }
}