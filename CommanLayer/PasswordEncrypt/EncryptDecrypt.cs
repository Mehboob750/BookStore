using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace CommanLayer.PasswordEncrypt
{
    /// <summary>
    /// This Class contains the Encrypt Method 
    /// </summary>
    public class EncryptDecrypt
    {
        /// <summary>
        /// This Method is Used to encrypt the password
        /// </summary>
        /// <param name="password">It contains the Password</param>
        /// <returns>It returns the Encrypted Password</returns>
        public string EncodePasswordToBase64(string password)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            byte[] inArray = HashAlgorithm.Create("SHA1").ComputeHash(bytes);
            return Convert.ToBase64String(inArray);
        }
    }
}
