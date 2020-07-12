using System.Collections.Generic;

namespace ToolTracker.ViewModels
{
    public class ToolsIssuedShopGroup
    {
        private int _rowsPerPage = 15;
        public string ShopName { get; set; }
        public List<ToolIssuedViewModel> ToolsIssued { get; set; }

        public int PageCount
        {
            get
            {
                if (ToolsIssued.Count <= _rowsPerPage)
                    return 1;
                if (ToolsIssued.Count % _rowsPerPage == 0)
                    return ToolsIssued.Count / _rowsPerPage;
                if (ToolsIssued.Count == 0)
                    return 0;
                return ToolsIssued.Count / _rowsPerPage + 1;
            }
        }

        public int BlankRowsQty
        {
            get
            {
                if (ToolsIssued.Count % _rowsPerPage == 0)
                    return 0;
                if (ToolsIssued.Count < _rowsPerPage)
                    return _rowsPerPage - ToolsIssued.Count;
                if (ToolsIssued.Count > _rowsPerPage)
                {
                    int remainder = ToolsIssued.Count % _rowsPerPage;
                    return _rowsPerPage - remainder;
                }
                return ToolsIssued.Count == 0 ? 15 : 0;
            }
        }

        public ToolsIssuedShopGroup()
        {
            ToolsIssued = new List<ToolIssuedViewModel>();
        }
    }
}
