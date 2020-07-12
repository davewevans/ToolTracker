using System.Collections.ObjectModel;
using ToolTracker.Models;
using ToolTracker.Interfaces;
using ToolTracker.Services;

namespace ToolTracker.ViewModels
{
    class ToolViewModel : ITool
    {
        public int Id { get; set; }
        public string ToolNumber { get; set; }
        public string Description { get; set; }

        public int? ShopId { get; set; }
        public Shop AssignedShop { get; set; }

        public ObservableCollection<Shop> Shops => ToolTrackerService.Shops;

        // Index position in the collection bound to dropdown list
        public int ShopIndex { get; set; }
    }
}
