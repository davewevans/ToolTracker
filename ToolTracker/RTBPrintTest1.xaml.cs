using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ToolTracker
{
    /// <summary>
    /// Interaction logic for RTBPrintTest1.xaml
    /// </summary>
    public partial class RTBPrintTest1 : Window
    {
        public RTBPrintTest1()
        {
            InitializeComponent();
        }

        private void BtnPrint_OnClick(object sender, RoutedEventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
                var doc = richTextBox.Document;

                // Save all the existing settings.
                double pageHeight = doc.PageHeight;
                double pageWidth = doc.PageWidth;
                Thickness pagePadding = doc.PagePadding;
                double columnGap = doc.ColumnGap;
                double columnWidth = doc.ColumnWidth;

                // Make the FlowDocument page match the printed page.
                doc.PageHeight = printDialog.PrintableAreaHeight;
                doc.PageWidth = printDialog.PrintableAreaWidth;
                doc.PagePadding = new Thickness(50);



                // Use two columns.
                //doc.ColumnGap = 25;
                //doc.ColumnWidth = (doc.PageWidth - doc.ColumnGap
                //- doc.PagePadding.Left - doc.PagePadding.Right) / 2;
                printDialog.PrintDocument(
                ((IDocumentPaginatorSource)doc).DocumentPaginator, "A Flow Document");

                // Reapply the old settings.
                doc.PageHeight = pageHeight;
                doc.PageWidth = pageWidth;
                doc.PagePadding = pagePadding;
                //doc.ColumnGap = columnGap;
                //doc.ColumnWidth = columnWidth;
            }
        }
       
    }
}
    

