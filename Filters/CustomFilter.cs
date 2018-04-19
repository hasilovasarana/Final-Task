using crm_system.Controllers;
using System.Web.Mvc;
using crm_system.Models;
namespace crm_system.Filters
{
    public class CustomFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (System.Web.HttpContext.Current.Session["Username"] == null|| System.Web.HttpContext.Current.Session["Password"]==null)
            {
                filterContext.Result = new RedirectResult("/Login/Index");
                return;
            }
            if (System.Web.HttpContext.Current.Session["Username"].ToString() !=LoginController.loginned_admin.admin_username && System.Web.HttpContext.Current.Session["Username"].ToString() != LoginController.loginned_admin.admin_password)
            {
                filterContext.Result = new RedirectResult("/Login/Index");
                return;
            }

            base.OnActionExecuting(filterContext);
        }
         
    }
}