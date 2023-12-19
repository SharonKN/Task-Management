using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Task_Managemenet.Models;

namespace Task_Managemenet.Controllers
{
    public class TasksController : Controller
    {
        private TaskManagementEntities db = new TaskManagementEntities();

        // GET: Tasks
        public async Task<ActionResult> Index()
        {
            var task = db.Task.Include(t => t.Priority).Include(t => t.Status);
            return View(await task.ToListAsync());
        }

        // GET: Tasks/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Task task = await db.Task.FindAsync(id);
            if (task == null)
            {
                return HttpNotFound();
            }
            return View(task);
        }

        // GET: Tasks/Create
        public ActionResult Create()
        {
            ViewBag.PriorityID = new SelectList(db.Priority, "PriorityID", "PriorityName");
            ViewBag.StatusType = new SelectList(db.Status, "StatusID", "StatusType");
            return View();
        }

        // POST: Tasks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "TaskID,Description,StatusType,StartDate,DueDate,PriorityID")] Task task)
        {
            if (ModelState.IsValid)
            {
                db.Task.Add(task);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.PriorityID = new SelectList(db.Priority, "PriorityID", "PriorityName", task.PriorityID);
            ViewBag.StatusType = new SelectList(db.Status, "StatusID", "StatusType", task.StatusType);
            return View(task);
        }

        // GET: Tasks/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Task task = await db.Task.FindAsync(id);
            if (task == null)
            {
                return HttpNotFound();
            }
            ViewBag.PriorityID = new SelectList(db.Priority, "PriorityID", "PriorityName", task.PriorityID);
            ViewBag.StatusType = new SelectList(db.Status, "StatusID", "StatusType", task.StatusType);
            return View(task);
        }

        // POST: Tasks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "TaskID,Description,StatusType,StartDate,DueDate,PriorityID")] Task task)
        {
            if (ModelState.IsValid)
            {
                db.Entry(task).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.PriorityID = new SelectList(db.Priority, "PriorityID", "PriorityName", task.PriorityID);
            ViewBag.StatusType = new SelectList(db.Status, "StatusID", "StatusType", task.StatusType);
            return View(task);
        }

        // GET: Tasks/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Task task = await db.Task.FindAsync(id);
            if (task == null)
            {
                return HttpNotFound();
            }
            return View(task);
        }

        // POST: Tasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Task task = await db.Task.FindAsync(id);
            db.Task.Remove(task);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
