using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolTracker.Models;

namespace ToolTracker.Comparers
{
    class ShopComparer : IComparer<Shop>
    {
        public int Compare(Shop x, Shop y)
        {
            return string.Compare(x.Name, y.Name, StringComparison.Ordinal);
        }
    }
}
