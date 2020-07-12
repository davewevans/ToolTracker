using System;
using System.Xml;
using ToolTracker.Models;
using System.IO;
using System.Xml.Linq;

namespace ToolTracker.Services
{
    public static class SettingsService
    {
        private const string XmlFileName = "Settings.xml";

        public static ToolTrackerSettings Settings { get; set; }

        public static void GetDefaultSettings()
        {
            var formInfo = new ToolsIssuedFormInfo
                {
                    Line1 = "GDC-SOP IIB01-0002(218.02)",
                    Line2 = "ATTACHMENT 1",
                    Line3 = "07/10/15"
                };
            Settings = new ToolTrackerSettings(formInfo, true, true);
        }

        public static void ReadXmlSettings()
        {
            string xmlFilePath = GetXmlFilePath();
            if (!File.Exists(xmlFilePath))
            {
                GetDefaultSettings();
                WriteSettingsXml();
            }

            var xDoc = XDocument.Load(GetXmlFilePath());
            var startElement = xDoc.Element("ToolTrackerSettings");
            if (startElement == null) return;
            var element = startElement?.Element("FormSettings");
            
            var formInfoLine1XName = XName.Get("FormInfoLine1");
            var formInfoLine2XName = XName.Get("FormInfoLine2");
            var formInfoLine3XName = XName.Get("FormInfoLine3");
            var skipFirstRowXName = XName.Get("SkipFirstRow");
            var leaveReceivedByOfficerBlankXName = XName.Get("LeaveReceivedByOfficerBlank");
            
            if (element == null) return;
            var formInfoLine1 = element.Element(formInfoLine1XName);
            var formInfoLine2 = element.Element(formInfoLine2XName);
            var formInfoLine3 = element.Element(formInfoLine3XName);
            var skipFirstRow = element.Element(skipFirstRowXName);
            var leaveReceivedByOfficerBlank = element.Element(leaveReceivedByOfficerBlankXName);

            var formInfo = new ToolsIssuedFormInfo
            {
                Line1 = formInfoLine1?.Value,
                Line2 = formInfoLine2?.Value,
                Line3 = formInfoLine3?.Value,
            };

            bool skipFirstRowBool = skipFirstRow == null || Convert.ToBoolean(skipFirstRow.Value);
            bool leaveReceivedByOfficerBlankBool = leaveReceivedByOfficerBlank == null || Convert.ToBoolean(leaveReceivedByOfficerBlank.Value);

            Settings = new ToolTrackerSettings(formInfo, skipFirstRowBool, leaveReceivedByOfficerBlankBool);
        }

        public static void WriteSettingsXml()
        {
            var xmlSettings = new XmlWriterSettings { Indent = true };

            if (Settings == null) GetDefaultSettings();

            string filePath = GetXmlFilePath();

            using (var writer = XmlWriter.Create(filePath, xmlSettings))
            {
                writer.WriteStartElement("ToolTrackerSettings");

                var xElement = new XElement("FormSettings",
                    new XElement("FormInfoLine1", Settings?.FormInfo.Line1),
                    new XElement("FormInfoLine2", Settings?.FormInfo.Line2),
                    new XElement("FormInfoLine3", Settings?.FormInfo.Line3),
                    new XElement("SkipFirstRow", Settings?.SkipFirstRow),
                    new XElement("LeaveReceivedByOfficerBlank", Settings?.LeaveReceivedByOfficerBlank));

                xElement.WriteTo(writer);
                writer.WriteEndElement();
            }
        }

        private static string GetXmlFilePath()
        {
            var baseDir = AppDomain.CurrentDomain.BaseDirectory;
            return Path.Combine(baseDir, XmlFileName);
        }
    }
}
