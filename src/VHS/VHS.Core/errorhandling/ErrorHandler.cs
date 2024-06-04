using Serilog;
using VHS.Core.Logging;
using System;

namespace VHS.Core.ErrorHandling
{
    public static class ErrorHandler
    {
        public static void HandleError(Exception ex)
        {
            // Log the error using the shared logger
            LoggingService.Logger.Error(ex, "An error occurred");

            // Additional actions can be added here
        }

        public static void HandleError(string customMessage, Exception ex)
        {
            // Log the custom error message along with exception details
            LoggingService.Logger.Error(ex, customMessage);

            // Additional actions can be added here
        }
    }
}