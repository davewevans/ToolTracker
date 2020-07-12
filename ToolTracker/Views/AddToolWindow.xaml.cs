using System;
using System.Data.Entity.Core;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using ToolTracker.DAL;
using ToolTracker.Models;
using ToolTracker.Services;

namespace ToolTracker.Views
{
    /// <summary>
    /// Interaction logic for AddToolWindow.xaml
    /// </summary>
    public partial class AddToolWindow : Window
    {
        public AddToolWindow()
        {
            InitializeComponent();
        }

        private void AddToolWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            ToolTrackerService.UpdateShopsCombobox(ComboBoxShops);

            textBlockStatus.Foreground = CommonUISettings.StatusColor;
            textBlockStatus.FontWeight = CommonUISettings.StatusFontWeight;
            textBlockStatus.FontSize = CommonUISettings.StatusFontSize;

            textBoxToolNo.Focus();
        }

        private void BtnCancel_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnSave_OnClick(object sender, RoutedEventArgs e)
        {
            TextBlockStatus.Text = "";

            // Validate tool
            if (ValidateToolData()) return;

            // Persist update to db
            using (var db = new UnitOfWork())
            {
                try
                {
                    var newTool = new Tool
                    {
                        ToolNumber = textBoxToolNo.Text.Trim(),
                        Description = ToolTrackerService.MakeEveryWordUppercase(textBoxToolDesc.Text.Trim())
                    };

                    var toolNoExists = db.ToolsRepo.Exists(t => t.ToolNumber.Equals(newTool.ToolNumber));
                    if (toolNoExists)
                    {
                        TextBlockStatus.Text = "Tool number already exists.";
                        textBoxToolNo.Focus();
                        return;
                    }

                    var shop = (Shop)ComboBoxShops.SelectedItem;
                    newTool.ShopId = shop.Id;

                    db.ToolsRepo.Add(newTool);
                    db.Commit();

                    // Update observable collection
                    ToolTrackerService.MapToolToViewModel(newTool);
                    ToolTrackerService.SortTools();
                    
                    TextBlockStatus.Text = $"{newTool.ToolNumber} added successfully.";
                }
                catch (EntityException ex)
                {
                    ExceptionHandler.LogAndNotifyOfException(ex, ex.Message);
                }
                catch (Exception ex)
                {
                    ExceptionHandler.LogAndNotifyOfException(ex, ex.Message);
                }

                btnCancel.Content = "I'm Finished";
                ResetForm();
            }
        }

        private bool ValidateToolData()
        {
            if (string.IsNullOrEmpty(textBoxToolNo.Text))
            {
                TextBlockStatus.Text = "Please enter a tool number.";
                textBoxToolNo.Focus();
                return true;
            }
            if (string.IsNullOrEmpty(textBoxToolDesc.Text))
            {
                TextBlockStatus.Text = "Please enter a tool description.";
                textBoxToolDesc.Focus();
                return true;
            }
            if (ComboBoxShops.SelectedIndex <= 0)
            {
                TextBlockStatus.Text = "Please select a shop.";
                return true;
            }
            return false;
        }

        private void ResetForm()
        {
            TextBlockStatus.Text = "";
            textBoxToolNo.Clear();
            textBoxToolDesc.Clear();
            textBoxToolNo.Focus();
        }

        private void ComboBoxShops_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TextBlockStatus.Text = "";
        }

        private void textBoxToolID_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBlockStatus.Text = "";
        }

        private void textBoxToolDesc_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBlockStatus.Text = "";
        }
    }
}
