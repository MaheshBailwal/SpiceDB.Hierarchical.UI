using Azure.Storage.Blobs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SpiceDB.UI
{
    public static class MyHelper
    {
        public static bool ValidateKey(string key)
        {
            string regexPattern = @"^([a-z][a-z0-9_]{1,62}[a-z0-9])?$";
            var regex = new Regex(regexPattern, RegexOptions.IgnoreCase);
            return regex.IsMatch(key);
        }

    }
}
