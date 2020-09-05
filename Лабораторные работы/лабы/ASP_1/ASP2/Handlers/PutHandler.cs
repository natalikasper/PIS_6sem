using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP2.Handlers
{
    public class PutHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            HttpRequest request = context.Request;
            HttpResponse response = context.Response;
            response.ContentType = "text/plain";
            response.Write("Put-Http-CJA: ParmA = " + request.Params.Get("ParmA") + ", ParmB = " + request.Params.Get("ParmB"));
        }
        public bool IsReusable
        {
            get { return false; }
        }
    }
}