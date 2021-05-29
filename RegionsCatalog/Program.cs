using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Serilog;

namespace RegionsCatalog
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ConfigureLogger();
            Log.Information("Starting application");
            try
            {
                CreateHostBuilder(args).Build().Run();
            }
            finally
            {
                Log.Information("Closing application");
                Log.CloseAndFlush();
            } 
           
        }

        public static void ConfigureLogger()
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
