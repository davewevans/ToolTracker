using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using ToolTracker.DAL;
using ToolTracker.Models;
using ToolTracker.Interfaces;
using ToolTracker.Printing;
using ToolTracker.Services;
using ToolTracker.ViewModels;
using ToolTracker.Views;
using Button = System.Windows.Controls.Button;
using CheckBox = System.Windows.Controls.CheckBox;
using ComboBox = System.Windows.Controls.ComboBox;
using Xceed.Wpf.Toolkit;

namespace ToolTracker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static BackgroundWorker backgroundWorkerLoad;
        private static BackgroundWorker backgroundWorkerUpdateToolIssued;

        private Queue<int> _toolsCheckedOutNext;
        private Queue<int> _toolsCheckedOutBack;

        // Used for check out/in background worker event handlers
        private bool _isOnChecked;
        private ToolIssued _newToolIssued;
        private Inmate _selectedInmate;
        private CheckToolOutInViewModel _checkOutInTool;
        private CheckBox _checkBox;

        //private BusyIndicator _busyIndicator;
        private int _counter = 0;

        delegate void LoadItemSourcesDelegate();
        delegate void ShowMessageDelegate();
        delegate void LoadingAnimationDelegate();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            //StartLoaderAnimation();

            if (ToolTrackerService.Officer == null)
            {
                NotifyUser.Inform("An officer must be logged in.", "Officer Not Logged In");
                Environment.Exit(0);
            }

            #region Seed database
            //var seeder = new TestDataSeeder();

            //seeder.WipeOutData();
            //seeder.SeedShops();
            //seeder.SeedInmates();
            #endregion

            _toolsCheckedOutNext = new Queue<int>();
            _toolsCheckedOutBack = new Queue<int>();

            UpdateCheckedOutTotal(ToolTrackerService.GetCheckedOutTotal());

            TextBlockLoggedInName.Text = ToolTrackerService.Officer.Name;

            ToolTrackerService.Inmates = new ObservableCollection<InmateViewModel>();
            ToolTrackerService.Shops = new ObservableCollection<Shop>();
            ToolTrackerService.Tools = new ObservableCollection<ToolViewModel>();
            ToolTrackerService.CheckOutInTools = new ObservableCollection<CheckToolOutInViewModel>();
            ToolTrackerService.ToolsIssued = new ObservableCollection<ToolIssuedViewModel>();


            ToolTrackerService.UpdateShopsCombobox(comboBoxShops);
            ToolTrackerService.UpdateShopsCombobox(comboBoxShopsToolsIssued);
            UpdateToolsListBox();

            backgroundWorkerLoad = new BackgroundWorker();
            backgroundWorkerLoad.DoWork += BackgroundWorkerLoad_DoWork;
            backgroundWorkerLoad.RunWorkerCompleted += BackgroundWorkerLoad_RunWorkerCompleted;

            _busyIndicator.IsBusy = true;
            backgroundWorkerLoad.RunWorkerAsync();

            DatePickerDate.SelectedDate = DateTime.Today;

            SettingsService.ReadXmlSettings();
            //StopLoaderAnimation();

        }

        private void BackgroundWorkerLoad_DoWork(object sender, DoWorkEventArgs e)
        {
            ToolTrackerService.LoadInmates();
            ToolTrackerService.LoadShops();
            ToolTrackerService.LoadTools();
        }

        private void BackgroundWorkerLoad_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            listBoxUpdateInmates.ItemsSource = ToolTrackerService.Inmates;
            listBoxUpdateShops.ItemsSource = ToolTrackerService.Shops;
            listBoxUpdateTools.ItemsSource = ToolTrackerService.Tools;
            _busyIndicator.IsBusy = false;         
        }

        private void ListViewToolsCheckInOut_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        #region combo box event handlers

        private void ComboBoxShops_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBoxShops.SelectedIndex < 1)
            {
                comboBoxInmates.SelectedIndex = 0;
                comboBoxInmates.IsEnabled = false;
                return;
            }

            comboBoxInmates.IsEnabled = true;
            var shop = (Shop)comboBoxShops.SelectedItem;
            ToolTrackerService.SelectedShopId = shop.Id;
            UpdateInmatesCombobox(shop);

            ToolTrackerService.CheckOutInTools.Clear();
        }

        private void ComboBoxInmates_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateToolsCheckedOutIn();
        }

        private void ComboBoxAssignedShops_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var cmbBox = (ComboBox)sender;
            int inmateId = (int)cmbBox.Tag;

            // Get Inmate object from collection
            var inmate = ToolTrackerService.Inmates.FirstOrDefault(i => i.Id == inmateId);

            if (inmate != null)
                inmate.AssignedShop = (Shop)cmbBox.SelectedItem;
        }

        private void ComboBoxShopsForTools_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var cmbBox = (ComboBox)sender;
            int toolId = (int)cmbBox.Tag;

            var tool = ToolTrackerService.Tools.FirstOrDefault(t => t.Id == toolId);

            if (tool != null)
            {
                tool.AssignedShop = (Shop)cmbBox.SelectedItem;
            }


        }

        #endregion

        #region button event handlers

        private void BtnToolNoSearch_OnClick(object sender, RoutedEventArgs e)
        {
            FindToolCheckedOutInByToolNo();
        }

        private void BtnPrint_OnClick(object sender, RoutedEventArgs e)
        {
            if (comboBoxShopsToolsIssued.SelectedIndex < 1) return;
            var shop = (Shop)comboBoxShopsToolsIssued.SelectedItem;

            PrintingService.PrintToolsIssued(shop);
        }

        private void BtnSaveUpdateInmate_OnClick(object sender, RoutedEventArgs e)
        {

            var btn = (Button)sender;

            // Tag attribute on button is bound to Id
            int inmateId = (int)btn.Tag;

            // Get Inmate object from collection
            var inmate = ToolTrackerService.Inmates.SingleOrDefault(i => i.Id == inmateId);

            var result = NotifyUser.AskToConfirm("Are you sure you want to save?", "Confirm Update");
            if (result != System.Windows.Forms.DialogResult.Yes) return;

            if (inmate != null && inmate.AssignedShop == null)
                inmate.AssignedShop = ToolTrackerService.Shops.FirstOrDefault(s => s.Id == inmate.ShopId);

            string statusMsg = ToolTrackerService.ValidateInmateData(inmate);
            if (statusMsg != null)
            {
                NotifyUser.InvalidEntry(statusMsg, "Invalid Entry");
                return;
            }


            // Ensure first letter is uppercase
            if (inmate != null)
            {
                inmate.FirstName = ToolTrackerService.MakeFirstLetterUppercase(inmate.FirstName);
                inmate.LastName = ToolTrackerService.MakeFirstLetterUppercase(inmate.LastName);
            }


            UpdateInmate(inmate);
        }

        private void BtnDeleteInmate_OnClick(object sender, RoutedEventArgs e)
        {
            var btn = (Button)sender;
            int inmateId = (int)btn.Tag;

            var inmateToDel = ToolTrackerService.Inmates.FirstOrDefault(i => i.Id == inmateId);

            var result =
                NotifyUser.AskToConfirm($"Are you absolutely positive you want to delete {inmateToDel?.LastName}?",
                    "Confirm Delete");
            if (result != System.Windows.Forms.DialogResult.Yes) return;

            // Remove from db
            using (var db = new UnitOfWork())
            {
                try
                {
                    var inmate = db.InmatesRepo.FindById(inmateId);
                    db.InmatesRepo.Delete(inmate);
                    db.Commit();
                }
                catch (EntityException ex)
                {
                    ExceptionHandler.LogAndNotifyOfException(ex, ex.Message);
                }
                catch (Exception ex)
                {
                    ExceptionHandler.LogAndNotifyOfException(ex, ex.Message);
                }

            }

            // Remove from collection
            var inmateVM = ToolTrackerService.Inmates.SingleOrDefault(i => i.Id == inmateId);
            ToolTrackerService.Inmates.Remove(inmateVM);
        }

        private void BtnAddInmate_OnClick(object sender, RoutedEventArgs e)
        {
            var window = new AddInmateWindow(ToolTrackerService.Inmates);
            window.ShowDialog();
        }

        private void BtnSaveUpdateShop_OnClick(object sender, RoutedEventArgs e)
        {
            var btn = (Button)sender;

            // Tag attribute on button is bound to Id
            int shopId = (int)btn.Tag;

            // Get Inmate object from collection
            var shop = ToolTrackerService.Shops.SingleOrDefault(i => i.Id == shopId);

            var result = NotifyUser.AskToConfirm("Are you sure you want to save?", "Confirm Update");
            if (result != System.Windows.Forms.DialogResult.Yes) return;

            if (string.IsNullOrEmpty(shop?.Name))
            {
                NotifyUser.InvalidEntry("Please enter the new shop name", "Invalid Entry");
                return;
            }

            shop.Name = ToolTrackerService.MakeEveryWordUppercase(shop.Name);
            UpdateShop(shop);
        }

        private void BtnDeleteShop_OnClick(object sender, RoutedEventArgs e)
        {
            var btn = (Button)sender;
            int shopId = (int)btn.Tag;

            var shopToDel = ToolTrackerService.Shops.FirstOrDefault(s => s.Id == shopId);

            var result =
                NotifyUser.AskToConfirm(
                    $"Are you absolutely positive you want to delete {shopToDel?.Name}? Inmates assigned to this shop will be un-assigned.",
                    "Confirm Delete");
            if (result != System.Windows.Forms.DialogResult.Yes) return;

            // Remove from db
            using (var db = new UnitOfWork())
            {
                var shop = db.ShopsRepo.FindById(shopId);

                if (shop == null)
                {
                    NotifyUser.SomethingIsMissing("Sorry, this shop was not found.", "Shop No Found");
                    return;
                }

                if (shop.Name.Equals(ToolTrackerService.AllShopsName))
                {
                    NotifyUser.Forbidden("'All Shops' cannot be removed.", "Not Allowed");
                    return;
                }

                // Check if any inmates assigned to the shop.
                // If so, un-assign inmates. Otherwise get a FK restraint exception.
                bool inmatesAssigned = db.InmatesRepo.Exists(i => i.ShopId == shop.Id);
                if (inmatesAssigned)
                {
                    var inmates = db.InmatesRepo.FindAll(i => i.ShopId == shop.Id);
                    foreach (var inmate in inmates)
                    {
                        inmate.ShopId = null;
                        db.InmatesRepo.Update(inmate);
                    }
                }

                try
                {
                    db.ShopsRepo.Delete(shop);
                    db.Commit();
                }
                catch (EntityException ex)
                {
                    ExceptionHandler.LogAndNotifyOfException(ex, ex.Message);
                }
                catch (Exception ex)
                {
                    ExceptionHandler.LogAndNotifyOfException(ex, ex.Message);
                }

                // Remove from collection
                var shopElement = ToolTrackerService.Shops.SingleOrDefault(s => s.Id == shop.Id);
                ToolTrackerService.Shops.Remove(shopElement);

                // Updates the ShopIndex prop in view models to correct combobox selection
                ToolTrackerService.UpdateIndicesAfterShopUpdate();
            }

        }

        private void BtnAddShop_OnClick(object sender, RoutedEventArgs e)
        {
            var window = new AddShopWindow();
            window.ShowDialog();
        }

        private void BtnAddTool_OnClicktnAddTool_Click(object sender, RoutedEventArgs e)
        {
            var window = new AddToolWindow();
            window.ShowDialog();
        }

        private void BtnSaveUpdateTool_OnClick(object sender, RoutedEventArgs e)
        {
            var btn = (Button)sender;

            // Tag attribute on button is bound to Id
            int toolId = (int)btn.Tag;

            // Get tool obj from collection
            var tool = ToolTrackerService.Tools.SingleOrDefault(t => t.Id == toolId);

            // Ensure description is uppercase
            if (tool != null)
            {
                tool.Description = ToolTrackerService.MakeEveryWordUppercase(tool.Description);
            }

            // update/save tool
            UpdateTool(tool);
        }

        private void BtnDeleteTool_OnClick(object sender, RoutedEventArgs e)
        {
            var btn = (Button)sender;
            int toolId = (int)btn.Tag;

            var toolToDel = ToolTrackerService.Tools.FirstOrDefault(t => t.Id == toolId);

            var result =
                NotifyUser.AskToConfirm($"Are you absolutely positive you want to delete {toolToDel?.Description}?",
                    "Confirm Delete");

            if (result != System.Windows.Forms.DialogResult.Yes) return;

            // Remove from db
            using (var db = new UnitOfWork())
            {
                try
                {
                    var tool = db.ToolsRepo.FindById(toolId);
                    db.ToolsRepo.Delete(tool);
                    db.Commit();
                }
                catch (EntityException ex)
                {
                    ExceptionHandler.LogAndNotifyOfException(ex, ex.Message);
                }
                catch (Exception ex)
                {
                    ExceptionHandler.LogAndNotifyOfException(ex, ex.Message);
                }
            }

            // Remove from collection
            var toolVM = ToolTrackerService.Tools.SingleOrDefault(t => t.Id == toolId);
            ToolTrackerService.Tools.Remove(toolVM);
        }


        private void BtnToolCheckedOutBack_OnClick(object sender, RoutedEventArgs e)
        {
            if (_toolsCheckedOutBack.Count > 0)
            {
                int toolIssuedId = _toolsCheckedOutBack.Dequeue();
                _toolsCheckedOutNext.Enqueue(toolIssuedId);
                var toolCheckOutIn = ToolTrackerService.CheckOutInTools.FirstOrDefault(t => t.ToolIssuedId == toolIssuedId);
                if (toolCheckOutIn != null)
                    listBoxToolsCheckOutIn.ScrollIntoView(toolCheckOutIn);
            }
        }

        private void BtnToolCheckedOutNext_OnClick(object sender, RoutedEventArgs e)
        {
            if (_toolsCheckedOutNext.Count > 0)
            {
                int toolIssuedId = _toolsCheckedOutNext.Dequeue();
                _toolsCheckedOutBack.Enqueue(toolIssuedId);
                var toolCheckOutIn = ToolTrackerService.CheckOutInTools.FirstOrDefault(t => t.ToolIssuedId == toolIssuedId);
                if (toolCheckOutIn != null)
                    listBoxToolsCheckOutIn.ScrollIntoView(toolCheckOutIn);
            }
        }

        #endregion

        #region helper methods

        private void LoadToolsIssued(Shop shop)
        {
            ToolTrackerService.ToolsIssued.Clear();
            var date = DatePickerDate.SelectedDate ?? DateTime.Today;

            if (shop.Name.Equals("All Shops"))
            {
                ListBoxToolsIssued.ItemsSource = ToolTrackerService.LoadAllToolsIssued(date);
                return;
            }

            ListBoxToolsIssued.ItemsSource = ToolTrackerService.LoadToolsIssued(shop, date);
        }

        private void UpdateInmatesCombobox(Shop shop)
        {
            if (comboBoxShops.SelectedIndex < 1) return;

            List<Inmate> inmates;
            using (var db = new UnitOfWork())
            {
                if (shop.Name == ToolTrackerService.AllShopsName)
                {
                    inmates = db.InmatesRepo.FindAll().OrderBy(i => i.LastName).ToList();
                }
                else
                {
                    inmates = db.InmatesRepo.FindAll(i => i.ShopId == shop.Id).OrderBy(i => i.LastName).ToList();
                }

            }

            inmates.Insert(0, new Inmate { FirstName = "Select Inmate" });
            inmates.Insert(1, new Inmate { FirstName = "--------------------------------" });

            comboBoxInmates.DisplayMemberPath = "FullName";
            comboBoxInmates.ItemsSource = inmates;
            comboBoxInmates.SelectedIndex = 0;
        }

        public void UpdateToolsListBox()
        {
            List<Tool> tools;
            using (var db = new UnitOfWork())
                tools = db.ToolsRepo.FindAll().ToList();

            //listBoxToolsCheckInOut.DisplayMemberPath = "Description";
            //listBoxToolsCheckInOut.ItemsSource = tools;
        }

        private void UpdateToolsCheckedOutIn()
        {
            if (comboBoxInmates.SelectedIndex < 1) return;
            var inmate = (Inmate)comboBoxInmates.SelectedItem;
            ToolTrackerService.SelectedInmateId = inmate.Id;
            ToolTrackerService.LoadCheckOutInTools();
            listBoxToolsCheckOutIn.ItemsSource = ToolTrackerService.CheckOutInTools;

            UpdateCheckedOutTotal();

            StackPanelNextPrevButtons.Visibility = Visibility.Visible;
            LoadCheckedOutQueues();
        }

        private void LoadCheckedOutQueues()
        {
            _toolsCheckedOutNext.Clear();
            _toolsCheckedOutBack.Clear();


            var checkedOut = ToolTrackerService.CheckOutInTools.Where(t => t.IsCheckedOut).ToList();

            foreach (var tool in checkedOut)
            {
                _toolsCheckedOutNext.Enqueue(tool.ToolIssuedId);
            }
        }

        private void FindToolCheckedOutInByToolNo()
        {
            string toolNo = TextBlockToolNo.Text.ToUpper().Trim();
            if (string.IsNullOrEmpty(toolNo)) return;
            var toolCheckOutIn = ToolTrackerService.CheckOutInTools.FirstOrDefault(t => t.ToolNumber.Equals(toolNo));
            if (toolCheckOutIn != null)
                listBoxToolsCheckOutIn.ScrollIntoView(toolCheckOutIn);
        }

        public static void UpdateInmate(IInmate inmate)
        {
            // Persist update to db
            using (var db = new UnitOfWork())
            {
                try
                {
                    var inmateFromDb = db.InmatesRepo.FindById(inmate.Id);
                    inmateFromDb.FirstName = inmate.FirstName.Trim();
                    inmateFromDb.LastName = inmate.LastName.Trim();
                    inmateFromDb.GDCNumber = inmate.GDCNumber.Trim();
                    inmateFromDb.ShopId = inmate.AssignedShop.Id;

                    db.InmatesRepo.Update(inmateFromDb);
                    db.Commit();
                }
                catch (EntityException ex)
                {
                    ExceptionHandler.LogAndNotifyOfException(ex, ex.Message);
                }
                catch (Exception ex)
                {
                    ExceptionHandler.LogAndNotifyOfException(ex, ex.Message);
                }

                NotifyUser.AllGood("Changes were saved.", "Saved");
            }
        }

        private void UpdateTool(ITool tool)
        {
            // Persist update to db
            using (var db = new UnitOfWork())
            {
                try
                {
                    var toolFromDb = db.ToolsRepo.FindById(tool.Id);
                    toolFromDb.ToolNumber = tool.ToolNumber;
                    toolFromDb.Description = tool.Description;

                    if (tool.AssignedShop != null)
                        toolFromDb.ShopId = tool.AssignedShop.Id;

                    db.ToolsRepo.Update(toolFromDb);
                    db.Commit();

                    NotifyUser.AllGood("Changes were saved.", "Saved");
                }
                catch (EntityException ex)
                {
                    ExceptionHandler.LogAndNotifyOfException(ex, ex.Message);
                }
                catch (Exception ex)
                {
                    ExceptionHandler.LogAndNotifyOfException(ex, ex.Message);
                }
            }
        }

        private void UpdateUnsavedChanges(int id)
        {

        }

        private void UpdateShop(Shop shop)
        {
            // Persist update to db
            using (var db = new UnitOfWork())
            {
                try
                {
                    var shopFromDb = db.ShopsRepo.FindById(shop.Id);
                    shopFromDb.Name = shopFromDb.Name.Trim();

                    db.ShopsRepo.Update(shopFromDb);
                    db.Commit();

                    NotifyUser.AllGood("Changes were saved.", "Saved");
                }
                catch (EntityException ex)
                {
                    ExceptionHandler.LogAndNotifyOfException(ex, ex.Message);
                }
                catch (Exception ex)
                {
                    ExceptionHandler.LogAndNotifyOfException(ex, ex.Message);
                }
            }
        }

        #endregion

        private void CheckBoxCheckOutIn_OnChecked(object sender, RoutedEventArgs e)
        {
            _checkBox = (CheckBox)sender;
            int toolId = (int)_checkBox.Tag;

            _checkBox.IsEnabled = false;
            _isOnChecked = true;

            backgroundWorkerUpdateToolIssued = new BackgroundWorker();
            backgroundWorkerUpdateToolIssued.DoWork += BackgroundWorkerUpdateToolIssued_DoWork;
            backgroundWorkerUpdateToolIssued.RunWorkerCompleted += BackgroundWorkerUpdateToolIssued_RunWorkerCompleted;

            _checkOutInTool = ToolTrackerService.CheckOutInTools.FirstOrDefault(t => t.ToolId == toolId);

            if (_checkOutInTool == null) return;

            _newToolIssued = new ToolIssued
            {
                ToolId = _checkOutInTool.ToolId,
                DateTimeOut = DateTime.Now,
                ReceivedByInmateId = _checkOutInTool.InmateId,
                IssuedByOfficerId = ToolTrackerService.Officer.Id,
                ToolReturned = false
            };

            // Update db on separate thread
            backgroundWorkerUpdateToolIssued.RunWorkerAsync();


            //StopLoaderAnimation();

        }

        private void CheckBoxCheckOutIn_OnUnchecked(object sender, RoutedEventArgs e)
        {

            //StartLoaderAnimation();

            _checkBox = (CheckBox)sender;
            int toolId = (int)_checkBox.Tag;

            _checkBox.IsEnabled = false;
            _isOnChecked = false;

            backgroundWorkerUpdateToolIssued = new BackgroundWorker();
            backgroundWorkerUpdateToolIssued.DoWork += BackgroundWorkerUpdateToolIssued_DoWork;
            backgroundWorkerUpdateToolIssued.RunWorkerCompleted += BackgroundWorkerUpdateToolIssued_RunWorkerCompleted;

            _checkOutInTool = ToolTrackerService.CheckOutInTools.FirstOrDefault(t => t.ToolId == toolId);

            if (_checkOutInTool == null) return;

            // Update db on separate thread
            backgroundWorkerUpdateToolIssued.RunWorkerAsync();




            //StopLoaderAnimation();
        }

        private void UpdateCheckedOutStacks()
        {
            // Update checked out stacks
            if (_toolsCheckedOutNext.Count > 0 && _toolsCheckedOutNext.Peek() == _checkOutInTool.ToolIssuedId)
            {
                _toolsCheckedOutNext.Dequeue();
            }
            if (_toolsCheckedOutBack.Count > 0 && _toolsCheckedOutBack.Peek() == _checkOutInTool.ToolIssuedId)
            {
                _toolsCheckedOutBack.Dequeue();
            }
        }

        private void BackgroundWorkerUpdateToolIssued_DoWork(object sender, DoWorkEventArgs e)
        {
            //Inmate selectedInmate;
            using (var db = new UnitOfWork())
            {
                if (_isOnChecked)
                {
                    db.ToolsIssuedRepo.Add(_newToolIssued);
                    db.Commit();
                    _selectedInmate = db.InmatesRepo.FindById(ToolTrackerService.SelectedInmateId);
                }
                else //OnUnchecked
                {
                    var toolIssued = db.ToolsIssuedRepo.FindById(_checkOutInTool.ToolIssuedId);

                    if (toolIssued == null)
                    {
                        NotifyUser.SomethingIsMissing("No tool found.", "Not Found");
                        return;
                    }

                    toolIssued.DateTimeIn = DateTime.Now;
                    toolIssued.ReturnedByInmateId = _checkOutInTool.InmateId;
                    toolIssued.ReceivedByOfficerId = ToolTrackerService.Officer.Id;
                    toolIssued.ToolReturned = true;

                    try
                    {
                        db.ToolsIssuedRepo.Update(toolIssued);
                        db.Commit();
                    }
                    catch (EntityException ex)
                    {
                        ExceptionHandler.LogAndNotifyOfException(ex, ex.Message);
                    }
                    catch (Exception ex)
                    {
                        ExceptionHandler.LogAndNotifyOfException(ex, ex.Message);
                    }
                }

            }
        }

        private void BackgroundWorkerUpdateToolIssued_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (_isOnChecked)
            {
                // Update tool issued id in collection
                _checkOutInTool.ToolIssuedId = _newToolIssued.Id;

                // Update inmate
                _checkOutInTool.InmateId = _selectedInmate.Id;
                _checkOutInTool.Inmate = _selectedInmate;

                _checkOutInTool.ToolReturned = false;

                listBoxToolsCheckOutIn.Items.Refresh();

                LoadCheckedOutQueues();
                UpdateCheckedOutTotal();

                _checkBox.IsEnabled = true;
            }
            else // onUnchecked
            {
                _checkOutInTool.Inmate = null;
                _checkOutInTool.ToolReturned = true;

                listBoxToolsCheckOutIn.Items.Refresh();

                _checkBox.IsEnabled = true;
                UpdateCheckedOutStacks();
                UpdateCheckedOutTotal();
            }
        }

        private void UpdateCheckedOutTotal(string total = null)
        {
            if (total == null)
                total = ToolTrackerService.CheckOutInTools.Count(t => !t.ToolReturned).ToString();
            TextBlockCheckOutTotal.Text = total;
            TextBlockCheckOutTotal.Foreground = total.Equals("0") ? Brushes.Green : Brushes.Crimson;
        }

        private void TabControl_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //_counter++;
            //Console.WriteLine("counter: " + _counter);

            if (!TabItemToolsIssued.IsSelected)
            {
                comboBoxShopsToolsIssued.SelectedIndex = 0;
                ToolTrackerService.ToolsIssued?.Clear();
            }

            if (TabItemCheckOutInTools.IsSelected)
                TextBlockTabHeader.Text = "CHECK OUT/IN TOOLS";
            if (!TabItemCheckOutInTools.IsSelected)
            {
                comboBoxShops.SelectedIndex = 0;
                comboBoxInmates.SelectedIndex = 0;
                ToolTrackerService.CheckOutInTools.Clear();
                TextBlockCheckOutTotal.Text = ToolTrackerService.GetCheckedOutTotal();
                StackPanelNextPrevButtons.Visibility = Visibility.Hidden;
            }

            if (TabItemToolsIssued.IsSelected)
                TextBlockTabHeader.Text = "TOOLS ISSUED";
            if (TabItemInmates.IsSelected)
                TextBlockTabHeader.Text = "UPDATE INMATES";
            if (TabItemTools.IsSelected)
            {
                TextBlockTabHeader.Text = "UPDATE TOOLS";
            }

            if (TabItemShops.IsSelected)
                TextBlockTabHeader.Text = "UPDATE SHOPS";
        }

        private void ComboBoxShopsToolsIssued_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBoxShopsToolsIssued.SelectedIndex < 1) return;
            var shop = (Shop)comboBoxShopsToolsIssued.SelectedItem;

            LoadToolsIssued(shop);
        }

        private void MenuItemExit_OnClick(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void MenuItemAbout_OnClick(object sender, RoutedEventArgs e)
        {
            var window = new AboutWindow();
            window.Show();
        }

        private void MenuItemSettings_OnClick(object sender, RoutedEventArgs e)
        {
            var window = new SettingsWindow();
            window.ShowDialog();
        }

        private void MenuItemImportTools_OnClick(object sender, RoutedEventArgs e)
        {
            var window = new ImportToolsWindow();
            window.Show();
        }

        private void DatePickerDate_OnSelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBoxShopsToolsIssued.SelectedIndex < 1) return;
            var shop = (Shop)comboBoxShopsToolsIssued.SelectedItem;

            LoadToolsIssued(shop);
        }

        //
        //TODO research how to run loader animation on separate thread
        //
        private void StartLoaderAnimation()
        {
            //
            //TODO run async on separate thread
            //

            this.Dispatcher.BeginInvoke(new Action(() =>
            {
                //((Storyboard) FindResource("WaitStoryboard")).Begin();
                //TextBlockTabHeader.Visibility = Visibility.Hidden;
                //Wait.Visibility = Visibility.Visible;

                //LoadingAdorner.IsAdornerVisible = true;
            }));


        }

        private void StopLoaderAnimation()
        {
            this.Dispatcher.BeginInvoke(new Action(() =>
            {
                //((Storyboard) FindResource("WaitStoryboard")).Stop();
                //TextBlockTabHeader.Visibility = Visibility.Visible;
                //Wait.Visibility = Visibility.Hidden;

                //LoadingAdorner.IsAdornerVisible = false;
            }));
        }

        #region MouseWheel event handler workaround
        private void MyMouseWheelH(object sender, RoutedEventArgs e)
        {
            // By default the mouse wheel does not work inside a listbox
            // this is a workaround for that issue
            MouseWheelEventArgs eargs = (MouseWheelEventArgs)e;
            double x = (double)eargs.Delta;

            if (ScrollViewerCheckOutInTools.IsMouseOver)
            {
                double y = ScrollViewerCheckOutInTools.VerticalOffset;
                ScrollViewerCheckOutInTools.ScrollToVerticalOffset(y - x);
            }

            if (ScrollViewerToolsIssued.IsMouseOver)
            {
                double y = ScrollViewerToolsIssued.VerticalOffset;
                ScrollViewerToolsIssued.ScrollToVerticalOffset(y - x);
            }

            if (ScrollViewerInmates.IsMouseOver)
            {
                double y = ScrollViewerInmates.VerticalOffset;
                ScrollViewerInmates.ScrollToVerticalOffset(y - x);
            }

            if (ScrollViewerTools.IsMouseOver)
            {
                double y = ScrollViewerTools.VerticalOffset;
                ScrollViewerTools.ScrollToVerticalOffset(y - x);
            }

            if (ScrollViewerShops.IsMouseOver)
            {
                double y = ScrollViewerShops.VerticalOffset;
                ScrollViewerShops.ScrollToVerticalOffset(y - x);
            }
        }

        private void ScrollViewerCheckOutInTools_OnLoaded(object sender, RoutedEventArgs e)
        {
            listBoxToolsCheckOutIn.AddHandler(MouseWheelEvent, new RoutedEventHandler(MyMouseWheelH), true);
        }

        private void ScrollViewerToolsIssued_OnLoaded(object sender, RoutedEventArgs e)
        {
            ListBoxToolsIssued.AddHandler(MouseWheelEvent, new RoutedEventHandler(MyMouseWheelH), true);
        }

        private void ScrollViewerInmates_OnLoaded(object sender, RoutedEventArgs e)
        {
            listBoxUpdateInmates.AddHandler(MouseWheelEvent, new RoutedEventHandler(MyMouseWheelH), true);
        }

        private void ScrollViewerTools_OnLoaded(object sender, RoutedEventArgs e)
        {
            listBoxUpdateTools.AddHandler(MouseWheelEvent, new RoutedEventHandler(MyMouseWheelH), true);
        }

        private void ScrollViewerShops_OnLoaded(object sender, RoutedEventArgs e)
        {
            listBoxUpdateShops.AddHandler(MouseWheelEvent, new RoutedEventHandler(MyMouseWheelH), true);
        }
        #endregion

        private void ListBoxUpdateTools_OnIsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

            //var lstbx = (ListBox)sender;

            //var newValu = e.NewValue;
            //var oldValue = e.OldValue;

            //MessageBox.Show("OnIsEnabledChanged");
            //StopLoaderAnimation();
        }

        private void ListBoxUpdateTools_OnIsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            //StartLoaderAnimation();

            // _busyIndicator.IsBusy = true;
            //LoadingAnimationDelegate del = () => {
            //    _busyIndicator.IsBusy = true;
            //};

            //Dispatcher.BeginInvoke(del);
            //Console.WriteLine("ListBoxUpdateTools_OnIsVisibleChanged");
        }

        private void ListBoxUpdateTools_OnLoaded(object sender, RoutedEventArgs e)
        {
            //StopLoaderAnimation();
            // _busyIndicator.IsBusy = false;

            //Console.WriteLine("ListBoxUpdateTools_OnLoaded");
        }

        private void ListBoxUpdateTools_LayoutUpdated(object sender, EventArgs e)
        {
            // Console.WriteLine("ListBoxUpdateTools_LayoutUpdated");
        }
    }
}
