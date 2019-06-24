using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Oracle.ManagedDataAccess.Client;

namespace BackgroundTasksSample.Services
{
    #region snippet1
    internal class TimedHostedService : IHostedService, IDisposable
    {
        private readonly ILogger _logger;
        private Timer _timer;

        public TimedHostedService(ILogger<TimedHostedService> logger)
        {
            _logger = logger;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Timed Background Service is starting.");

            _timer = new Timer(DoWork, null, TimeSpan.Zero, 
                TimeSpan.FromSeconds(10));

            return Task.CompletedTask;
        }

        private void DoWork(object state)
        {
            string conString = "Data Source=192.168.5.200:1521/kfhzbdc;User Id=sjgj;Password=sjgj;";
            using (OracleConnection con = new OracleConnection(conString))
            {
                con.Open();
                using (OracleCommand comm = new OracleCommand()) {
                    //comm.CommandText = "select * from bdcqz where rownum<5";
                    comm.CommandText = "select count(1) from bdcqz";
                    comm.CommandType = System.Data.CommandType.Text;
                    comm.Connection = con;
                    OracleDataReader reader = comm.ExecuteReader();
                    while (reader.Read())
                    {
                        _logger.LogInformation($"bdcqz {reader.GetInt32(0)}");
                    }
                }
            }
            //OracleConnection 
            Serilog.Log.Information("Timed Background Service is working11.");
            _logger.LogInformation("Timed Background Service is working.");
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Timed Background Service is stopping.");

            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
    #endregion
}
