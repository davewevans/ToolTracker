using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using ToolTracker.ViewModels;
using ToolTracker.Models;
using ToolTracker.Services;

namespace ToolTracker.Printing
{
    public static class PrintingService
    {
        public static List<ToolsIssuedShopGroup> ToolsIssuedShopGroups { get; set; }

        public static bool AllShopsSelected { get; set; }

        public static string ShopName { get; set; }

        // For drawing shop name in top left corner
        public static List<string> ShopNames { get; set; }
        public static int ShopNamesCounter { get; set; }

        // Only used if 'All Shops' selected
        public static int PageCount { get; set; }

        public static DataTable ToolsIssuedDataTable { get; set; }

        public static void PrintToolsIssued(Shop shop)
        {
            AllShopsSelected = shop.Name.Equals("All Shops");
            ShopName = shop.Name;
            ShopNamesCounter = 0;

            CreateDataTable();

            // For one shop selected
            if (!AllShopsSelected)
                AddDataToRows(ToolTrackerService.ToolsIssued);

            var printDialog = new PrintDialog();
            printDialog.SelectedPagesEnabled = true;
            printDialog.CurrentPageEnabled = true;

            string dateStr = DateTime.Now.ToString("d");
            string printDescription = $"Tools Issued {dateStr}";

            // if 'All Shops' selected, create groups and get the page count
            // Need page count b4 creating DataSetPaginator (it uses the static prop)
            if (AllShopsSelected)
            {
                CreateToolsIssuedGroups();
                PageCount = GetPageCount();
            }

            if (printDialog.ShowDialog() != true) return;
            var paginator = new DataSetPaginator(ToolsIssuedDataTable,
                new Typeface("Times New Roman"), 10, 96 * 0.5,
                new Size(1056, 816), rowsPerPage: 17);

            #region For 'All Shops' selected
            if (AllShopsSelected)
            {
                ShopNames = new List<string>();
                foreach (var group in ToolsIssuedShopGroups)
                {
                    AddDataToRows(group.ToolsIssued);
                    AddBlankRows(group.BlankRowsQty);

                    // Add shop name to display per page
                    for (int i = 0; i < group.PageCount; i++)
                    {
                        ShopNames.Add(group.ShopName);
                    }
                }
            }
            #endregion
          
            printDialog.PrintDocument(paginator, printDescription);
          
        }

        private static int GetPageCount()
        {
            return ToolsIssuedShopGroups.Sum(@group => @group.PageCount);
        }

        /// <summary>
        /// Groups the tools issued by shop. Only used if 
        /// 'All Shops' is selected.
        /// </summary>
        /// <param name="shop"></param>
        private static void CreateToolsIssuedGroups()
        {
            // 'All Shops' selected
            ToolsIssuedShopGroups = new List<ToolsIssuedShopGroup>();
            ToolsIssuedShopGroup group;
            bool shopGroupExists;
            foreach (var toolIssued in ToolTrackerService.ToolsIssued)
            {
                shopGroupExists = ToolsIssuedShopGroups.Exists(g => g.ShopName.Equals(toolIssued.Shop.Name));
                if (!shopGroupExists)
                    ToolsIssuedShopGroups.Add(new ToolsIssuedShopGroup { ShopName = toolIssued.Shop.Name });
                group = ToolsIssuedShopGroups.FirstOrDefault(g => g.ShopName == toolIssued.Shop.Name);
                group?.ToolsIssued.Add(toolIssued);
            }
            
        }

        public static void AddDataToRows(IEnumerable<ToolIssuedViewModel> toolsIssued )
        {
            foreach (var t in toolsIssued)
            {
                ToolsIssuedDataTable.Rows.Add(t.ToolNumber, t.ToolDescription, t.ReceivedByInmateDisplayName, t.IssuedByName, t.DateOut,
                    t.TimeOut, t.DateIn, t.TimeIn, t.ReturnedByInmateDisplayName, t.ReceivedByName);
            }
        }

        public static void AddBlankRows(int blankRowsQty)
        {
            for (int i = 0; i < blankRowsQty; i++)
            {
                ToolsIssuedDataTable.Rows.Add("", "", "", "", "", "", "", "", "", "");
            }
        }

        private static void CreateDataTable()
        {
            var dc1 = new DataColumn("ToolNo");
            var dc2 = new DataColumn("Description");
            var dc3 = new DataColumn("ReceivedByInmate");
            var dc4 = new DataColumn("IssuedBy");
            var dc5 = new DataColumn("DateOut");
            var dc6 = new DataColumn("TimeOut");
            var dc7 = new DataColumn("DateIn");
            var dc8 = new DataColumn("TimeIn");
            var dc9 = new DataColumn("ReturnedBy");
            var dc10 = new DataColumn("ReveivedByOfficer");

            ToolsIssuedDataTable = new DataTable();

            ToolsIssuedDataTable.Columns.Add(dc1);
            ToolsIssuedDataTable.Columns.Add(dc2);
            ToolsIssuedDataTable.Columns.Add(dc3);
            ToolsIssuedDataTable.Columns.Add(dc4);
            ToolsIssuedDataTable.Columns.Add(dc5);
            ToolsIssuedDataTable.Columns.Add(dc6);
            ToolsIssuedDataTable.Columns.Add(dc7);
            ToolsIssuedDataTable.Columns.Add(dc8);
            ToolsIssuedDataTable.Columns.Add(dc9);
            ToolsIssuedDataTable.Columns.Add(dc10);
        }

        
    }
}
