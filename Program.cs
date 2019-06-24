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
            
            var host = new HostBuilder()
                //.ConfigureLogging((hostContext, config) =>
                //{
                //    config.AddConsole();
                //    config.AddDebug();
                //})
                .ConfigureAppConfiguration((hostContext, config) =>
                {
                    config.AddEnvironmentVariables();
                    //config.AddJsonFile("appsettings.json", optional: true);
                    config.AddJsonFile($"appsettings.{hostContext.HostingEnvironment.EnvironmentName}.json", optional: true);
                    config.AddCommandLine(args);
                })
                .ConfigureServices((hostContext, services) =>
                {
                    //services.AddLogging();
                    //services.AddSingleton<MonitorLoop>();
                    Log.Logger = new LoggerConfiguration()
                        .MinimumLevel.Debug()
                        .WriteTo.RollingFile(@"Logs\log{Date}.log")
                        .CreateLogger();
                    Log.Information($"{ System.Environment.CurrentDirectory}");
                    foreach(var arg in args)
                    {
                        Log.Information($"args:{arg}");
                    }
                    #region snippet1
                    services.AddHostedService<TimedHostedService>();
                    #endregion

                    //#region snippet2
                    //services.AddHostedService<ConsumeScopedServiceHostedService>();
                    //services.AddScoped<IScopedProcessingService, ScopedProcessingService>();
                    //#endregion

                    //#region snippet3
                    //services.AddHostedService<QueuedHostedService>();
                    //services.AddSingleton<IBackgroundTaskQueue, BackgroundTaskQueue>();
                    //#endregion
                })
                .UseSerilog()
                .UseConsoleLifetime()
                .Build();

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
