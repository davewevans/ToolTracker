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
    /// Interaction logic for AddShopWindow.xaml
    /// </summary>
    public partial class AddShopWindow : Window
    {
        public AddShopWindow()
        {
            InitializeComponent();

            textBoxShopName.Focus();

            textBlockStatus.Foreground = CommonUISettings.StatusColor;
            textBlockStatus.FontWeight = CommonUISettings.StatusFontWeight;
            textBlockStatus.FontSize = CommonUISettings.StatusFontSize;
        }

        private void BtnSave_OnClick(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxShopName.Text))
            {
                textBlockStatus.Text = "Please enter the shop name.";
                textBoxShopName.Focus();
                return;
            }

            var newShop = new Shop { Name = textBoxShopName.Text.Trim() };

            newShop.Name = ToolTrackerService.MakeEveryWordUppercase(newShop.Name);

            try
            {
                using (var db = new UnitOfWork())
                {
                    bool shopExists = db.ShopsRepo.Exists(s => s.Name == newShop.Name);
                    if (shopExists)
                    {
                        textBlockStatus.Text = "This shop already exists.";
                        return;
                    }
                    else
                    { // add to db and collection

                        db.ShopsRepo.Add(newShop);
                        db.Commit();
                    }
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

            ToolTrackerService.Shops.Add(newShop);

            // change text in cancel button to "I'm Finished"
            btnCancel.Content = "I'm Finished";

            // update status
            textBlockStatus.Text = $"{newShop.Name} has been added.";

            textBoxShopName.Clear();
            textBoxShopName.Focus();

            // Updates the ShopIndex prop in view models to correct combobox selection
            ToolTrackerService.UpdateIndicesAfterShopUpdate();
        }

        private void BtnCancel_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void TextBoxShopName_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            textBlockStatus.Text = "";
        }
    }
}
