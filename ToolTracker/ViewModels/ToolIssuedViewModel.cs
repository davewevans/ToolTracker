using System;
using ToolTracker.Models;

namespace ToolTracker.ViewModels
{
    public class ToolIssuedViewModel
    {
        public string ToolNumber { get; set; }

        public string ToolDescription { get; set; }
       
        public DateTime DateTimeOut { get; set; }

        public DateTime? DateTimeIn { get; set; }

        public Shop Shop { get; set; }

        public string ReceivedByInmateFirstName { get; set; }

        public string ReceivedByInmateLastName { get; set; }

        public string ReceivedByInmateNumber { get; set; }

        public string DateTimeOutStr => DateTimeOut.ToString("MM-dd-yy HHmm");
        public string DateTimeInStr => DateTimeIn != null ? DateTimeIn?.ToString("MM-dd-yy HHmm") : "";

        public string DateOut => DateTimeOut.ToString("MM-dd-yy");
        public string DateIn => DateTimeIn?.ToString("MM-dd-yy") ?? "";
        public string TimeOut => DateTimeOut.ToString("HHmm");
        public string TimeIn => DateTimeIn?.ToString("HHmm");
      
        public string ReceivedByInmateDisplayName 
            => $"{GetInitial(ReceivedByInmateFirstName)} {ReceivedByInmateLastName}";

        public string ReturnedByInmateDisplayName 
            => $"{GetInitial(ReturnedByInmateFirstName)} {ReturnedByInmateLastName}";

        public string IssuedByName { get; set; }

        public string ReturnedByInmateFirstName { get; set; }

        public string ReturnedByInmateLastName { get; set; }

        public string ReturnedByInmateNumber { get; set; }

        public string ReceivedByName { get; set; }

        private static string GetInitial(string name)
        {
            return name != null ? $"{name.Substring(0, 1)}." : "";
        }
    }
}
