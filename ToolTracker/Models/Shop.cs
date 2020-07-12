using System.Collections.Generic;

namespace ToolTracker.Models
{
    public class Shop
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Inmate> AssignedInmates { get; set; }
        public virtual ICollection<Tool> Tools  { get; set; } 
    }
}
