using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace lab5b.Controllers
{
    public class AResearchController : Controller
    {
        //GET: AA - Фильтр акции
        [AAFilter]
        public void AA()
        {
            Response.Write("AA");
        }
        public class AAFilterAttribute : FilterAttribute, IActionFilter
        {
            public void OnActionExecuted(ActionExecutedContext filterContext)
            {
                filterContext.HttpContext.Response.Write(" OnActionExecuted ");
            }

            public void OnActionExecuting(ActionExecutingContext filterContext)
            {
                filterContext.HttpContext.Response.Write(" OnActionExecuting ");
            }
        }



        // GET: AR - Фильтр результата
        [ARFilter]
        public ActionResult AR()
        {
            Response.Write("AR");
            return View();///возврат результата
        }
        public class ARFilterAttribute : FilterAttribute, IResultFilter
        {
            public void OnResultExecuted(ResultExecutedContext filterContext)
            {
                filterContext.HttpContext.Response.Write(" OnResultExecuted ");
            }

            public void OnResultExecuting(ResultExecutingContext filterContext)
            {
                filterContext.HttpContext.Response.Write(" OnResultExecuting ");
            }
        }


        // GET: AE - Фильтр исключения
        [AEFilter]
        public void AE()
        {
            StringBuilder result = new StringBuilder("AE");
            throw new Exception("My exception");
            Response.Write(result.ToString());
        }
        public class AEFilterAttribute : FilterAttribute, IExceptionFilter
        {
            public void OnException(ExceptionContext filterContext)
            {
                filterContext.HttpContext.Response.Write(" OnException ");
                ViewResult viewResult = new ViewResult();
                viewResult.ViewName = "Error";
                filterContext.Result = viewResult;
                filterContext.ExceptionHandled = true;
            }
        }

    }
}