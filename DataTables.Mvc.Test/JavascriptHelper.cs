using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataTables.Mvc.Test
{
    public static class JavascriptHelper
    {
        public static string AsLower(this bool boolean)
        {
            return boolean.ToString().ToLowerInvariant();
        }
    }
}
