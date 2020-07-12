using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Core;
using System.Linq;
using System.Windows.Controls;
using ToolTracker.Comparers;
using ToolTracker.DAL;
using ToolTracker.Models;
using ToolTracker.Enums;
using ToolTracker.Interfaces;
using ToolTracker.ViewModels;

namespace ToolTracker.Services
{
    static class ToolTrackerService
    {
        public static int SelectedShopId { get; set; }
        public static int SelectedInmateId { get; set; }
        public static string AllShopsName => "All Shops";
        public static Officer Officer { get; set; }

        public static ObservableCollection<InmateViewModel> Inmates { get; set; }
        public static ObservableCollection<Shop> Shops { get; set; }
        public static ObservableCollection<ToolViewModel> Tools { get; set; }
        public static ObservableCollection<CheckToolOutInViewModel> CheckOutInTools { get; set; }
        public static ObservableCollection<ToolIssuedViewModel> ToolsIssued { get; set; }
        public static ObservableCollection<Officer> Officers { get; set; }

        public static InmateValidationStatus InmateValidationStatus { get; set; }

        public static void LoadOfficers()
        {
            Officers.Clear();
            using (var db = new UnitOfWork())
            {
                try
                {
                    var officers = db.OfficersRepo.FindAll().ToList();
                    if (officers.Count == 0) return;
                    foreach (var officer in officers)
                    {
                        Officers.Add(officer);
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

            }
        }

        public static void AddOfficer(string officerName)
        {
            var officer = new Officer
            {
                Name = officerName
            };

            using (var db = new UnitOfWork())
            {
                db.OfficersRepo.Add(officer);
                db.Commit();
            }
            LoadOfficers();
        }

        public static void EditOfficer(string officerName)
        {
            using (var db = new UnitOfWork())
            {
                var officer = db.OfficersRepo.FindById(Officer.Id);
                officer.Name = officerName;
                db.OfficersRepo.Update(officer);
                db.Commit();
            }
            LoadOfficers();
        }

        public static ObservableCollection<CheckToolOutInViewModel> LoadCheckOutInTools()
        {
            // Shop and inmate have to be selected
            if (SelectedShopId < 1 || SelectedInmateId < 1) return null;

            CheckOutInTools.Clear();

            using (var db = new UnitOfWork())
            {
                var inmate = db.InmatesRepo.FindById(SelectedInmateId);
                var shop = db.ShopsRepo.FindById(SelectedShopId);
                var tools = shop.Name == AllShopsName ? db.ToolsRepo.FindAll().ToList() 
                    : db.ToolsRepo.FindAll(t => t.ShopId == SelectedShopId).ToList();

                MapToolsToCheckOutInViewModel(tools, inmate, db);
            }

            return CheckOutInTools;
        }

        private static void MapToolsToCheckOutInViewModel(IEnumerable<Tool> tools, Inmate inmate, UnitOfWork db)
        {
            foreach (var tool in tools)
            {
                MapToolToCheckOutInViewModel(tool, inmate, db);    
            }
        }

        private static void MapToolToCheckOutInViewModel(Tool tool, Inmate inmate, UnitOfWork db)
        {
            var shop = db.ShopsRepo.FindById(tool.ShopId);

            var checkToolOutIn = new CheckToolOutInViewModel
            {
                ToolNumber = tool.ToolNumber,
                ToolDescription = tool.Description,
                ShopName = shop.Name,
                InmateId = inmate.Id,
                Inmate = inmate,
                ToolId = tool.Id,
                ToolReturned = true
            };

            // check if tool is checked out
            bool toolCheckedOut = db.ToolsIssuedRepo
                .Exists(ti => ti.ToolId == tool.Id && !ti.ToolReturned);

            // if already checked out, get inmate name and assign to property
            if (toolCheckedOut)
            {
                // get ToolIssued obj
                var toolIssued = db.ToolsIssuedRepo.Find(ti => ti.ToolId == tool.Id && !ti.ToolReturned);
                var checkedOutByInmate = db.InmatesRepo.FindById(toolIssued.ReceivedByInmateId);
                checkToolOutIn.Inmate = checkedOutByInmate;
                checkToolOutIn.InmateId = checkedOutByInmate?.Id ?? 0;
                checkToolOutIn.IsCheckedOut = true;
                checkToolOutIn.ToolIssuedId = toolIssued.Id;
                checkToolOutIn.ToolReturned = toolIssued.ToolReturned;
            }
           
            CheckOutInTools.Add(checkToolOutIn);
        }

        public static ObservableCollection<InmateViewModel> LoadInmates()
        {
            // Get list from db
            List<Inmate> inmates;
            using (var db = new UnitOfWork())
                inmates = db.InmatesRepo.FindAll().ToList();

            LoadShops();
            MapInmatesToViewModel(inmates);

            return Inmates;
        }

        public static void SortInmates()
        {
            var inmates = Inmates.ToList();
            inmates.Sort(new InmateComparer());
            Inmates.Clear();
            foreach (var inmate in inmates)
                Inmates.Add(inmate);
            
        }

        public static void SortTools()
        {
            var tools = Tools.ToList();
            tools.Sort(new ToolComparer());
            Tools.Clear();
            foreach (var tool in tools)
                Tools.Add(tool);
            
        }

        public static void SortShops()
        {
            var shops = Shops.ToList();
            shops.Sort(new ShopComparer());
            Shops.Clear();
            foreach (var shop in shops)
                Shops.Add(shop);
            
        }

        public static string GetCheckedOutTotal()
        {
            using (var db = new UnitOfWork())
            {
                return db.ToolsIssuedRepo.FindAll(t => !t.ToolReturned).Count().ToString();
            }
        }

        public static ObservableCollection<ToolViewModel> LoadTools()
        {
            using (var db = new UnitOfWork())
            {
                var tools = db.ToolsRepo.FindAll().ToList();
                MapToolsToViewModel(tools);
            }
            return Tools;
        }

        public static ObservableCollection<ToolIssuedViewModel> LoadToolsIssued(Shop shop, DateTime date)
        {
            using (var db = new UnitOfWork())
            {
                var toolsIssued = db.ToolsIssuedRepo.FindAll(t => t.DateTimeOut.Year == date.Year 
                    && t.DateTimeOut.Month == date.Month 
                    && t.DateTimeOut.Day == date.Day 
                    && t.Tool.AssignedShop.Id == shop.Id).ToList();
                MapToolsIssuedToViewModel(toolsIssued, db);
            }
            return ToolsIssued;
        }

        public static ObservableCollection<ToolIssuedViewModel> LoadAllToolsIssued(DateTime date)
        {
            using (var db = new UnitOfWork())
            {
                var toolsIssued = db.ToolsIssuedRepo.FindAll(t => t.DateTimeOut.Year == date.Year
                    && t.DateTimeOut.Month == date.Month
                    && t.DateTimeOut.Day == date.Day).ToList();
                MapToolsIssuedToViewModel(toolsIssued, db);
            }
            return ToolsIssued;
        }

        private static void MapToolsIssuedToViewModel(IEnumerable<ToolIssued> toolsIssued, UnitOfWork db)
        {
            if (toolsIssued == null) return;
            foreach (var toolIssued in toolsIssued)
            {
                MapToolIssuedToViewModel(toolIssued, db);
            }
        }

        private static void MapToolIssuedToViewModel(ToolIssued toolIssued, UnitOfWork db)
        {
            var tool = db.ToolsRepo.FindById(toolIssued.ToolId);
            var issuedByOfficer = db.OfficersRepo.FindById(toolIssued.IssuedByOfficerId);
            var receivedByInmate = db.InmatesRepo.FindById(toolIssued.ReceivedByInmateId);

            var receivedByOfficer = db.OfficersRepo.FindById(toolIssued.ReceivedByOfficerId);
            var returnedByInmate = db.InmatesRepo.FindById(toolIssued.ReturnedByInmateId);

            ToolsIssued.Add(new ToolIssuedViewModel
            {
               ToolNumber = tool?.ToolNumber,
               ToolDescription = tool?.Description,
               DateTimeIn = toolIssued.DateTimeIn,
               DateTimeOut = toolIssued.DateTimeOut,
               ReceivedByInmateFirstName = receivedByInmate?.FirstName,
               ReceivedByInmateLastName = receivedByInmate?.LastName,
               ReturnedByInmateFirstName = returnedByInmate?.FirstName,
               ReturnedByInmateLastName = returnedByInmate?.LastName,
               Shop = tool?.AssignedShop,
               IssuedByName = issuedByOfficer.Name,
               ReceivedByName = receivedByOfficer?.Name, 
            });
        }

        public static void MapToolsToViewModel(IEnumerable<Tool> tools)
        {
            if (tools == null) return;
            foreach (var tool in tools)
            {
                MapToolToViewModel(tool);
            }
        }

        /// <summary>
        /// Maps domain to view model and adds to observable collection.
        /// </summary>
        /// <param name="tool"></param>
        public static void MapToolToViewModel(Tool tool)
        {
            // shop obj needed to get the shop index for the drop down menu
            var shop = Shops.SingleOrDefault(s => s.Id == tool.ShopId);
            Tools.Add(new ToolViewModel
            {
                Id = tool.Id,
                ToolNumber = tool.ToolNumber,
                Description = tool.Description,
                ShopId = shop?.Id,
                ShopIndex = Shops.IndexOf(shop)
            });
        }

        public static void UpdateIndicesAfterShopUpdate()
        {
            foreach (var inmate in Inmates)
            {
                var shop = Shops.SingleOrDefault(s => s.Id == inmate.ShopId);
                if (shop == null) inmate.ShopIndex = -1;
                else { inmate.ShopIndex = Shops.IndexOf(shop); }
            }

            foreach (var tool in Tools)
            {
                var shop = Shops.SingleOrDefault(s => s.Id == tool.ShopId);
                if (shop == null) tool.ShopIndex = -1;
                else { tool.ShopIndex = Shops.IndexOf(shop); }
            }
        }

        public static ObservableCollection<Shop> LoadShops()
        {
            var shops = GetShops();
            Shops = new ObservableCollection<Shop>(shops.OrderBy(s => s.Name));
            return Shops;
        }

        public static IEnumerable<Shop> GetShops()
        {
            using (var db = new UnitOfWork())
                return db.ShopsRepo.FindAll().ToList();
        }

        public static void UpdateShopsCombobox(ComboBox comboBox)
        {
            List<Shop> shops;
            using (var db = new UnitOfWork())
                shops = db.ShopsRepo.FindAll().ToList();

            shops.Insert(0, new Shop { Name = "Select Shop" });
            shops.Insert(1, new Shop { Name = "--------------------------------" });
            comboBox.DisplayMemberPath = "Name";
            comboBox.ItemsSource = shops;
            comboBox.SelectedIndex = 0;
        }

        /// <summary>
        /// Maps Inmate to InmateViewModel.
        /// </summary>
        /// <param name="inmates"></param>
        public static void MapInmatesToViewModel(IEnumerable<Inmate> inmates)
        {
            if (inmates == null) return;
            foreach (var inmate in inmates)
            {
                MapInmateToViewModel(inmate);
            }
        }

        public static void MapInmateToViewModel(Inmate inmate)
        {
            // shop obj needed to get the shop index for the drop down menu
            var shop = Shops.SingleOrDefault(s => s.Id == inmate.ShopId);
            Inmates.Add(new InmateViewModel
            {
                Id = inmate.Id,
                FirstName = inmate.FirstName,
                LastName = inmate.LastName,
                GDCNumber = inmate.GDCNumber,
                ShopId = inmate.ShopId,
                ShopIndex = Shops.IndexOf(shop)
            });
        }

        public static string ValidateInmateData(IInmate inmate)
        {
            InmateValidationStatus = InmateValidation(inmate);
            switch (InmateValidationStatus)
            {
                case InmateValidationStatus.InvalidFirstName:
                    return "The first name is invalid.";
                case InmateValidationStatus.InvalidLastName:
                    return "The last name is invalid.";
                case InmateValidationStatus.InvalidGDC:
                    return "The GDC number is invalid.";
                case InmateValidationStatus.NoShopAssigned:
                    return "No shop assigned to inmate.";
                default:
                    return null;
            }
        }

        /// <summary>
        /// Validation logic for adding or updating an inmate.
        /// </summary>
        /// <param name="inmate"></param>
        private static InmateValidationStatus InmateValidation(IInmate inmate)
        {
            if (string.IsNullOrEmpty(inmate.FirstName) || inmate.FirstName.Any(ch => !char.IsLetter(ch)))
                return InmateValidationStatus.InvalidFirstName;

            if (string.IsNullOrEmpty(inmate.LastName) || inmate.LastName.Any(ch => !char.IsLetter(ch)))
                return InmateValidationStatus.InvalidLastName;

            if (string.IsNullOrEmpty(inmate.GDCNumber) || inmate.GDCNumber.Any(digit => !char.IsDigit(digit)))
                return InmateValidationStatus.InvalidGDC;
           
            // Compares the shop objects with an equality comparer
            if (inmate.AssignedShop == null || !Shops.Contains(inmate.AssignedShop, new ShopEqualityComparer()))
                return InmateValidationStatus.NoShopAssigned;

            return InmateValidationStatus.IsValidated;
        }

        public static string MakeFirstLetterUppercase(string word)
        {
            if (string.IsNullOrEmpty(word)) return word;
            return char.ToUpper(word[0]) + word.Substring(1);
        }

        public static string MakeEveryWordUppercase(string words)
        {
            string[] nameSplit = words.Split(' ');
            string nameUppercase = "";
            for (int i = 0; i < nameSplit.Length; i++)
            {
                string word = MakeFirstLetterUppercase(nameSplit[i]);
                nameUppercase = nameUppercase + word;
                if (i < nameSplit.Length - 1)
                {
                    nameUppercase = nameUppercase + " ";
                }
            }
            return nameUppercase;
        }

        //public static string TruncateText(string text, int maxLength)
        //{
        //    if (text.Length <= maxLength)
        //        return text;

        //    // To account for '...'
        //    maxLength = maxLength - 3;
        //    string truncatedText = text.Substring(0, maxLength);
        //    return $"{truncatedText}...";
        //}

    }
}
