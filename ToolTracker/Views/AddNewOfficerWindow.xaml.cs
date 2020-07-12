using System.Windows;
using ToolTracker.Services;

namespace ToolTracker.Views
{
    /// <summary>
    /// Interaction logic for AddNewOfficerWindow.xaml
    /// </summary>
    public partial class AddNewOfficerWindow : Window
    {
        public AddNewOfficerWindow()
        {
            InitializeComponent();
        }

        private void AddNewOfficerWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            TextBoxName.Focus();
        }

        private void BtnAdd_OnClick(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TextBoxName.Text))
                Close();

            ToolTrackerService.AddOfficer(TextBoxName.Text);
            Close();
        }

        private void BtnCancel_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        
    }
}
