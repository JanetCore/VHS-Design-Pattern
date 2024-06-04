using Serilog;
using System;

namespace VHS.Core.ErrorHandling
{
    public static class ErrorHandler
    {
        static ErrorHandler()
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();
        }

        public static void HandleError(Exception ex)
        {
            // Log the error with Serilog
            Log.Error(ex, "An error occurred");

            // Additional actions can be added here
        }

        public static void HandleError(string customMessage, Exception ex)
        {
            // Log the custom error message along with exception details
            Log.Error(ex, customMessage);

            // Additional actions can be added here
        }
    }
}