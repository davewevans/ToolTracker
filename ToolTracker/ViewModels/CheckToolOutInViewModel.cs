using ToolTracker.Models;

namespace ToolTracker.ViewModels
{
    class CheckToolOutInViewModel
    {
        public bool IsCheckedOut { get; set; }
        public string ToolNumber { get; set; }
        public string ToolDescription { get; set; }
        public string ShopName { get; set; }
        public int InmateId { get; set; }
        public Inmate Inmate { get; set; }
        public int ToolId { get; set; }
        public int ToolIssuedId { get; set; }
        public bool ToolReturned { get; set; }
        public string InmateNameAndGDC => Inmate != null && IsCheckedOut ? $"{Inmate.FirstName.Substring(0,1)}. {Inmate.LastName} #{Inmate.GDCNumber}" : "";
    }
}
