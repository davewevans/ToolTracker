using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolTracker.ViewModels;

namespace ToolTracker.Comparers
{
    class InmateComparer : IComparer<InmateViewModel>
    {
        public int Compare(InmateViewModel x, InmateViewModel y)
        {
            return string.Compare(x.LastName, y.LastName, StringComparison.Ordinal);
        }
    }
}
