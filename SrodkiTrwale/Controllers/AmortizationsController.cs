using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SrodkiTrwale.Context;
using SrodkiTrwale.Models;

namespace SrodkiTrwale.Controllers
{
    [Authorize]
    public class AmortizationsController : Controller
    {
        private SrodkiContext db = new SrodkiContext();

        // GET: Amortizations
        public ActionResult Index()
        {

            return View(db.Amortization.Include(x => x.AmortizationRows).ToList());
        }

        // GET: Amortizations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Amortization amortization = db.Amortization.Find(id);
            if (amortization == null)
            {
                return HttpNotFound();
            }
            return View(amortization);
        }

        // GET: Amortizations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Amortizations/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FixedAssetsID,AmortizationValue,ModificationDate,Description")] Amortization amortization)
        {
            if (ModelState.IsValid)
            {
                amortization.ModificationDate = DateTime.Now;
                db.Amortization.Add(amortization);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(amortization);
        }

        // GET: Amortizations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Amortization amortization = db.Amortization.Find(id);
            if (amortization == null)
            {
                return HttpNotFound();
            }
            return View(amortization);
        }

        // POST: Amortizations/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FixedAssetsID,AmortizationValue,ModificationDate,Description")] Amortization amortization)
        {
            if (ModelState.IsValid)
            {   
                amortization.ModificationDate = DateTime.Now;
                db.Entry(amortization).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(amortization);
        }

        // GET: Amortizations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Amortization amortization = db.Amortization.Find(id);
            if (amortization == null)
            {
                return HttpNotFound();
            }
            return View(amortization);
        }

        // POST: Amortizations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Amortization amortization = db.Amortization.Find(id);
            db.Amortization.Remove(amortization);
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
