using System.Collections.Generic;
using ToolTracker.Interfaces;

namespace ToolTracker.Models
{
    public class Tool : ITool
    {
        public int Id { get; set; }
        public string ToolNumber { get; set; }
        public string Description { get; set; }

        public int? ShopId { get; set; }
        public virtual Shop AssignedShop { get; set; }
        
        public virtual ICollection<ToolIssued> ToolsIssued { get; set; } 

    }
}
