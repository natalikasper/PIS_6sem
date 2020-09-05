using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using ASP3MVC.Models;

namespace ASP7.Controllers
{
    public class TSController : ApiController
    {
        DictObjectContext context = new DictObjectContext();
        // GET: api/TS
        public IEnumerable<DictObject> Get()
        {
            return context.GetAll().OrderBy(i => i.FIO);
        }

        // POST: api/TS
        public void Post([FromBody]DictObject value)
        {
            value.Id = context.GetAll().Last().Id+1;
            context.Add(value);
        }

        // PUT: api/TS/
        public void Put([FromBody]DictObject value)
        {
            context.Update(value);
        }

        // DELETE: api/TS/
        public void Delete([FromBody]int id)
        {
            context.Delete(id);
        }
    }
}
