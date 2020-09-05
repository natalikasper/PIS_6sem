using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ASP2
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
                HttpWebRequest rq = (HttpWebRequest)HttpWebRequest.Create("http://localhost:49426/CJA?ParmA=aaa&ParmB=bbbb");
                rq.Method = "Get";
                HttpWebResponse response = (HttpWebResponse)rq.GetResponse();
                StreamReader rdr = new StreamReader(response.GetResponseStream());
                Response.Write(rdr.ReadToEnd());
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            HttpWebRequest rq = (HttpWebRequest)HttpWebRequest.Create("http://localhost:49426/CJA");
            rq.Method = "POST";
            rq.MaximumResponseHeadersLength = 100;
            string postData = "ParmA=aaa&ParmB=bbb";
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            rq.ContentType = "application/x-www-form-urlencoded";
            rq.ContentLength = byteArray.Length;
            Stream dataStream = rq.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();
            HttpWebResponse response = (HttpWebResponse)rq.GetResponse();
            StreamReader rdr = new StreamReader(response.GetResponseStream());
            Response.Write(rdr.ReadToEnd());
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            HttpWebRequest rq = (HttpWebRequest)HttpWebRequest.Create("http://localhost:49426/CJA");
            rq.Method = "PUT";
            rq.MaximumResponseHeadersLength = 100;
            string postData = "ParmA=aaa&ParmB=bbb";
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            rq.ContentType = "application/x-www-form-urlencoded";
            rq.ContentLength = byteArray.Length;
            Stream dataStream = rq.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();
            HttpWebResponse response = (HttpWebResponse)rq.GetResponse();
            StreamReader rdr = new StreamReader(response.GetResponseStream());
            Response.Write(rdr.ReadToEnd());
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            try
            {
                HttpWebRequest rq = (HttpWebRequest)HttpWebRequest.Create("http://localhost:49426/403");
                rq.Method = "Get";
                HttpWebResponse response = (HttpWebResponse)rq.GetResponse();
                StreamReader rdr = new StreamReader(response.GetResponseStream());
                Response.Write(rdr.ReadToEnd());
            }
            catch (WebException we)
            {
                Response.Write(we.Status);
                Response.Write("<br/>" + we.Message);
                Response.Write("<br/>" + we.TargetSite);
                Response.Write("<br/>" + we.Source);
            }
        }
    }
}