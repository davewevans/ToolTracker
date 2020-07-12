using System;
using System.Data;
using System.Globalization;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;
using ToolTracker.Models;
using ToolTracker.Services;

namespace ToolTracker.Printing
{
    public class DataSetPaginator : DocumentPaginator
    {
        private readonly DataTable _dt;
        private readonly Typeface _typeface;
        private readonly double _fontSize;
        private readonly double _margin;
        private int _rowsPerPage;
        private Size _pageSize;
        private int _pageCount;
        private Typeface _columnHeaderTypeface;
        private double _headerMargin;
        private FormattedText _locationText;

        #region Set column widths
        double col1Width = .75 * 96;
        double col2Width = 1.80 * 96;
        double col3Width = 1.30 * 96;
        double col4Width = 1.25 * 96;
        double col5Width = .5 * 96;
        double col6Width = .5 * 96;
        double col7Width = .5 * 96;
        double col8Width = .5 * 96;
        double col9Width = 1.30 * 96;
        double col10Width = 1.25 * 96;
        #endregion

        // Always returns true, because the page count is updated immediately,
        // and synchronously, when the page size changes.
        // It's never left in an indeterminate state.
        public override bool IsPageCountValid => true;

        public override int PageCount => _pageCount;

        public override Size PageSize
        {
            get { return _pageSize; }
            set
            {
                _pageSize = value;
                PaginateData();
            }
        }

        public DataSetPaginator(DataTable dt, Typeface typeface,
            double fontSize, double margin, Size pageSize, int rowsPerPage)
        {
            _dt = dt;
            _typeface = typeface;
            _fontSize = fontSize;
            _margin = margin;
            _pageSize = pageSize;
            _rowsPerPage = rowsPerPage;
            _columnHeaderTypeface = new Typeface(_typeface.FontFamily, 
                FontStyles.Normal, FontWeights.Normal, FontStretches.Normal);

            PaginateData();
        }

