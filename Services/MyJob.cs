using Quartz;
using Serilog;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BackgroundTasksSample.Services
{
    public class MyJob : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            Log.Logger.Information("MyJob  is executing ...");
            return Task.CompletedTask;
        }
    }
}
