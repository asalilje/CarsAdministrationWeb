using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cars.Administration.Web.Helpers
{
    public static class TypeExtensions
    {

        public static bool IsNull(this object obj)
        {
            return obj == null;
        }

        public static decimal ToDecimal(this string str)
        {
            decimal dec;
            decimal.TryParse(str, out dec);
            return dec;
        }
    }
}