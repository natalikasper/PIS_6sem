using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace ASP2.Handlers
{
    public class GetHandler:IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            HttpRequest request = context.Request;
            HttpResponse response = context.Response;
            response.ContentType = "text/plain";
            response.Write("GET-Http-CJA: ParmA = "+request.Params.Get("ParmA")+", ParmB = "+request.Params.Get("ParmB"));
        }
        public bool IsReusable
        {
            get { return false; }
        }
    }
}