using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Registration.Models;

namespace Registration.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(UserAccount account){
            if (ModelState.IsValid)
            {
                using (DbVirtLibContext db = new DbVirtLibContext())
                {
                    db.userAccount.Add(account);
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = account.Username + " " + "Succesfully Registered";
            }
            return View();
        }
          //Login
          public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(UserAccount user)
        {
            using (DbVirtLibContext db = new DbVirtLibContext()) {
              
                var usr = db.userAccount.Single(u => u.Username == user.Username && u.Password == user.Password);
                {
                    if (usr != null) {
                        Session["Id"] = usr.Id.ToString();
                        Session["Username"] = usr.Username.ToString();
                        return RedirectToAction("LoggedIn");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Username or Password is password is wrong".);
                    }
                }
            }
            return View();
        }

        public ActionResult LoggedIn(UserAccount user)
        {
            if (Session["Userid"] != null){
                return View();
            }
            else {
                return RedirectToAction("Login");
            }
        }
    }
}