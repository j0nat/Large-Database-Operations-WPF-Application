using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLDODemo.ExtensionMethods
{
    public static class StringExtensions
    {
        public static bool IsNumeric(this string text)
        {
            double test;
            return double.TryParse(text, out test);
        }
    }
}
