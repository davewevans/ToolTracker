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
    /// Interaction logic for PrintTest1.xaml
    /// </summary>
    public partial class PrintTest1 : Window
    {
        public PrintTest1()
        {
            InitializeComponent();
        }

        private void BtnPrint_OnClick(object sender, RoutedEventArgs e)
        {
           
        }

        private void Button_OnClick(object sender, RoutedEventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
                // Create the text.
                Run run = new Run("This is a test of the printing functionality " +
                "in the Windows Presentation Foundation.");

                // Wrap it in a TextBlock.
                TextBlock visual = new TextBlock();
                visual.Inlines.Add(run);

                // Use margin to get a page border.
                visual.Margin = new Thickness(15);

                // Allow wrapping to fit the page width.
                visual.TextWrapping = TextWrapping.Wrap;

                // Scale the TextBlock up in both dimensions by a factor of 5.
                // (In this case, increasing the font would have the same effect,
                // because the TextBlock is the only element.)
                visual.LayoutTransform = new ScaleTransform(5, 5);

                // Size the element.
                Size pageSize = new Size(printDialog.PrintableAreaWidth,
                printDialog.PrintableAreaHeight);

                visual.Measure(pageSize);

                visual.Arrange(new Rect(0, 0, pageSize.Width, pageSize.Height));

                // Print the element.
                printDialog.PrintVisual(visual, "A Scaled Drawing");
            }
        }

        private void Button1_OnClick(object sender, RoutedEventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
                //FlowDocument doc = docReader.Document;

                FlowDocument doc = new FlowDocument();

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
                doc.ColumnGap = 25;
                doc.ColumnWidth = (doc.PageWidth - doc.ColumnGap
                - doc.PagePadding.Left - doc.PagePadding.Right) / 2;
                printDialog.PrintDocument(
                ((IDocumentPaginatorSource)doc).DocumentPaginator, "A Flow Document");

                // Reapply the old settings.
                doc.PageHeight = pageHeight;
                doc.PageWidth = pageWidth;
                doc.PagePadding = pagePadding;
                doc.ColumnGap = columnGap;
                doc.ColumnWidth = columnWidth;
            }
        }
    }
}
