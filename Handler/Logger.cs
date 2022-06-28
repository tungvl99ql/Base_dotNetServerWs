using GameServer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;
using Serilog.Events;

namespace GameServer.Handler
{
    public class Logger : IGameLogger
    {
        private readonly ILogger _logger;

        public Logger()
        {
            _logger = new LoggerConfiguration()
                 .WriteTo.Console(
                    outputTemplate:
                    "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
                .WriteTo.File("logging/log-.txt", LogEventLevel.Error, rollingInterval: RollingInterval.Day)
                .CreateLogger();
        }
        public void Error(string msg, Exception ex)
        {
            _logger.Error($"===> {ex.Message}");
        }

        public void Infor(string msg)
        {
            _logger.Information($"=== {msg}");
        }

        public void Print(string msg)
        {
            _logger.Information($"=== {msg}");
        }

        public void Warning(string msg, Exception ex)
        {
            _logger.Warning($"=== {ex.Message}");
        }
    }
}
