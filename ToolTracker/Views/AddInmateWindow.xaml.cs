using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Core;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using ToolTracker.DAL;
using ToolTracker.Models;
using ToolTracker.Enums;
using ToolTracker.Services;
using ToolTracker.ViewModels;

namespace ToolTracker.Views
{
    /// <summary>
    /// Interaction logic for AddInmateWindow.xaml
    /// </summary>
    public partial class AddInmateWindow : Window
    {
        ObservableCollection<InmateViewModel> _inmates;

        public AddInmateWindow(ObservableCollection<InmateViewModel> inmates)
        {
            InitializeComponent();
            _inmates = inmates;
        }

        private void AddInmateWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            UpdateShopsCombobox();
            textBoxFirstName.Focus();

            textBlockStatus.Foreground = CommonUISettings.StatusColor;
            textBlockStatus.FontWeight = CommonUISettings.StatusFontWeight;
            textBlockStatus.FontSize = CommonUISettings.StatusFontSize;
        }
        
        private void UpdateShopsCombobox()
        {
            List<Shop> shops;
            using (var db = new UnitOfWork())
                shops = db.ShopsRepo.FindAll().ToList();

            shops.Insert(0, new Shop { Name = "Select Shop" });
            shops.Insert(1, new Shop { Name = "-----------------------------" });
            comboBoxShops.DisplayMemberPath = "Name";
            comboBoxShops.ItemsSource = shops;
            comboBoxShops.SelectedIndex = 0;
        }

        private void BtnSave_OnClick(object sender, RoutedEventArgs e)
        {
            var assignedShop = (Shop) comboBoxShops.SelectedItem;

            // create inmate object from data entered
            var newInmate = CreateInmateObject(assignedShop);
           
            string statusMsg = ToolTrackerService.ValidateInmateData(newInmate);
            if (AlertUserIfNotValidated(statusMsg)) return;

            newInmate.FirstName = ToolTrackerService.MakeFirstLetterUppercase(newInmate.FirstName);
            newInmate.LastName = ToolTrackerService.MakeFirstLetterUppercase(newInmate.LastName);

            // update database and collection
            try
            {
                using (var db = new UnitOfWork())
                {
                    // Used for validation but not needed here. Avoids re-adding the shop.
                    newInmate.AssignedShop = null;

                    db.InmatesRepo.Add(newInmate);
                    db.Commit();
                }
            }
            catch (EntityException ex)
            {
                ExceptionHandler.LogAndNotifyOfException(ex, ex.Message);
            }
            catch (Exception ex)
            {
                ExceptionHandler.LogAndNotifyOfException(ex, ex.Message);
            }

            ToolTrackerService.MapInmateToViewModel(newInmate);
            ToolTrackerService.SortInmates();

            // change text in cancel button to "I'm Finished"
            btnCancel.Content = "I'm Finished";

            // update status
            textBlockStatus.Text = $"{newInmate.FirstName} {newInmate.LastName} has been added.";

            ResetForm();
        }

        private Inmate CreateInmateObject(Shop assignedShop)
        {
            var newInmate = new Inmate
            {
                FirstName = textBoxFirstName.Text.Trim(),
                LastName = textBoxLastName.Text.Trim(),
                GDCNumber = textBoxGDC.Text.Trim(),
                AssignedShop = assignedShop,
                ShopId = assignedShop.Id
            };
            return newInmate;
        }

        private void ResetForm()
        {
            // reset form
            textBoxFirstName.Clear();
            textBoxFirstName.Focus();
            textBoxLastName.Clear();
            textBoxGDC.Clear();
            comboBoxShops.SelectedIndex = 0;
        }

        private bool AlertUserIfNotValidated(string statusMsg)
        {
            if (statusMsg == null) return false;
            textBlockStatus.Text = statusMsg;

            // set focus to non-validated field
            switch (ToolTrackerService.InmateValidationStatus)
            {
                case InmateValidationStatus.InvalidFirstName:
                    textBoxFirstName.Focus();
                    break;
                case InmateValidationStatus.InvalidLastName:
                    textBoxLastName.Focus();
                    break;
                case InmateValidationStatus.InvalidGDC:
                    textBoxGDC.Focus();
                    break;
            }

            return true;
        }

        private void BtnCancel_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void TextBoxFirstName_OnLostFocus(object sender, RoutedEventArgs e)
        {
            textBlockStatus.Text = string.Empty;
        }
    }
}
