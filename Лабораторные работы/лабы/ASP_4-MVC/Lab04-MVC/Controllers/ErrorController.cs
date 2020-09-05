using System.Web.Mvc;

namespace Lab04_MVC.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult NotFound()
        {
            ActionResult result;

            if (!Request.IsAjaxRequest())
                result = View(Request);
            else
                result = PartialView("_NotFound", Request);

            return result;
        }
    }
}