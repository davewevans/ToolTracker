using System.ComponentModel.DataAnnotations.Schema;

namespace ToolTracker.Models
{
    /// <summary>
    /// Join table that stores inmates shop assignment. 
    /// </summary>
    [Table("ShopAssignment")]
    public class ShopAssignment
    {
        public int Id { get; set; }
        public int InmateId { get; set; }
        public int ShopId { get; set; }
    }
}
