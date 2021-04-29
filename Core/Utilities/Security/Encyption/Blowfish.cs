using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Core.Utilities.Security.Encyption
{
    public static class Blowfish 
    {
        //private static string key = "suIs214m.K.Eemqe";
        //private static string iv = "jgIl03.E.IhjsIl.";

        private static string Hex2bin(string hex)
        {
            byte[] buf = new byte[hex.Length / 2];
            for (int i = 0; i < hex.Length / 2; i++)
            {
                buf[i] = Convert.ToByte(hex.Substring(i * 2, 2), 16);
            }
            return Convert.ToBase64String(buf);
        }


        public static string Decrypt(string str,string key, string iv)
        {
            String result;

            RijndaelManaged rijn = new RijndaelManaged();
            rijn.Mode = CipherMode.CBC;
            rijn.Padding = PaddingMode.Zeros;

            using (MemoryStream msDecrypt = new MemoryStream(Convert.FromBase64String(Hex2bin(str))))
            {
                using (ICryptoTransform decryptor = rijn.CreateDecryptor(Encoding.ASCII.GetBytes(key), Encoding.ASCII.GetBytes(iv)))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader swDecrypt = new StreamReader(csDecrypt))
                        {
                            result = swDecrypt.ReadToEnd();
                        }
                    }
                }
            }
            rijn.Clear();
            return result;
        }


        public static string Encrypt(string str,string key ,string iv)
        {
            String result;

            RijndaelManaged rijn = new RijndaelManaged();
            rijn.Mode = CipherMode.CBC;
            rijn.Padding = PaddingMode.Zeros;

            using (MemoryStream msEncrypt = new MemoryStream())
            {
                using (ICryptoTransform encryptor = rijn.CreateEncryptor(Encoding.ASCII.GetBytes(key), Encoding.ASCII.GetBytes(iv)))
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(str);
                        }
                    }
                }
                result = BitConverter.ToString(msEncrypt.ToArray()).Replace("-", "").ToLower();
            }
            rijn.Clear();

            return result;
        }
    }
}
