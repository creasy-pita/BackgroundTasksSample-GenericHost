using Microsoft.Extensions.Configuration;
using Serilog;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackgroundTasksSample.Services
{
    public class Component
    {

        public static string GetTimerSet()
        {
            if (!string.IsNullOrEmpty(ConfigService.Configuration.GetSection("TimerSet").Value)) {
                return ConfigService.Configuration.GetSection("TimerSet").Value;
            };
            return "* */10 * * * ?";//默认10分钟1次
//#if DEBUG
//            return "*/10 * * * * ?";//默认10秒1次
//#else
//            return "* */10 * * * ?";//默认10分钟1次
//#endif
        }
    }
}
