using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP2.Handlers
{
    public class PostSumHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            HttpRequest request = context.Request;
            HttpResponse response = context.Response;
            string s = request.Params.Get("X");
            string d = request.Params.Get("Y");
            int x = 0;
            int y = 0;
            int sum = 0;
            if (int.TryParse(s, out x) && int.TryParse(d, out y))
            {
                sum = x + y;
            }
            response.ContentType = "text/plain";
            response.Write(s + "+" + y + "=" + sum);
        }
        public bool IsReusable
        {
            get { return false; }
        }
    }
}