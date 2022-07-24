using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpiceDB.UI
{
    public static class StringExtensions
    {
        public static string RemoveParenthesis(this string text)
        {
            return text.Contains('(') ? text.Substring(0, text.IndexOf("(")).Trim() : text;
        }
        public static string RemoveParenthesisFromPath(this string text)
        {
            if (string.IsNullOrEmpty(text))
                return "";

            if (!text.Contains('('))
                return text;

            var paths = text.Split('\\');

            for (var i = 0; i < paths.Length; i++)
            {
                paths[i] = paths[i].RemoveParenthesis();
            }

            return string.Join('\\', paths);
        }
    }
}