        public override DocumentPage GetPage(int pageNumber)
        {
            // Please re-factor me!

            #region Set column header text
            var col1Header = GetFormattedText("TOOL NO.", _columnHeaderTypeface);
            var col2Header = GetFormattedText("DESCRIPTION", _columnHeaderTypeface);
            var col3Header = GetFormattedText("RECEIVED BY", _columnHeaderTypeface);
            var col4Header = GetFormattedText("ISSUED BY", _columnHeaderTypeface);
            var col5Header = GetFormattedText("OUT", _columnHeaderTypeface);
            var col6Header = GetFormattedText("OUT", _columnHeaderTypeface);
            var col7Header = GetFormattedText("IN", _columnHeaderTypeface);
            var col8Header = GetFormattedText("IN", _columnHeaderTypeface);
            var col9Header = GetFormattedText("RETURNED BY", _columnHeaderTypeface);
            var col10Header = GetFormattedText("RECEIVED BY", _columnHeaderTypeface);
            #endregion

            #region Table margins
            double tableMarginLR = 96 * .7;
            double tableMarginTop = _margin * 2.3;
            double tableMarginBottom = _margin * 1.7;
            #endregion

            // Create a test string for the purposes of measurement.
            FormattedText text = GetFormattedText("A");

            // Calculate the range of rows that fits on this page.
            int minRow = pageNumber * (_rowsPerPage - 1);
            int maxRow = minRow + _rowsPerPage - 1;

            var linePen = new Pen(Brushes.Black, 1);

            // Create the visual for the page.
            var visual = new DrawingVisual();

            // Set the position to the top-left corner of the printable area.
            Point point = new Point(_margin, _margin);
            using (DrawingContext dc = visual.RenderOpen())
            {

                #region Draw table border
                dc.DrawLine(linePen,
                    new Point(tableMarginLR, tableMarginTop),
                    new Point(_pageSize.Width - tableMarginLR, tableMarginTop));

                dc.DrawLine(linePen,
                    new Point(tableMarginLR, tableMarginTop),
                    new Point(tableMarginLR, _pageSize.Height - tableMarginBottom));

                dc.DrawLine(linePen,
                    new Point(tableMarginLR, _pageSize.Height - tableMarginBottom),
                    new Point(_pageSize.Width - tableMarginLR, _pageSize.Height - tableMarginBottom));

                dc.DrawLine(linePen,
                    new Point(_pageSize.Width - tableMarginLR, _pageSize.Height - tableMarginBottom),
                    new Point(_pageSize.Width - tableMarginLR, tableMarginTop));
                #endregion

                #region Set row heights
                double rowHeight = .3823529 * 96;
                double row1 = tableMarginTop + rowHeight;
                double row2 = row1 + rowHeight;
                double row3 = row2 + rowHeight;
                double row4 = row3 + rowHeight;
                double row5 = row4 + rowHeight;
                double row6 = row5 + rowHeight;
                double row7 = row6 + rowHeight;
                double row8 = row7 + rowHeight;
                double row9 = row8 + rowHeight;
                double row10 = row9 + rowHeight;
                double row11 = row10 + rowHeight;
                double row12 = row11 + rowHeight;
                double row13 = row12 + rowHeight;
                double row14 = row13 + rowHeight;
                double row15 = row14 + rowHeight;
                double row16 = row15 + rowHeight;
                #endregion

                #region Draw table row borders
                dc.DrawLine(linePen,
                    new Point(tableMarginLR, row1),
                    new Point(_pageSize.Width - tableMarginLR, row1));
                dc.DrawLine(linePen,
                    new Point(tableMarginLR, row2),
                    new Point(_pageSize.Width - tableMarginLR, row2));
                dc.DrawLine(linePen,
                    new Point(tableMarginLR, row3),
                    new Point(_pageSize.Width - tableMarginLR, row3));
                dc.DrawLine(linePen,
                    new Point(tableMarginLR, row4),
                    new Point(_pageSize.Width - tableMarginLR, row4));
                dc.DrawLine(linePen,
                    new Point(tableMarginLR, row5),
                    new Point(_pageSize.Width - tableMarginLR, row5));
                dc.DrawLine(linePen,
                    new Point(tableMarginLR, row6),
                    new Point(_pageSize.Width - tableMarginLR, row6));
                dc.DrawLine(linePen,
                    new Point(tableMarginLR, row7),
                    new Point(_pageSize.Width - tableMarginLR, row7));
                dc.DrawLine(linePen,
                    new Point(tableMarginLR, row8),
                    new Point(_pageSize.Width - tableMarginLR, row8));
                dc.DrawLine(linePen,
                    new Point(tableMarginLR, row9),
                    new Point(_pageSize.Width - tableMarginLR, row9));
                dc.DrawLine(linePen,
                    new Point(tableMarginLR, row10),
                    new Point(_pageSize.Width - tableMarginLR, row10));
                dc.DrawLine(linePen,
                    new Point(tableMarginLR, row11),
                    new Point(_pageSize.Width - tableMarginLR, row11));
                dc.DrawLine(linePen,
                    new Point(tableMarginLR, row12),
                    new Point(_pageSize.Width - tableMarginLR, row12));
                dc.DrawLine(linePen,
                    new Point(tableMarginLR, row13),
                    new Point(_pageSize.Width - tableMarginLR, row13));
                dc.DrawLine(linePen,
                    new Point(tableMarginLR, row14),
                    new Point(_pageSize.Width - tableMarginLR, row14));
                dc.DrawLine(linePen,
                    new Point(tableMarginLR, row15),
                    new Point(_pageSize.Width - tableMarginLR, row15));
                dc.DrawLine(linePen,
                    new Point(tableMarginLR, row16),
                    new Point(_pageSize.Width - tableMarginLR, row16));
                #endregion

                #region Set table column borders
                double col1and2BorderX = tableMarginLR + col1Width;
                double col2and3BorderX = col1and2BorderX + col2Width;
                double col3and4BorderX = col2and3BorderX + col3Width;
                double col4and5BorderX = col3and4BorderX + col4Width;
                double col5and6BorderX = col4and5BorderX + col5Width;
                double col6and7BorderX = col5and6BorderX + col6Width;
                double col7and8BorderX = col6and7BorderX + col7Width;
                double col8and9BorderX = col7and8BorderX + col8Width;
                double col9and10BorderX = col8and9BorderX + col9Width;
                #endregion

                #region Draw table column borders
                dc.DrawLine(linePen,
                    new Point(col1and2BorderX, tableMarginTop),
                    new Point(col1and2BorderX, _pageSize.Height - tableMarginBottom));
                dc.DrawLine(linePen,
                   new Point(col2and3BorderX, tableMarginTop),
                   new Point(col2and3BorderX, _pageSize.Height - tableMarginBottom));
                dc.DrawLine(linePen,
                   new Point(col3and4BorderX, tableMarginTop),
                   new Point(col3and4BorderX, _pageSize.Height - tableMarginBottom));
                dc.DrawLine(linePen,
                   new Point(col4and5BorderX, tableMarginTop),
                   new Point(col4and5BorderX, _pageSize.Height - tableMarginBottom));
                dc.DrawLine(linePen,
                   new Point(col5and6BorderX, tableMarginTop),
                   new Point(col5and6BorderX, _pageSize.Height - tableMarginBottom));
                dc.DrawLine(linePen,
                   new Point(col6and7BorderX, tableMarginTop),
                   new Point(col6and7BorderX, _pageSize.Height - tableMarginBottom));
                dc.DrawLine(linePen,
                   new Point(col7and8BorderX, tableMarginTop),
                   new Point(col7and8BorderX, _pageSize.Height - tableMarginBottom));
                dc.DrawLine(linePen,
                   new Point(col8and9BorderX, tableMarginTop),
                   new Point(col8and9BorderX, _pageSize.Height - tableMarginBottom));
                dc.DrawLine(linePen,
                   new Point(col9and10BorderX, tableMarginTop),
                   new Point(col9and10BorderX, _pageSize.Height - tableMarginBottom));
                #endregion

                #region Set column header text padding
                double colHeader1_X = tableMarginLR + (col1Width - col1Header.Width) / 2;
                double colHeader2_X = col1and2BorderX + (col2Width - col2Header.Width) / 2;
                double colHeader3_X = col2and3BorderX + (col3Width - col3Header.Width) / 2;
                double colHeader4_X = col3and4BorderX + (col4Width - col4Header.Width) / 2;
                double colHeader5_X = col4and5BorderX + (col5Width - col5Header.Width) / 2;
                double colHeader6_X = col5and6BorderX + (col6Width - col6Header.Width) / 2;
                double colHeader7_X = col6and7BorderX + (col7Width - col7Header.Width) / 2;
                double colHeader8_X = col7and8BorderX + (col8Width - col8Header.Width) / 2;
                double colHeader9_X = col8and9BorderX + (col9Width - col9Header.Width) / 2;
                double colHeader10_X = col9and10BorderX + (col10Width - col10Header.Width) / 2;
                #endregion

                #region Draw header text
                _headerMargin = .7 * 96;

                _locationText = GetFormattedText("LOCATION", _columnHeaderTypeface);
                dc.DrawText(_locationText, new Point(_headerMargin, _headerMargin));

                // Draw shop name here if only one shop selected
                if (!PrintingService.AllShopsSelected)
                {
                    var shopName = GetFormattedText(PrintingService.ShopName.ToUpper(), _columnHeaderTypeface);
                    dc.DrawText(shopName, new Point(_headerMargin + _locationText.Width + 5, _headerMargin));
                }
                

                dc.DrawLine(linePen,
                    new Point(_headerMargin + _locationText.Width, _headerMargin + _locationText.Height),
                    new Point(_headerMargin + _locationText.Width + 150, _headerMargin + _locationText.Height));


                double headerPaddingTop = (rowHeight - text.Height) / 2;
                double tableHeaderY = tableMarginTop + headerPaddingTop;

                var headerPoint = new Point ();
                headerPoint.Y = tableHeaderY;

                headerPoint.X = colHeader1_X;
                dc.DrawText(col1Header, headerPoint);

                headerPoint.X = colHeader2_X;
                dc.DrawText(col2Header, headerPoint);

                headerPoint.X = colHeader3_X;
                dc.DrawText(col3Header, headerPoint);

                headerPoint.X = colHeader4_X;
                dc.DrawText(col4Header, headerPoint);

                headerPoint.X = colHeader5_X;
                dc.DrawText(col5Header, headerPoint);

                headerPoint.X = colHeader6_X;
                dc.DrawText(col6Header, headerPoint);

                headerPoint.X = colHeader7_X;
                dc.DrawText(col7Header, headerPoint);

                headerPoint.X = colHeader8_X;
                dc.DrawText(col8Header, headerPoint);

                headerPoint.X = colHeader9_X;
                dc.DrawText(col9Header, headerPoint);

                headerPoint.X = colHeader10_X;
                dc.DrawText(col10Header, headerPoint);

                
                text = GetFormattedText("TOOLS ISSUED", _columnHeaderTypeface);
                double headerCenteredTextX = (_pageSize.Width - text.Width) / 2;
                dc.DrawText(text, new Point(headerCenteredTextX, _headerMargin));

                dc.DrawLine(linePen,
                   new Point(headerCenteredTextX, _headerMargin + text.Height),
                   new Point(headerCenteredTextX + text.Width, _headerMargin + text.Height));
              
                var text1 = GetFormattedText(SettingsService.Settings.FormInfo.Line1, _columnHeaderTypeface);
                double x = _pageSize.Width - _headerMargin - text1.Width;
                double y = _headerMargin;
                dc.DrawText(text1, new Point(x, y));

                var text2 = GetFormattedText(SettingsService.Settings.FormInfo.Line2, _columnHeaderTypeface);
                x = x + (text1.Width - text2.Width) / 2;
                y = y + text1.Height;
                dc.DrawText(text2, new Point(x, y));

                var text3 = GetFormattedText(SettingsService.Settings.FormInfo.Line3, _columnHeaderTypeface);
                x = x + (text2.Width - text3.Width) / 2;
                y = y + text2.Height;
                dc.DrawText(text3, new Point(x, y));

                var headerDate = GetFormattedText("DATE", _columnHeaderTypeface);
                var headerTime = GetFormattedText("TIME", _columnHeaderTypeface);
                y = tableMarginTop - .15 * 96;

                x = col4and5BorderX + (col5Width - headerDate.Width) / 2;
                dc.DrawText(headerDate, new Point(x, y));

                x = col5and6BorderX + (col5Width - headerTime.Width) / 2;
                dc.DrawText(headerTime, new Point(x, y));

                x = col6and7BorderX + (col5Width - headerDate.Width) / 2;
                dc.DrawText(headerDate, new Point(x, y));

                x = col7and8BorderX + (col5Width - headerTime.Width) / 2;
                dc.DrawText(headerTime, new Point(x, y));
                #endregion

                #region Draw footer text
                string footerLine1Str = "RETENTION SCHEDULE: This form shall be kept on file for six months and then destroyed.";
                var footerLine1 = GetFormattedText(footerLine1Str, _columnHeaderTypeface);
                x = .7 * 96;
                y = _pageSize.Height - .7 * 96;
                dc.DrawText(footerLine1, new Point(x, y));


                string footerLine2Str = "REPRODUCE LOCALLY";
                var footerLine2 = GetFormattedText(footerLine2Str, _columnHeaderTypeface);
                x = _pageSize.Width - .7 * 96 - 300;
                y = _pageSize.Height - .8 * 96;
                dc.DrawText(footerLine2, new Point(x, y));
                #endregion

                #region Set cell text padding and X coordinate
                double leftPading = .03 * 96;
                double colData1_X = tableMarginLR + leftPading;
                double colData2_X = col1and2BorderX + leftPading;
                double colData3_X = col2and3BorderX + leftPading;
                double colData4_X = col3and4BorderX + leftPading;
                double colData5_X = col4and5BorderX + leftPading;
                double colData6_X = col5and6BorderX + leftPading;
                double colData7_X = col6and7BorderX + leftPading;
                double colData8_X = col7and8BorderX + leftPading;
                double colData9_X = col8and9BorderX + leftPading;
                double colData10_X = col9and10BorderX + leftPading;
                #endregion

                // Draw shop name for each group if 'All Shops' selected
                if (PrintingService.AllShopsSelected)
                {
                    var shopName = GetFormattedText(PrintingService.ShopNames[PrintingService.ShopNamesCounter].ToUpper(), _columnHeaderTypeface);
                    dc.DrawText(shopName, new Point(_headerMargin + _locationText.Width + 5, _headerMargin));
                    PrintingService.ShopNamesCounter++;
                }

                double rowBorderY = tableMarginTop + rowHeight;

                DrawFormData(minRow, maxRow, point, colData1_X, rowBorderY, rowHeight, dc, colData2_X, colData3_X, colData4_X, colData5_X, colData6_X, colData7_X, colData8_X, colData9_X, colData10_X);

            }
            return new DocumentPage(visual, _pageSize, new Rect(_pageSize),
                                    new Rect(_pageSize));
        }

