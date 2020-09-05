using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SendPostSum
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Uri target = new Uri("http://localhost:49426/Sum");
            WebRequest request = WebRequest.Create(target);
            string postData = "X="+textBox1.Text+"&Y="+textBox2.Text;
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = byteArray.Length;
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader rdr = new StreamReader(response.GetResponseStream());
            textBox3.Text=rdr.ReadToEnd();
        }
    }
}
