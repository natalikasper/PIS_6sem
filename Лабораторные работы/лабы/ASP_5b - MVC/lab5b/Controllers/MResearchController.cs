using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace lab5b.Controllers
{
    [RoutePrefix("it")]
    public class MResearchController : Controller
    {
        // GET: /it/23/catdog2

        [HttpGet]
        [Route("{n:int}/{str}")]
        public void M01B(int n, string str)
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"GET:M01:/{n}/{str}");
            result.AppendLine($"{n} - целочисленное значение;");
            result.AppendLine($"{str} - любая строка.");

            Response.Write(result.ToString());
        }
        

        // GET, POST: /it/true/house

        [AcceptVerbs("get", "post")]
        [Route("{b:bool}/{letters:alpha}")]
        public void M02(bool b, string letters)
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"{Request.HttpMethod}:M02:/{b}/{letters}");
            result.AppendLine($"{b} - булево значение;");
            result.AppendLine($"{letters} - строка из букв;");
            result.AppendLine($"{Request.HttpMethod} - метод.");
            
            Response.Write(result.ToString());
        }


        // GET, DELETE: /it/2.235/col2

        [AcceptVerbs("get", "delete")]
        [Route("{f:float}/{str:length(2,5)}")]
        public void M03(float f, string str)
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"{Request.HttpMethod}:M03:/{f}/{str}");
            result.AppendLine($"{f} - float-значение;");
            result.AppendLine($"{str} - строка (2 <= кол-во симв. <= 5);");
            result.AppendLine($"{Request.HttpMethod} - метод.");
            
            Response.Write(result.ToString());
        }


        // PUT: /it/jam/156

        [AcceptVerbs("put")]
        [Route(@"{letters:regex(^[a-zA-Z]{3,4}$)}/{n:range(100, 200)}")]
        public void M04(string letters, int n)
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"{Request.HttpMethod}:M03:/{letters}/{n}");
            result.AppendLine($"{letters} - строка из букв. 3 <= кол. симв. <= 4;");
            result.AppendLine($"{n} - целочисленное значение 100 <= n <= 200;");
            result.AppendLine($"{Request.HttpMethod} - метод.");
            
            Response.Write(result.ToString());
        }


        // POST: /it/test@mail.ru

        [AcceptVerbs("get", "post")]
        [Route(@"{mail:regex(^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$)}")]
        public void M05(string mail)
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"POST:M05:/{mail}");
            result.AppendLine($"{mail} - e-mail-адрес;");

            Response.Write(result.ToString());
        }
    }
}



/// ^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$
/// ^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$
/// ^.+@.+\..+$
/// ^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$
///^.+@.+\..{2,3}+$