using Newtonsoft.Json;
using PagedList;
using RestSharp;
using SrodkiTrwale.Context;
using SrodkiTrwale.Models;
using SrodkiTrwale.Models.ApiModels;
using SrodkiTrwale.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SrodkiTrwale.Controllers
{
    [Authorize]
    public class FixedAssetsController : Controller
    {
        private SrodkiContext db = new SrodkiContext();

        public FixedAssetsController()
        {

        }
        // GET: FixedAssets
        public ViewResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "Date" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;
            var fixedAssets = db.FixedAssets.Include(f => f.Categories).Include(f => f.Users);
            if (!String.IsNullOrEmpty(searchString))
            {
                fixedAssets = fixedAssets.Where(s => s.Name.Contains(searchString)
                                       || s.Users.FirstName.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    fixedAssets = fixedAssets.OrderByDescending(s => s.Name);
                    break;

                case "Date":
                    fixedAssets = fixedAssets.OrderBy(s => s.DateOfCollections);
                    break;

                case "date_desc":
                    fixedAssets = fixedAssets.OrderByDescending(s => s.DateOfCollections);
                    break;

                default:
                    fixedAssets = fixedAssets.OrderBy(s => s.Name);
                    break;
            }
            //ilosc rekordow na strone
            int pageSize = 2;
            int pageNumber = (page ?? 1);
            return View(fixedAssets.ToPagedList(pageNumber, pageSize));
        }

        // GET: FixedAssets/Details/5
        public ActionResult Details(int? id)
        {
            var amortizationFromDb = db.Amortization.Include(x => x.AmortizationRows).ToList();
            List<SelectListItem> listOfAmortization = new List<SelectListItem>();
            foreach (var item in amortizationFromDb)
            {

                listOfAmortization.Add(new SelectListItem { Text = item.AmortizationValue.ToString(), Value = item.AmortizationValue.ToString() });
            }

            var asset = db.FixedAssets.FirstOrDefault(x => x.ID == id);
            if (asset != null && !(asset.ImageUrl == null || asset.ImageUrl == ""))
            {
                FixedAssetDetailsModelView modelview1 = new FixedAssetDetailsModelView
                {
                    Categories = asset.Categories.CatTypes,
                    DateOfCollections = asset.DateOfCollections,
                    Name = asset.Name,
                    UserName = asset.Users.LastName,
                    ImageUrl = asset.ImageUrl,
                    ID = asset.ID,
                    CurrentPrice = asset.CurrentPrice,
                    ListOfAmortization = listOfAmortization

                };
                ViewBag.ImageUrl = asset.ImageUrl;
                return View(modelview1);
            }
            FixedAssetDetailsModelView modelview = new FixedAssetDetailsModelView
            {
                Categories = asset.Categories.CatTypes,
                DateOfCollections = asset.DateOfCollections,
                Name = asset.Name,
                UserName = asset.Users.LastName,
                ImageUrl = "~/Obrazki/brak.png",
                ID = asset.ID,
                CurrentPrice = asset.CurrentPrice,
                ListOfAmortization = listOfAmortization
            };
            ViewBag.ImageUrl = "~/Obrazki/brak.png";
            return View(modelview);
        }

        // GET: FixedAssets/Create
        public ActionResult Create()
        {
            ViewBag.CategoriesID = new SelectList(db.Categories, "ID", "CatTypes");
            ViewBag.UserID = new SelectList(db.Users, "ID", "FirstName");
            return View();
        }

        // POST: FixedAssets/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FixedAssetCreateModelView model)
        {
            if (ModelState.IsValid)
            {
                var asset = new FixedAssets
                {
                    CategoriesID = model.CategoriesID,
                    DateOfCollections = DateTime.Now,
                    Name = model.Name,
                    UserID = model.UserID,
                    AmortizationValue = model.AmortizationValue,
                    PurchasePrice = model.PurchasePrice,
                    CurrentPrice = model.PurchasePrice

                };

                if (model?.ImageFile?.FileName != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(model.ImageFile.FileName);
                    string extension = Path.GetExtension(model.ImageFile.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    string path = "~/Obrazki/" + fileName;
                    fileName = Path.Combine(Server.MapPath("~/Obrazki/"), fileName);
                    model.ImageFile.SaveAs(fileName);
                    asset.ImageUrl = path;
                }

               
                
                db.FixedAssets.Add(asset);
                db.SaveChanges();
                return RedirectToAction("Index");
            };

            ViewBag.CategoriesID = new SelectList(db.Categories, "ID", "CatTypes", model.CategoriesID);
            ViewBag.UserID = new SelectList(db.Users, "ID", "FirstName", model.UserID);
            return View(model);
        }

        public async Task<ActionResult> Amortize(FixedAssets fixedAsset)
        {
            var fixedAssetFromDb = await db.FixedAssets.FirstOrDefaultAsync(x => x.ID == fixedAsset.ID);
            fixedAssetFromDb.CurrentPrice = fixedAssetFromDb.CurrentPrice - (fixedAssetFromDb.CurrentPrice * fixedAsset.AmortizationValue / 100);

            db.Entry(fixedAssetFromDb).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Details/" + fixedAsset.ID);
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
            ViewBag.CategoriesID = new SelectList(db.Categories, "ID", "CatTypes", fixedAssets.CategoriesID);
            ViewBag.UserID = new SelectList(db.Users, "ID", "FirstName", fixedAssets.UserID);
            return View(fixedAssets);
        }

        // POST: FixedAssets/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CategoriesID,UserID,Name,DateOfCollections")] FixedAssets fixedAssets)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fixedAssets).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoriesID = new SelectList(db.Categories, "ID", "CatTypes", fixedAssets.CategoriesID);
            ViewBag.UserID = new SelectList(db.Users, "ID", "FirstName", fixedAssets.UserID);
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

        public ActionResult QuantityOfAssets()
        {
            var quantity = new QuantityOfAssets();
            quantity.Name = "Ilosc wszystkich: ";
            quantity.Quantity = db.FixedAssets.Count();

            return View(quantity);
        }
        public ActionResult AmortizeFixedAsset(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FixedAssets fixedAsset = db.FixedAssets.Find(id);
            if (fixedAsset == null)
            {
                return HttpNotFound();
            }
            fixedAsset.CurrentPrice = fixedAsset.PurchasePrice - (fixedAsset.PurchasePrice * fixedAsset.AmortizationValue / 100);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public async Task<string> GenerateRaport()
        {
            var httpClient = new RestClient("https://localhost:44364/api");
            var request = new RestRequest("/FixedAssets", Method.Get);
            var response = await httpClient.ExecuteAsync(request);
            return response.Content;

        }
        public async Task<ActionResult> GenerateReportForAssets()
        {
            var jsonResponse = await GenerateRaport();
            if (jsonResponse != null)
            {
                try
                {
                    var model = JsonConvert.DeserializeObject<List<FixedAssetApiModel>>(jsonResponse);
                    return View(model);
                }
                catch (Exception ex)
                {
                    return RedirectToAction("Index");
                }

            }
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