using ToolTracker.Models;

namespace ToolTracker.Interfaces
{
    public interface IInmate
    {
        int Id { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string GDCNumber { get; set; }
        int? ShopId { get; set; }
        Shop AssignedShop { get; set; }
    }
}