        private void DrawFormData(int minRow, int maxRow, Point point, double colData1_X, double rowBorderY, double rowHeight,
            DrawingContext dc, double colData2_X, double colData3_X, double colData4_X, double colData5_X, double colData6_X,
            double colData7_X, double colData8_X, double colData9_X, double colData10_X)
        {
            // Leave first row blank if setting is true
            if(SettingsService.Settings.SkipFirstRow)
                rowBorderY = rowBorderY + rowHeight;

            FormattedText text;
            for (int i = minRow; i < maxRow; i++)
            {
                // Check for the end of the last page.
                if (i > _dt.Rows.Count - 1) break;
                int subtractNumForTrim = 3;

                point.X = colData1_X;
                text = GetFormattedText(_dt.Rows[i]["ToolNo"].ToString());
                point.Y = rowBorderY + (rowHeight - text.Height)/2;
                text.Trimming = TextTrimming.CharacterEllipsis;
                text.MaxTextWidth = col1Width - subtractNumForTrim;
                dc.DrawText(text, point);

                point.X = colData2_X;
                text = GetFormattedText(_dt.Rows[i]["Description"].ToString());
                point.Y = rowBorderY + (rowHeight - text.Height)/2;
                text.Trimming = TextTrimming.CharacterEllipsis;
                text.MaxTextWidth = col2Width - subtractNumForTrim;
                dc.DrawText(text, point);

                point.X = colData3_X;
                text = GetFormattedText(_dt.Rows[i]["ReceivedByInmate"].ToString());
                point.Y = rowBorderY + (rowHeight - text.Height)/2;
                text.Trimming = TextTrimming.CharacterEllipsis;
                text.MaxTextWidth = col3Width - subtractNumForTrim;
                dc.DrawText(text, point);

                point.X = colData4_X;
                text = GetFormattedText(_dt.Rows[i]["IssuedBy"].ToString());
                point.Y = rowBorderY + (rowHeight - text.Height)/2;
                text.Trimming = TextTrimming.CharacterEllipsis;
                text.MaxTextWidth = col4Width - subtractNumForTrim;
                dc.DrawText(text, point);

                point.X = colData5_X;
                text = GetFormattedText(_dt.Rows[i]["DateOut"].ToString());
                point.Y = rowBorderY + (rowHeight - text.Height)/2;
                dc.DrawText(text, point);

                point.X = colData6_X;
                text = GetFormattedText(_dt.Rows[i]["TimeOut"].ToString());
                point.Y = rowBorderY + (rowHeight - text.Height)/2;
                dc.DrawText(text, point);

                point.X = colData7_X;
                text = GetFormattedText(_dt.Rows[i]["DateIn"].ToString());
                point.Y = rowBorderY + (rowHeight - text.Height)/2;
                dc.DrawText(text, point);

                point.X = colData8_X;
                text = GetFormattedText(_dt.Rows[i]["TimeIn"].ToString());
                point.Y = rowBorderY + (rowHeight - text.Height)/2;
                dc.DrawText(text, point);

                point.X = colData9_X;
                text = GetFormattedText(_dt.Rows[i]["ReturnedBy"].ToString());
                point.Y = rowBorderY + (rowHeight - text.Height)/2;
                text.Trimming = TextTrimming.CharacterEllipsis;
                text.MaxTextWidth = col9Width - subtractNumForTrim;
                dc.DrawText(text, point);

                if (!SettingsService.Settings.LeaveReceivedByOfficerBlank)
                {
                    point.X = colData10_X;
                    text = GetFormattedText(_dt.Rows[i]["ReveivedByOfficer"].ToString());
                    point.Y = rowBorderY + (rowHeight - text.Height) / 2;
                    text.Trimming = TextTrimming.CharacterEllipsis;
                    text.MaxTextWidth = col10Width - subtractNumForTrim - 2;
                    dc.DrawText(text, point);
                }
              

                rowBorderY = rowBorderY + rowHeight;
            }
        }

        private void PaginateData()
        {
            // Leave a row for the headings
            _rowsPerPage -= 1;
            if(!PrintingService.AllShopsSelected)
                _pageCount = (int)Math.Ceiling((double)_dt.Rows.Count / _rowsPerPage);
            else // 'All Shops' selected
                _pageCount = PrintingService.PageCount;
        }

        private FormattedText GetFormattedText(string text)
        {
            return GetFormattedText(text, _typeface);
        }

        private FormattedText GetFormattedText(string text, Typeface typeface)
        {
            return new FormattedText(
                text, CultureInfo.CurrentCulture, FlowDirection.LeftToRight,
                typeface, _fontSize, Brushes.Black);
        }

        public override IDocumentPaginatorSource Source { get; }
    }
}
