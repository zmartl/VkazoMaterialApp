using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

using VkazoMaterial.Models;

namespace VkazoMaterial.Controllers
{
    public class RanksController : Controller
    {
        private readonly VkazoMaterialDbContext db = new VkazoMaterialDbContext();

        // GET: Ranks
        public ActionResult Index()
        {
            return View(db.Grades.ToList());
        }

        // GET: Ranks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var rank = db.Grades.Find(id);
            if (rank == null)
            {
                return HttpNotFound();
            }
            return View(rank);
        }

        // GET: Ranks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ranks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,RankName")] Rank rank)
        {
            if (ModelState.IsValid)
            {
                if (db.Grades.Count(entity => entity.RankName.Equals(rank.RankName)) == 0)
                {
                    db.Grades.Add(rank);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.AlreadyExist = true;
            }

            return View(rank);
        }

        // GET: Ranks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var rank = db.Grades.Find(id);
            if (rank == null)
            {
                return HttpNotFound();
            }
            return View(rank);
        }

        // POST: Ranks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RankName")] Rank rank)
        {
            if (ModelState.IsValid)
            {
                if (db.Grades.Where(entity => entity.Id != rank.Id).Count(entity => entity.RankName == rank.RankName) == 0)
                {
                    db.Entry(rank).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.AlreadyExist = true;
            }
            return View(rank);
        }

        // GET: Ranks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var rank = db.Grades.Find(id);
            if (rank == null)
            {
                return HttpNotFound();
            }
            return View(rank);
        }

        // POST: Ranks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var rank = db.Grades.Find(id);
            db.Grades.Remove(rank);
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