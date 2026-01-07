using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace DVLD
{
    internal class clsSecuirty
    {

        /// <summary>
        /// Hash Password
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public static string ComputeHash(string Input) 
        {

            using (SHA256 sHA256 = SHA256.Create())
            {

                byte[] HashBytes = sHA256.ComputeHash(Encoding.UTF8.GetBytes(Input));
                return BitConverter.ToString(HashBytes).Replace("-", "").ToLower();

            }

        }







    }
}
