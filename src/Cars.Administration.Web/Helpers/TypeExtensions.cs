using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Cars.Administration.Web.Helpers
{
	public static class TypeExtensions
	{
		public static bool IsNull(this object input)
		{
			return input == null;
		}

		public static decimal ToDecimal(this string input)
		{
			decimal dec;
			decimal.TryParse(input, out dec);
			return dec;
		}

		public static string ToStringWithSpaces(this string input)
		{
			return Regex.Replace(input, "(?<!^)([A-Z][a-z]|(?<=[a-z])[A-Z]|(?<![A-Z])[A-Z]$)", " $1",
				RegexOptions.IgnorePatternWhitespace);
		}
	}
}