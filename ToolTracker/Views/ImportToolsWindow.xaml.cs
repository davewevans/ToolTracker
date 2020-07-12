using System;
using System.IO;
using System.Windows;
using System.Windows.Media;
using Microsoft.Win32;
using ToolTracker.Services;

namespace ToolTracker.Views
{
    /// <summary>
    /// Interaction logic for ImportToolsWindow.xaml
    /// </summary>
    public partial class ImportToolsWindow : Window
    {
        private string _filePath;
        public ImportToolsWindow()
        {
            InitializeComponent();
        }

        private void ImportToolsWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            TextBlockStatus.Foreground = CommonUISettings.StatusColor;
            TextBlockStatus.FontWeight = CommonUISettings.StatusFontWeight;
            TextBlockStatus.FontSize = CommonUISettings.StatusFontSize;
            TextBlockStatus.Text = "Select the Excel file";
        }

        private void BtnImport_OnClick(object sender, RoutedEventArgs e)
        {
            TextBlockStatus.Text = "Please wait...";
            var importService = new ImportToolsService();
            importService.ImportTools(_filePath);
            ToolTrackerService.LoadTools();
            TextBlockStatus.Text = "Import Complete";
        }

        private void BtnBrowse_OnClick(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog();
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string initDir = System.IO.Path.Combine(baseDir, "ToolLists");
            dialog.InitialDirectory = Directory.Exists(initDir) ? initDir : baseDir;
            
            dialog.Title = "Select File";
            dialog.Filter = "Excel File (*.xls, *.xlsx, *.csv)|*.xls;*.xlsx;*.csv;" +
                            "|All Files (*.*)|*.*";
            dialog.AddExtension = true;
            dialog.RestoreDirectory = false;
            var dialogResult = dialog.ShowDialog();
            if (dialogResult != null && !dialogResult.Value) return;
            _filePath = dialog.FileName;

            if (!string.IsNullOrEmpty(_filePath))
            {
                TextBlockFileName.Text = Path.GetFileName(_filePath);
                btnImport.IsEnabled = true;
                TextBlockStatus.Text = "Click 'Import' and then please wait.";
            }

            
        }

        private void BtnClose_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
       
    }
}
