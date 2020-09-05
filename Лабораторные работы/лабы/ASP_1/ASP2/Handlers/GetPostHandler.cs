using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace ASP2.Handlers
{
    public class GetPostHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            HttpRequest request = context.Request;
            HttpResponse response = context.Response;
            if(request.HttpMethod == "GET")
            {
                response.ContentType = "text/html";
                response.Write(File.ReadAllText(Path.GetFullPath(AppDomain.CurrentDomain.BaseDirectory) + "PostXHTML.html"));
            }
            else if (request.HttpMethod == "POST")
            {
                string s = request.Params.Get("X");
                string d = request.Params.Get("Y");
                int x = 0;
                int y = 0;
                int op = 0;
                if (int.TryParse(s, out x) && int.TryParse(d, out y))
                {
                    op = x * y;
                }
                response.ContentType = "text/plain";
                response.Write(s + "*" + y + "=" + op);
            }
        }
        public bool IsReusable
        {
            get { return false; }
        }
    }
}