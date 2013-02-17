using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace NetLicensing
{
    class Encryption
    {
        //EncryptString
        //Key1 MUST BE 16 IN LENGTH
        //Key2 MUST BE 32 IN LENGTH
        public string EncryptString(string ClearText, string key1, string key2)
        {

            byte[] clearTextBytes = Encoding.UTF8.GetBytes(ClearText);

            System.Security.Cryptography.SymmetricAlgorithm rijn = SymmetricAlgorithm.Create();

            MemoryStream ms = new MemoryStream();
            byte[] rgbIV = Encoding.ASCII.GetBytes(key1);
            byte[] key = Encoding.ASCII.GetBytes(key2);
            CryptoStream cs = new CryptoStream(ms, rijn.CreateEncryptor(key, rgbIV),
       CryptoStreamMode.Write);

            cs.Write(clearTextBytes, 0, clearTextBytes.Length);

            cs.Close();

            return Convert.ToBase64String(ms.ToArray());
        }

        //DecryptString
        //Make sure you use the same keys you used to encrypt the string
        public string DecryptString(string EncryptedText, string key1, string key2)
        {
            byte[] encryptedTextBytes = Convert.FromBase64String(EncryptedText);

            MemoryStream ms = new MemoryStream();

            System.Security.Cryptography.SymmetricAlgorithm rijn = SymmetricAlgorithm.Create();


            byte[] rgbIV = Encoding.ASCII.GetBytes(key1);
            byte[] key = Encoding.ASCII.GetBytes(key2);

            CryptoStream cs = new CryptoStream(ms, rijn.CreateDecryptor(key, rgbIV),
            CryptoStreamMode.Write);

            cs.Write(encryptedTextBytes, 0, encryptedTextBytes.Length);

            cs.Close();

            return Encoding.UTF8.GetString(ms.ToArray());

        }
    }
}
