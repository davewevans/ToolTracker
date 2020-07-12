using ToolTracker.Interfaces;

namespace ToolTracker.Models
{
    public class Inmate : IInmate
    {
        public int Id { get; set; }
        public string GDCNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string FullName => $"{FirstName} {LastName}";
        
        public int? ShopId { get; set; }
        public virtual Shop AssignedShop  { get; set; }
    }
}
