namespace ToolTracker.Models
{
    /// <summary>
    /// Stores the settings. This data is read from and written to an XML file.
    /// </summary>
    public class ToolTrackerSettings
    {
        public ToolsIssuedFormInfo FormInfo { get; set; }
        public bool SkipFirstRow { get; set; }
        public bool LeaveReceivedByOfficerBlank { get; set; }

        public ToolTrackerSettings(ToolsIssuedFormInfo formInfo, bool skipFirstRow, bool leaveReceivedByOfficerBlank)
        {
            FormInfo = formInfo;
            SkipFirstRow = skipFirstRow;
            LeaveReceivedByOfficerBlank = leaveReceivedByOfficerBlank;
        }
    }
}
