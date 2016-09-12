using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VkazoMaterial.Models;

namespace VkazoMaterial.Controllers
{
    public class UserHasMaterialsController : Controller
    {
        private VkazoMaterialDbContext db = new VkazoMaterialDbContext();

        // GET: UserHasMaterials
        //public ActionResult Index()
        //{
        //    return View(db.UserHasMaterials.ToList());
        //}

        // GET: UserHasMaterials Search
        public ActionResult Index()
        {
            var searchTerm = Request.QueryString("filter");
            if (!string.IsNullOrEmpty(searchTerm))
            {
                return View(db.UserHasMaterials.ToList().Where(entity => entity.User.Contraction == searchTerm));
            }
            return View(db.UserHasMaterials.ToList());
        }

        // GET: UserHasMaterials/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserHasMaterial userHasMaterial = db.UserHasMaterials.Find(id);
            if (userHasMaterial == null)
            {
                return HttpNotFound();
            }
            return View(userHasMaterial);
        }

        // GET: UserHasMaterials/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.Users, "Id", "Contraction");
            ViewBag.MaterialId = new SelectList(db.Materials.Where(entity => !db.UserHasMaterials.Select(b => b.MaterialId).Contains(entity.Id)), "Id", "Serialnumber");
            return View();
        }

        // POST: UserHasMaterials/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ReceiveDate,UserId,MaterialId")] UserHasMaterial userHasMaterial)
        {
            if (ModelState.IsValid)
            {
                userHasMaterial.Material = db.Materials.Find(userHasMaterial.MaterialId);
                db.SaveChanges();
                userHasMaterial.User = db.Users.Find(userHasMaterial.UserId);
                db.UserHasMaterials.Add(userHasMaterial);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "Contraction", userHasMaterial.User.Id);
            ViewBag.MaterialId = new SelectList(db.Materials.Where(entity => !db.UserHasMaterials.Select(b => b.MaterialId).Contains(entity.Id)), "Id", "Serialnumber");
            return View(userHasMaterial);
        }

        // GET: UserHasMaterials/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserHasMaterial userHasMaterial = db.UserHasMaterials.Find(id);
            if (userHasMaterial == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "Contraction", userHasMaterial.User.Id);
            ViewBag.MaterialId = new SelectList(db.Materials.Where(entity => !db.UserHasMaterials.Select(b => b.MaterialId).Contains(entity.Id)), "Id", "Serialnumber");
            return View(userHasMaterial);
        }

        // POST: UserHasMaterials/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ReceiveDate,UserId,MaterialId")] UserHasMaterial userHasMaterial)
        {
            if (ModelState.IsValid)
            {
                userHasMaterial.Material = db.Materials.Find(userHasMaterial.MaterialId);
                userHasMaterial.User = db.Users.Find(userHasMaterial.UserId);
                db.Entry(userHasMaterial).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "Contraction", userHasMaterial.User.Id);
            ViewBag.MaterialId = new SelectList(db.Materials.Where(entity => !db.UserHasMaterials.Select(b => b.MaterialId).Contains(entity.Id)), "Id", "Serialnumber");
            return View(userHasMaterial);
        }

        // GET: UserHasMaterials/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserHasMaterial userHasMaterial = db.UserHasMaterials.Find(id);
            if (userHasMaterial == null)
            {
                return HttpNotFound();
            }
            return View(userHasMaterial);
        }

        // POST: UserHasMaterials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserHasMaterial userHasMaterial = db.UserHasMaterials.Find(id);
            db.UserHasMaterials.Remove(userHasMaterial);
            db.SaveChanges();
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
