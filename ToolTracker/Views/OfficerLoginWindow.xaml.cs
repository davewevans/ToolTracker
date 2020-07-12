using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using ToolTracker.Models;
using ToolTracker.Services;

namespace ToolTracker.Views
{
    /// <summary>
    /// Interaction logic for OfficerLoginWindow.xaml
    /// </summary>
    public partial class OfficerLoginWindow : Window
    {
        public OfficerLoginWindow()
        {
            InitializeComponent();
        }

        private void OfficerLoginWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            ToolTrackerService.Officers = new ObservableCollection<Officer>();
            ToolTrackerService.LoadOfficers();
            ListBoxNames.ItemsSource = ToolTrackerService.Officers;
            ListBoxNames.DisplayMemberPath = "Name";
        }

        private void BtnLogin_OnClick(object sender, RoutedEventArgs e)
        {
            ToolTrackerService.Officer = (Officer)ListBoxNames.SelectedItem;
            var window = new MainWindow();
            window.Show();
            Close();
        }

        private void BtnAddOfficer_OnClick(object sender, RoutedEventArgs e)
        {
            var window = new AddNewOfficerWindow();
            window.ShowDialog();
        }

        private void BtnClose_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ListBoxNames_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ToolTrackerService.Officer = (Officer)ListBoxNames.SelectedItem;
        }

        private void BtnEditOfficer_OnClick(object sender, RoutedEventArgs e)
        {
            if (ListBoxNames.SelectedIndex == -1)
            {
                NotifyUser.SomethingIsMissing("Please select a name", "No Name Selected");
                return;
            }

            var window = new EditOfficerWindow();
            window.ShowDialog();
        }
    }
}
