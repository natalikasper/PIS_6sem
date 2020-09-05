using System;
using System.ServiceModel;


namespace ASP7._3
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(WcfServiceLibrary.WCFService));
            host.Open();
            Console.WriteLine("Service Hosted Sucessfully");
            Console.Read();
        }
    }
}
