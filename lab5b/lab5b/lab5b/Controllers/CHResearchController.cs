using System;
using System.Text;
using System.Web.Mvc;

namespace lab5b.Controllers
{
    public class CHResearchController : Controller
    {
        //https://localhost:44379/chresearch/ad
        // GET: AD - Cache 5 sec
        [HttpGet]
        [OutputCache(Duration = 5)]
        [Route("chresearch/ad")]
        public void AD()
        {
            StringBuilder result = new StringBuilder("AD");
            result.AppendLine(DateTime.UtcNow.ToString());
            Response.Write(result.ToString());
        }

        //postman
        // POST: AP - cache 7 sec
        [HttpPost]
        [OutputCache(Duration = 7, VaryByParam ="x; y")]
        [Route("chresearch/ap")]
        public void AP(int x, int y)
        {
            StringBuilder result = new StringBuilder("AP ");
            result.AppendLine((x + y).ToString());
            Response.Write(result.ToString());
        }
    }
}