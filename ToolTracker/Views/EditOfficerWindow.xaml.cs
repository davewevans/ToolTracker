using System.Windows;
using ToolTracker.Services;

namespace ToolTracker.Views
{
    /// <summary>
    /// Interaction logic for EditOfficerWindow.xaml
    /// </summary>
    public partial class EditOfficerWindow : Window
    {
        public EditOfficerWindow()
        {
            InitializeComponent();
        }

        private void EditOfficerWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            TextBoxName.Focus();
            TextBoxName.Text = ToolTrackerService.Officer.Name;
        }

        private void BtnSave_OnClick(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TextBoxName.Text))
                Close();

            ToolTrackerService.EditOfficer(TextBoxName.Text);
            Close();
        }

        private void BtnCancel_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
       
    }
}
