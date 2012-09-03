using System;
using System.Web.Http;
using System.Web.Http.SelfHost;
using ContactWebPack;

namespace WebAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new HttpSelfHostConfiguration("http://localhost:9100/");

            config.Routes.MapHttpRoute("default", "{controller}/{id}", new { id = RouteParameter.Optional });
            
            foreach(var f in Formatters.Available) { config.Formatters.Add(f); }
            
            var host = new HttpSelfHostServer(config);

            host.OpenAsync().Wait();

            Console.WriteLine("Press enter to shutdown service");
            Console.ReadLine();

            host.CloseAsync().Wait();
        }
    }
}
