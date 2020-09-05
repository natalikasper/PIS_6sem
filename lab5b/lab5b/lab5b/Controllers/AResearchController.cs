using System;
using System.Text;
using System.Web.Mvc;

namespace lab5b.Controllers
{
    public class AResearchController : Controller
    {
        //https://localhost:44379/aresearch/aa
        //GET: AA - Фильтр экшена
        [AAFilter]
        [Route("aresearch/aa")]
        public void AA()
        {
            StringBuilder result = new StringBuilder("AA");
            Response.Write(result.ToString());
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


        //https://localhost:44379/aresearch/ar
        // GET: AR - Фильтр результата
        [ARFilter]
        [Route("aresearch/ar")]
        public ActionResult AR()
        {
            StringBuilder result = new StringBuilder("AR");
            Response.Write(result.ToString());
            return View();//возврат результата
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

        //https://localhost:44379/aresearch/ae
        // GET: AE - Фильтр исключения
        [AEFilter]
        [Route("aresearch/ae")]
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