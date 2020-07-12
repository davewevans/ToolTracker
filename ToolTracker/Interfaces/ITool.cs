using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolTracker.Models;

namespace ToolTracker.Interfaces
{
    interface ITool
    {
        int Id { get; set; }
        string ToolNumber { get; set; }
        string Description { get; set; }

        int? ShopId { get; set; }
        Shop AssignedShop { get; set; }
    }
}
