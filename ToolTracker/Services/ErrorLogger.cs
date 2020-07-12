using System;
using System.Globalization;
using System.IO;
using System.Windows;

namespace ToolTracker.Services
{
    /// <summary>
    /// Logs exceptions to a text file.
    /// </summary>
    public static class ErrorLogger
    {
        const string TEXT_FILE_NAME = "ErrorLog.txt";

        public static void LogError(Exception exception)
        {
            string appFolder = AppDomain.CurrentDomain.BaseDirectory;

            string fullFilePath = Path.Combine(appFolder, TEXT_FILE_NAME);

            try
            {
                using (var fs = new FileStream(fullFilePath, FileMode.Append, FileAccess.Write))
                using (var writer = new StreamWriter(fs))
                {
                    writer.WriteLine(DateTime.Now.ToString(CultureInfo.CurrentCulture));
                    writer.WriteLine("Message: " + exception.Message);
                    writer.WriteLine("Inner Exception: " + exception.InnerException);
                    writer.WriteLine("Stack Trace:");
                    writer.WriteLine(exception.StackTrace);
                    writer.WriteLine();
                    writer.WriteLine();
                }
            }
            catch (IOException ex)
            {
                MessageBox.Show("Unable to log error: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to log error: " + ex.Message);
            }

        }
    }
}
