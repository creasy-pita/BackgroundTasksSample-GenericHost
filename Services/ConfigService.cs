using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackgroundTasksSample.Services
{
    public class ConfigService
    {
        public static IConfiguration Configuration { get; set; }
    }
}
