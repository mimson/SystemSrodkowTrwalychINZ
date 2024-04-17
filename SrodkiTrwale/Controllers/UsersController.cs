using SrodkiTrwale.Context;
using SrodkiTrwale.Models;
using SrodkiTrwale.Models.ViewModel;
using SrodkiTrwale.Services;
using System;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using System.Web.Security;

namespace SrodkiTrwale.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class UsersController : Controller
    {
        private SrodkiContext db;

        public UsersController()
        {
            db = new SrodkiContext();
        }

        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginViewModel view, string returnUrl)
        {
            var dataItem = db.Users.FirstOrDefault(x => x.Mail.Equals(view.Email) && x.Password.Equals(view.Password));
            if (dataItem != null)
            {
                FormsAuthentication.SetAuthCookie(dataItem.Mail, false);
                if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                    && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                {
                    return Redirect(returnUrl);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                ModelState.AddModelError("", "Invalid user/pass");
                return View();
            }
        }

        public ActionResult Create(Users user)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
               

                var user = new Users
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Mail = model.Mail,
                    Password = model.Password,
                    UserRolesID = model.UserRolesID
                };

                if (model?.ImageFile?.FileName != null)
                { 
                string fileName = Path.GetFileNameWithoutExtension(model.ImageFile.FileName);
                string extension = Path.GetExtension(model.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                string path = "~/Obrazki/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Obrazki/"), fileName);
                model.ImageFile.SaveAs(fileName);
                }

                db.Users.Add(user);
                db.SaveChanges();
                MailService service = new MailService();
                service.SendMail(model.Mail, "Twoj login i hasło to: " + model.Mail + ", " + model.Password);
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Details(int id)
        {
            var user = db.Users.FirstOrDefault(x => x.ID == id);
            if (!(user.ImageUrl == null || user.ImageUrl == ""))
            {
                UserDetailsModelView modelview1 = new UserDetailsModelView
                {
                    FirstName = user.FirstName,
                    ImageUrl = user.ImageUrl,
                    LastName = user.LastName,
                    Mail = user.Mail,
                    Password = user.Password,
                    ID = user.ID
                };
                ViewBag.ImageUrl = user.ImageUrl;
                return View(modelview1);
            }
            UserDetailsModelView modelview = new UserDetailsModelView
            {
                FirstName = user.FirstName,
                ImageUrl = "~/Obrazki/brak.png",
                LastName = user.LastName,
                Mail = user.Mail,
                Password = user.Password,
                ID = user.ID
            };
            ViewBag.ImageUrl = "~/Obrazki/brak.png";
            return View(modelview);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Users user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Amortizations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Users user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Users user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            UserEditViewModel modelview = new UserEditViewModel
            {
                Id = user.ID,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Mail = user.Mail,
                Password = user.Password,
                UserRolesID = user.UserRolesID
            };
            return View(modelview);
        }

        // POST: FixedAssets/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserEditViewModel model)
        {
            string fileName = Path.GetFileNameWithoutExtension(model.ImageFile?.FileName);
            string extension = Path.GetExtension(model.ImageFile?.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            string path = "~/Obrazki/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Obrazki/"), fileName);
            model.ImageFile?.SaveAs(fileName);
            var user = new Users
            {
                ID = model.Id,
                FirstName = model.FirstName,
                ImageUrl = path,
                LastName = model.LastName,
                Mail = model.Mail,
                Password = model.Password,
                UserRolesID = model.UserRolesID
            };
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);
        }






        //akcja do usuniecia ciasteczka sesji
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            //Przekierowanie do akcji Index w kontrolerze Home
            return RedirectToAction("Index", "Home");
        }
    }
}