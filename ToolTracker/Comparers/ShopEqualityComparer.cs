using System.Collections.Generic;
using ToolTracker.Models;

namespace ToolTracker.Comparers
{
    public class ShopEqualityComparer : IEqualityComparer<Shop>
    {
        public bool Equals(Shop x, Shop y)
        {
            return x.Id == y.Id;
        }

        public int GetHashCode(Shop obj)
        {
           return obj.Id.GetHashCode();
        }
    }
}
