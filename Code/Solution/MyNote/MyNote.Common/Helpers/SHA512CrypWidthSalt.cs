using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace MyNote.Common.Helpers
{
    public class SHA512CrypWidthSalt
    {
        private readonly string source = string.Empty;
        private readonly string salt = string.Empty;
        private readonly string hashString = string.Empty;

        #region Constructors

        public SHA512CrypWidthSalt(string _source, string _salt, string _hasString)
        {
            this.source = _source;
            this.salt = _salt;
            this.hashString = _hasString;
        }

        #endregion

        #region Properties

        public string Source
        {
            get
            {
                return this.source;
            }
        }

        public string Salt
        {
            get
            {
                return this.salt;
            }
        }

        public string HashString
        {
            get
            {
                return this.hashString;
            }
        }

        public bool CanMatch
        {
            get
            {
                byte[] passwordAndSaltBytes = Encoding.UTF8.GetBytes(this.source + this.salt);
                byte[] hashBytes = new SHA512Managed().ComputeHash(passwordAndSaltBytes);
                string resultHashString = Convert.ToBase64String(hashBytes);
                return resultHashString == this.hashString;
            }
        }

        #endregion

        #region Public methods

        public override string ToString()
        {
            return string.Format("Source:{0};Salt:{1};HashString:{2}", this.source, this.salt, this.hashString);
        }

        #endregion

        #region Static methods

        public static SHA512CrypWidthSalt Encrypt(string source)
        {
            /********** 用RNGCryptoServiceProvider获取salt **********/
            //RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            //byte[] saltBytes = new byte[36];
            //rng.GetBytes(saltBytes);
            //// 将byte[]转换为string，可以使用Base64String，也可以使用下面的ToHexString方法
            //string salt = Convert.ToBase64String(saltBytes);
            ////string salt = ToHexString(hashBytes);
            /********************************************************/
            string salt = Guid.NewGuid().ToString();
            byte[] passwordAndSaltBytes = Encoding.UTF8.GetBytes(source + salt);
            byte[] hashBytes = new SHA512Managed().ComputeHash(passwordAndSaltBytes);
            // 将byte[]转换为string，可以使用Base64String，也可以使用下面的ToHexString方法
            string hashString = Convert.ToBase64String(hashBytes);
            return new SHA512CrypWidthSalt(source, salt, hashString);
        }

        private static string ToHexString(byte[] bytes)
        {
            StringBuilder hex = new StringBuilder();

            foreach (byte b in bytes)
            {
                hex.AppendFormat("{0:x2}", b);
            }

            return hex.ToString();
        }

        public static bool IsMatch(string source, string salt, string hashString)
        {
            byte[] passwordAndSaltBytes = Encoding.UTF8.GetBytes(source + salt);
            byte[] hashBytes = new SHA512Managed().ComputeHash(passwordAndSaltBytes);
            string resultHashString = Convert.ToBase64String(hashBytes);
            return resultHashString == hashString;
        }

        #endregion
    }
}
