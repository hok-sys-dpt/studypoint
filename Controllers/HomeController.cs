using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudyPoints.Models;

namespace StudyPoints.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext context;

        public HomeController()
        {
            context = new ApplicationDbContext();
            context.Configuration.LazyLoadingEnabled = false;
        }

        public ActionResult Index()
        {
            if (User.IsInRole("CanManagePointItem"))
            {
                var result = context.PointLists.GroupBy(c => c.UserName).Select(c => new
                {
                    UserName = c.Key,
                    TotalPoint = c.Sum(d => d.Points),
                }).ToList();
                ViewBag.Result = result;
                return View("IndexForAdmin");
            }
            else
            {
                return View("Index");
            }           
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}