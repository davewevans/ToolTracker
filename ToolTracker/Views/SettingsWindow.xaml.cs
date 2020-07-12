using System;
using System.Windows;
using System.Windows.Media;
using ToolTracker.Models;
using ToolTracker.Services;

namespace ToolTracker.Views
{
    /// <summary>
    /// Interaction logic for SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        public SettingsWindow()
        {
            InitializeComponent();
        }

        private void SettingsWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            TextBlockStatus.Foreground = CommonUISettings.StatusColor;
            TextBlockStatus.FontWeight = CommonUISettings.StatusFontWeight;
            TextBlockStatus.FontSize = CommonUISettings.StatusFontSize;

            SetValuesFromSettings();
        }

        private void SetValuesFromSettings()
        {
            TextBoxFormNumber.Text = SettingsService.Settings.FormInfo.Line1;
            TextBoxFormInfoLine2.Text = SettingsService.Settings.FormInfo.Line2;
            TextBoxFormDate.Text = SettingsService.Settings.FormInfo.Line3;
            CheckBoxSkipRow.IsChecked = SettingsService.Settings.SkipFirstRow;
            CheckBoxLeaveReceivedByBlank.IsChecked = SettingsService.Settings.LeaveReceivedByOfficerBlank;
        }

        private void BtnSave_OnClick(object sender, RoutedEventArgs e)
        {
            var formInfo = new ToolsIssuedFormInfo
            {
                Line1 = TextBoxFormNumber.Text,
                Line2 = TextBoxFormInfoLine2.Text,
                Line3 = TextBoxFormDate.Text
            };

            SettingsService.Settings.FormInfo = formInfo;
            SettingsService.Settings.SkipFirstRow = CheckBoxSkipRow.IsChecked == null || Convert.ToBoolean(CheckBoxSkipRow.IsChecked);
            SettingsService.Settings.LeaveReceivedByOfficerBlank = CheckBoxLeaveReceivedByBlank.IsChecked == null || Convert.ToBoolean(CheckBoxLeaveReceivedByBlank.IsChecked);

            SettingsService.WriteSettingsXml();

            TextBlockStatus.Text = "The new settings have been changed.";
            btnCancel.Content = "Close";
        }

        private void BtnRestore_OnClick(object sender, RoutedEventArgs e)
        {
            SettingsService.GetDefaultSettings();
            SettingsService.WriteSettingsXml();
            SetValuesFromSettings();

            TextBlockStatus.Text = "The default settings have been restored.";
            btnCancel.Content = "Close";
        }
        private void BtnCancel_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        
    }
}
