using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolTracker.ViewModels;

namespace ToolTracker.Comparers
{
    class ToolComparer : IComparer<ToolViewModel>
    {
        public int Compare(ToolViewModel x, ToolViewModel y)
        {
            return string.Compare(x.ToolNumber, y.ToolNumber, StringComparison.Ordinal);
        }
    }
}
