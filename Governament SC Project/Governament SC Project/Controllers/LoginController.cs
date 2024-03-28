﻿using Governament_SC_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Governament_SC_Project.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();

        }
        GSFC_ProjectEntities db = new GSFC_ProjectEntities();
        [HttpPost]
        public ActionResult Login(Customer c)
        {
            bool userexists = db.Customers.Any(x => x.User_Name == c.User_Name && x.Password == c.Password);

        }
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Default");
        }
    }
}