using Governament_SC_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Governament_SC_Project.Controllers
{
    public class LoginsController : Controller
    {
        // GET: Logins
        public ActionResult Logins()
        {
            return View();
        }
        GSFC_ProjectEntities db = new GSFC_ProjectEntities();
        [HttpPost]
        public ActionResult Logins(Staff c)
        {
            bool userexists = db.Staffs.Any(x => x.User_Name == c.User_Name && x.Password == c.Password);
            Staff u = db.Staffs.FirstOrDefault(x => x.User_Name == c.User_Name && x.Password == c.Password);

            if (userexists)
            {
                FormsAuthentication.SetAuthCookie(u.User_Name, false);
                return RedirectToAction("Index", "Outlets");
            }
            return View();

        }
        public ActionResult Logouts()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Default");
        }
    }
}