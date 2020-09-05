using System;
using System.Configuration;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace CodeAppStore.License.EncodeDecodeRepo
{
    /// <summary>
    /// Encode Decode Class
    /// </summary>
    public class EncodeDecode : IEncodeDecode
    {
        private protected string Ek { get; } = ConfigurationManager.ConnectionStrings["Ek"].ConnectionString;

        /// <summary>
        /// Takes String and Encrypts the string 
        /// </summary>
        /// <param name="encryptString"></param>
        /// <returns> Encrypted String <see cref="string"/>  </returns>
        public string Encrypt(string encryptString)
        {
            byte[] cb9jk = Encoding.Unicode.GetBytes(encryptString);
            using (Aes ecs9jk = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(Ek, new byte[] {
                    0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76
                });
                if (ecs9jk != null)
                {
                    ecs9jk.Key = pdb.GetBytes(32);
                    ecs9jk.IV = pdb.GetBytes(16);
                    using MemoryStream ms = new MemoryStream();
                    using (CryptoStream cs = new CryptoStream(ms, ecs9jk.CreateEncryptor(),
                        CryptoStreamMode.Write))
                    {
                        cs.Write(cb9jk, 0, cb9jk.Length);
                        cs.Close();
                    }

                    encryptString = Convert.ToBase64String(ms.ToArray());
                }
            }
            return encryptString;
        }

        /// <summary>
        /// Decrypts the Encrypted String <see cref="Encrypt"/>
        /// </summary>
        /// <param name="encryptedText"></param>
        /// <returns> Decrypted string <see cref="string"/>   </returns>
        public string Decrypt(string encryptedText)
        {
            encryptedText = encryptedText.Replace(" ", "+");
            byte[] cb9jk = Convert.FromBase64String(encryptedText);
            using (Aes ecor9hkl = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(Ek, new byte[] {
                    0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76
                });
                if (ecor9hkl != null)
                {
                    ecor9hkl.Key = pdb.GetBytes(32);
                    ecor9hkl.IV = pdb.GetBytes(16);
                    using MemoryStream ms = new MemoryStream();
                    using (CryptoStream cs = new CryptoStream(ms, ecor9hkl.CreateDecryptor(),
                        CryptoStreamMode.Write))
                    {
                        cs.Write(cb9jk, 0, cb9jk.Length);
                        cs.Close();
                    }

                    encryptedText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return encryptedText;
        }

    }
}