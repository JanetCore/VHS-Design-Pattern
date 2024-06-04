using Serilog;

namespace VHS.Core.Logging
{
    public static class LoggingService
    {
        static LoggingService()
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();
        }

        public static ILogger Logger => Log.Logger;

        public static void ConfigureLogger(Action<LoggerConfiguration> configure)
        {
            var config = new LoggerConfiguration();
            configure(config);
            Log.Logger = config.CreateLogger();
        }
    }
}