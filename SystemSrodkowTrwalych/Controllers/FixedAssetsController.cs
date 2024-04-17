using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SystemSrodkowTrwalych.DAL;
using SystemSrodkowTrwalych.Models;

namespace SystemSrodkowTrwalych.Controllers
{
    public class FixedAssetsController : Controller
    {
        private FixedAssetsContext db = new FixedAssetsContext();

        // GET: FixedAssets
        public ActionResult Index()
        {
             var fixedAssets = db.FixedAssets.Include(f => f.Categories).Include(f => f.Users);
             return View(fixedAssets.ToList());
         
        }

        // GET: FixedAssets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FixedAssets fixedAssets = db.FixedAssets.Find(id);
            if (fixedAssets == null)
            {
                return HttpNotFound();
            }
            return View(fixedAssets);
        }

        // GET: FixedAssets/Create
        public ActionResult Create()
        {
            ViewBag.ID = new SelectList(db.Amortization, "ID", "Description");
            ViewBag.CategoriesID = new SelectList(db.Categories, "ID", "CatTypes");
            ViewBag.UsersID = new SelectList(db.Users, "ID", "FirstName");
            return View();
        }

        // POST: FixedAssets/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,AmortizationID,CategoriesID,UsersID,Name,DateOfCollections")] FixedAssets fixedAssets)
        {
            if (ModelState.IsValid)
            {
                db.FixedAssets.Add(fixedAssets);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID = new SelectList(db.Amortization, "ID", "Description", fixedAssets.ID);
            ViewBag.CategoriesID = new SelectList(db.Categories, "ID", "CatTypes", fixedAssets.CategoriesID);
           // ViewBag.UsersID = new SelectList(db.Users, "ID", "FirstName", fixedAssets.UsersID);
            return View(fixedAssets);
        }

        // GET: FixedAssets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FixedAssets fixedAssets = db.FixedAssets.Find(id);
            if (fixedAssets == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID = new SelectList(db.Amortization, "ID", "Description", fixedAssets.ID);
            ViewBag.CategoriesID = new SelectList(db.Categories, "ID", "CatTypes", fixedAssets.CategoriesID);
         //   ViewBag.UsersID = new SelectList(db.Users, "ID", "FirstName", fixedAssets.UsersID);
            return View(fixedAssets);
        }

        // POST: FixedAssets/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,AmortizationID,CategoriesID,UsersID,Name,DateOfCollections")] FixedAssets fixedAssets)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fixedAssets).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID = new SelectList(db.Amortization, "ID", "Description", fixedAssets.ID);
            ViewBag.CategoriesID = new SelectList(db.Categories, "ID", "CatTypes", fixedAssets.CategoriesID);
          //  ViewBag.UsersID = new SelectList(db.Users, "ID", "FirstName", fixedAssets.UsersID);
            return View(fixedAssets);
        }

        // GET: FixedAssets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FixedAssets fixedAssets = db.FixedAssets.Find(id);
            if (fixedAssets == null)
            {
                return HttpNotFound();
            }
            return View(fixedAssets);
        }

        // POST: FixedAssets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FixedAssets fixedAssets = db.FixedAssets.Find(id);
            db.FixedAssets.Remove(fixedAssets);
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
