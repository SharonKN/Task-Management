using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task_Managemenet.Models;

namespace Task_Managemenet.Controllers
{
    public class HomeController : Controller
    {
        // Public property for the context
        private TaskManagementEntities db = new TaskManagementEntities();

        public ActionResult Index()
        {
            // Fetch priorities and status types from the database
            ViewBag.Priorities = db.Priority.Select(p => new SelectListItem
            {
                Value = p.PriorityID.ToString(),
                Text = p.PriorityName
            });

            ViewBag.StatusTypes = db.Status.Select(s => new SelectListItem
            {
                Value = s.StatusID.ToString(),
                Text = s.StatusType
            });

            // Fetch tasks from the database
            ViewBag.Tasks = db.Task.ToList();

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