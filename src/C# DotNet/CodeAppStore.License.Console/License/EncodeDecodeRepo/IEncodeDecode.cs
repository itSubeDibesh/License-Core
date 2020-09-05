namespace CodeAppStore.License.Console.EncodeDecodeRepo
{
    /// <summary>
    /// Encode Decode interface
    /// </summary>
    public interface IEncodeDecode
    {
        /// <summary>
        /// Takes String and Encrypts the string 
        /// </summary>
        /// <param name="encryptString"></param>
        /// <returns> Encrypted String <see cref="string"/>  </returns>
        string Encrypt(string encryptString);

        /// <summary>
        /// Decrypts the Encrypted String <see cref="Encrypt"/>
        /// </summary>
        /// <param name="encryptedText"></param>
        /// <returns> Decrypted string <see cref="string"/>   </returns>
        string Decrypt(string encryptedText);
    }
}