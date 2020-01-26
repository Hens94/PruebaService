using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PruebaService_Common.Extensions;
using Serilog;
using Serilog.Events;

namespace PruebaService_Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder
                        .UseStartup<Startup>()
                        .UseSerilog((hostingContext, loggerConfiguration) => loggerConfiguration
                            .UseIf(
                                hostingContext.HostingEnvironment.IsProduction(),
                                config => config
                                    .MinimumLevel.Warning(),
                                config => config
                                    .MinimumLevel.Debug()
                                    .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                            )
                            .Enrich.FromLogContext()
                            .WriteTo.Console()
                            .WriteTo.File($"log\\{hostingContext.HostingEnvironment.ApplicationName}_.txt", rollingInterval: RollingInterval.Day));
                });
    }
}
