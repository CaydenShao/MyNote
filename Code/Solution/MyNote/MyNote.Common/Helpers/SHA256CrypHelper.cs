using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.Common.Helpers
{
    public static class SHA256CrypHelper
    {
        public static string GetHashStr(string source)
        {
            byte[] passwordAndSaltBytes = Encoding.UTF8.GetBytes(source);
            byte[] hashBytes = new SHA256Managed().ComputeHash(passwordAndSaltBytes);
            return Convert.ToBase64String(hashBytes);
        }
    }
}
