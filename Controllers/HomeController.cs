using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task_Managemenet.Models;
using System.Data.Entity;


namespace Task_Managemenet.Controllers
{
    public class HomeController : Controller
    {
        // Public property for the context
        private TaskManagementEntities db = new TaskManagementEntities();

        public ActionResult Index()
        {
            ViewBag.Task = db.Task
                .Include(t => t.Priority)
                .Include(t => t.Status)
                .ToList();

            return View();
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