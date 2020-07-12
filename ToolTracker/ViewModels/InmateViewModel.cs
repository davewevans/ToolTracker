using System.Collections.ObjectModel;
using ToolTracker.Models;
using ToolTracker.Interfaces;
using ToolTracker.Services;

namespace ToolTracker.ViewModels
{
    public class InmateViewModel : IInmate
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // Returns last name comma first name. eg: Smith, John
        public string LastCommaFirst => $"{LastName}, {FirstName}";

        public string GDCNumber { get; set; }
        public int? ShopId { get; set; }
        public Shop AssignedShop { get; set; }

        public ObservableCollection<Shop> Shops => ToolTrackerService.Shops;

        // Index position in the collection bound to dropdown list
        public int ShopIndex { get; set; }
    }
}
