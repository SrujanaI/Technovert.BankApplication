using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;



namespace Technovert.BankApp.CLI.ConsoleFiles
{
    public class PasswordEncryption
    {
        private const string SecurityKey = "#@#$%%&*%$##!@#$%^&*())(*&^%$#@!";
        public string EncryptPlainTextToCipherText(string PlainText)
        {
            byte[] toEncryptedArray = UTF8Encoding.UTF8.GetBytes(PlainText);

            MD5CryptoServiceProvider objMD5CryptoService = new MD5CryptoServiceProvider();

            byte[] securityKeyArray = objMD5CryptoService.ComputeHash(UTF8Encoding.UTF8.GetBytes(SecurityKey));

            objMD5CryptoService.Clear();

            var objTripleDESCryptoService = new TripleDESCryptoServiceProvider();

            objTripleDESCryptoService.Key = securityKeyArray;

            objTripleDESCryptoService.Mode = CipherMode.ECB;

            objTripleDESCryptoService.Padding = PaddingMode.PKCS7;

            var objCrytpoTransform = objTripleDESCryptoService.CreateEncryptor();

            byte[] resultArray = objCrytpoTransform.TransformFinalBlock(toEncryptedArray, 0, toEncryptedArray.Length);
            objTripleDESCryptoService.Clear();
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }
    }
}