using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace TDH.Basketball.Game.EF.Manager.Util
{
    public static class Utils
    {
        public static string GetPaymentCode(string InputString)
        {
            return String.Format("{0:X}", InputString.GetHashCode());
        }
        public static string GetSHA256Hash(string InputString)
        {
            byte[] data = Encoding.UTF8.GetBytes(InputString);

            using (SHA256 sha256Hash = SHA256.Create())
            {
                return BitConverter.ToString(sha256Hash.ComputeHash(data)).Replace("-", string.Empty);
            }
        }
    }
}
