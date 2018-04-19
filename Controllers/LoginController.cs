using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using crm_system.Models;

namespace crm_system.Controllers
{
    public class LoginController : Controller
    {
        public static Admin loginned_admin { get; set; }
        //public static Admin change_password;

        CRMEntities db = new CRMEntities();
        [HttpGet]
        // GET: Login
        public ActionResult Index()
        {
            return View();
            
        }
        [HttpPost]
       
        public ActionResult Index(Admin admin)
        {
            loginned_admin = db.Admins.FirstOrDefault(a=>a.admin_username==admin.admin_username&& a.admin_password==admin.admin_password);
            if (loginned_admin != null)
            {
               
                Session["Username"] = loginned_admin.admin_username;
                Session["Password"] = loginned_admin.admin_password;
                return RedirectToAction("Index","Dashboard");
            }
            else
            {
                return RedirectToAction("Index");
            }      
         
        }

        [HttpGet]
        public ActionResult LogOut()
        {
            Session["Username"] = null;
            Session["Password"] = null;
            loginned_admin = null;
            return RedirectToAction("Index", "Login"); 
        }
        
        [HttpGet]
        public ActionResult Change_Password()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Change_Password(Admin _admin)
        {
            //
            Admin changePassword = db.Admins.Where(c => c.admin_id == loginned_admin.admin_id).FirstOrDefault();
            changePassword.admin_password = _admin.admin_new_psw;
            Session["Password"] = loginned_admin.admin_password; 
            db.SaveChanges();
            return View();          
     

        }

    }
}