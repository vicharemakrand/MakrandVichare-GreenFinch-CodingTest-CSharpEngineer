using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Linq;

namespace CodingTest.Utility
{
    public class AppMethods
    {
        public static string CorrectCollectionName(string className)
        {
            return className.Replace("EntityModel", "");
        }

        public static string GetHash(string input)
        {
            HashAlgorithm hashAlgorithm = new SHA256CryptoServiceProvider();

            byte[] byteValue = System.Text.Encoding.UTF8.GetBytes(input);

            byte[] byteHash = hashAlgorithm.ComputeHash(byteValue);

            return Convert.ToBase64String(byteHash);
        }

        public static List<long> StringToLongList(string commaSeparatedStr)
        {
            var stringIds = commaSeparatedStr.Split(',').ToList();
            var longIds = new List<long>();
            foreach (string s in stringIds)
            {
                long val;

                if (long.TryParse(s, out val))
                {
                    longIds.Add(val);
                }
            }

            return longIds;
        }
    }
}
