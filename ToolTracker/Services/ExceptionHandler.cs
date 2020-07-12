using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolTracker.Views;

namespace ToolTracker.Services
{
    /// <summary>
    /// Handles exceptions by logging it and notifying user.
    /// </summary>
    static class ExceptionHandler
    {
        public static void LogAndNotifyOfException(Exception ex, string message)
        {
            ErrorLogger.LogError(ex);
            var window = new NotifyExceptionWindow(ex, message);
            window.Show();
        }
    }
}
