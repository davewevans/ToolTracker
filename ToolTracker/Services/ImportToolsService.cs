using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows;
using ToolTracker.DAL;
using ToolTracker.Models;
using Excel = Microsoft.Office.Interop.Excel;

namespace ToolTracker.Services
{
    class ImportToolsService
    {
        private List<Tool> _newTools;

        // default shops
        private Shop _autoBody;
        private Shop _autoMaintenance;
        private Shop _smallEngine;
        private Shop _welding;
        private Shop _bufferMaintenance;
        private Shop _woodShop;


        public ImportToolsService()
        {
            _newTools = new List<Tool>();
        }

        public void ImportTools(string filePath)
        {
            if (!System.IO.File.Exists(filePath))
            {
                NotifyUser.SomethingIsMissing("Sorry, we can't find this file. Please try again.", "File Not Found");
                return;
            }

            // Sets the private fields with shop objects
            SetDefaultShops();

            //Create COM Objects. Create a COM object for everything that is referenced
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(filePath);
            Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Excel.Range xlRange = xlWorksheet.UsedRange;
           
            int rowCount = xlWorksheet.UsedRange.Rows.Count;
            int colCount = xlWorksheet.UsedRange.Columns.Count;
            string toolNumber = null, description = null;
            for (int i = 1; i <= rowCount; i++)
            {
                for (int j = 1; j <= colCount; j++)
                {
                    if (xlRange.Cells[i, j] != null && xlRange.Cells[i, j].Value2 != null)
                    {
                        if (j == 1)
                            toolNumber = xlRange.Cells[i, j].Value2.ToString();
                        else
                            description = xlRange.Cells[i, j].Value2.ToString();
                    }
                }
                CreateTool(toolNumber, description);
            }

            StoreNewTools();

            CleanUp(xlRange, xlWorksheet, xlWorkbook, xlApp);
        }

        private void StoreNewTools()
        {
            using (var db = new UnitOfWork())
            {
               foreach (var newTool in _newTools)
                {
                    // Make sure tool with same number doesn't exist
                    if(!db.ToolsRepo.Exists(t => t.ToolNumber.Equals(newTool.ToolNumber)))
                        db.ToolsRepo.Add(newTool);
                } 
               db.Commit();
            }
        }

        private void SetDefaultShops()
        {
            ToolTrackerService.LoadShops();
            _autoBody = ToolTrackerService.Shops.FirstOrDefault(s => s.Name.Equals("Auto Body"));
            _autoMaintenance = ToolTrackerService.Shops.FirstOrDefault(s => s.Name.Equals("Auto Mechanic"));
            _smallEngine = ToolTrackerService.Shops.FirstOrDefault(s => s.Name.Equals("Small Engine"));
            _welding = ToolTrackerService.Shops.FirstOrDefault(s => s.Name.Equals("Welding"));
            _bufferMaintenance = ToolTrackerService.Shops.FirstOrDefault(s => s.Name.Equals("Buffer Maintenance"));
            _woodShop = ToolTrackerService.Shops.FirstOrDefault(s => s.Name.Equals("Wood Shop"));
        }

        private void CreateTool(string toolNumber, string description)
        {
            if (toolNumber == null || description == null) return;

            _newTools.Add(new Tool
            {
                ToolNumber = toolNumber,
                Description = description,
                ShopId = FindAssignedShop(toolNumber)
            });
        }

        private int? FindAssignedShop(string toolNumber)
        {
            string firstChar = toolNumber.Substring(0, 1);
            string first2Chars = toolNumber.Substring(0, 2);

            if (first2Chars.Equals("AB")) return _autoBody?.Id;
            if (first2Chars.Equals("AM")) return _autoMaintenance?.Id;
            if (first2Chars.Equals("BM")) return _bufferMaintenance?.Id;
            if (first2Chars.Equals("SA")) return _smallEngine?.Id;
            if (first2Chars.Equals("WS")) return _woodShop?.Id;
            if (firstChar.Equals("W") && !first2Chars.Equals("WS")) return _welding?.Id;

            return null;
        }

        private static void CleanUp(Excel.Range xlRange, Excel._Worksheet xlWorksheet, Excel.Workbook xlWorkbook, Excel.Application xlApp)
        {
            //cleanup
            GC.Collect();
            GC.WaitForPendingFinalizers();

            //rule of thumb for releasing com objects:
            // never use two dots, all COM objects must be referenced and released individually
            // ex: [somthing].[something].[something] is bad
            //release com objects to fully kill excel process from running in the background
            Marshal.ReleaseComObject(xlRange);
            Marshal.ReleaseComObject(xlWorksheet);

            //close and release
            xlWorkbook.Close();
            Marshal.ReleaseComObject(xlWorkbook);

            //quit and release
            xlApp.Quit();
            Marshal.ReleaseComObject(xlApp);
        }
    }
}
