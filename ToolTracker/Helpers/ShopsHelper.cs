using System.Collections;
using ToolTracker.Services;

//
// not used for now
//

namespace ToolTracker.Helpers
{
    class ShopsHelper
    {
        public static IEnumerable GetShops()
        {
            foreach (var shop in ToolTrackerService.Shops)
            {
                yield return shop;
            }
        } 
    }
}
