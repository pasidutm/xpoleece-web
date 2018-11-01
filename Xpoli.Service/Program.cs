using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace ListingService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var step1 = CreateWebHostBuilder(args);
            var step2 = step1.Build();
            step2.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args).UseStartup<Startup>(); //Can specify the start up logic 
            //asp.net will instantiate this class and invoke 2 methods.
            //1. Configure service, which can register services, that can be injected to other components 
            //2. Configure methods, calls onces, you can configure the middle ware
        }
    }
}
