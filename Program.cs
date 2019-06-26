using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using BackgroundTasksSample.Services;
using System.Threading;
using Serilog;
using System;

namespace BackgroundTasksSample
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            //try
            //{
            //    var configuration = new ConfigurationBuilder()
            //        .AddJsonFile($"appsettings.json")
            //        .Build();

            //    var logger = new LoggerConfiguration()
            //        .ReadFrom.Configuration(configuration)
            //        .CreateLogger();
            //    logger.Information("HELLO you know for log");
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine("ddddd" + ex.Message);
            //}

            var host = new HostBuilder()
                //.ConfigureLogging((hostContext, config) =>
                //{
                //    config.AddConsole();
                //    config.AddDebug();
                //})
                .ConfigureAppConfiguration((hostContext, config) =>
                {
                    config.AddEnvironmentVariables();
                    config.AddJsonFile("appsettings.json", optional: true);
                    //config.AddJsonFile($"appsettings.{hostContext.HostingEnvironment.EnvironmentName}.json", optional: true);
                    config.AddCommandLine(args);
                })
                .ConfigureServices((hostContext, services) =>
                {
                    //services.AddLogging();
                    //services.AddSingleton<MonitorLoop>();
                    #region snippet1
                    services.AddHostedService<TimedHostedService>();
                    #endregion
                    ConfigService.Configuration = hostContext.Configuration;
                })
                .UseSerilog((ctx, config) => { config.ReadFrom.Configuration(ctx.Configuration); })
                .UseConsoleLifetime()
                .Build();

            //Log.Logger = host.Services.GetRequiredService<Serilog.ILogger>();
            Log.Logger.Information("HELLO you know for logger 11111");


            using (host)
            {
                // Start the host
                await host.StartAsync();

                // Monitor for new background queue work items
                //var monitorLoop = host.Services.GetRequiredService<MonitorLoop>();
                //monitorLoop.StartMonitorLoop();

                // Wait for the host to shutdown
                await host.WaitForShutdownAsync();
            }



        }
    }
}
