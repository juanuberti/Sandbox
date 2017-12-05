using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox
{
    public class Encryption
    {
        #region AES-256

        /// <summary>
        /// Generates cryptographically random string of alphanumerical characters.
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string RandomString(int length)
        {
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                byte[] uintBuffer = new byte[sizeof(uint)];

                while (length-- > 0)
                {
                    rng.GetBytes(uintBuffer);
                    uint num = BitConverter.ToUInt32(uintBuffer, 0);
                    res.Append(valid[(int)(num % (uint)valid.Length)]);
                }
            }

            return res.ToString();
        }

        /// <summary>
        /// MD5 just happens to create fixed length hashes of exactly 32 bytes, which makes it a convenient function to combine different strings, 
        /// get added entropy and guarantee an output string of the right size to serve as a secret key for AES-256
        /// </summary>
        /// <param name="tobehashed"></param>
        /// <returns></returns>
        public static string CreateFixedLengthCombinedKey(string tobehashed)
        {
            MD5 md5 = System.Security.Cryptography.MD5.Create();

            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(tobehashed);
            byte[] hash = md5.ComputeHash(inputBytes);

            return Convert.ToBase64String(hash);
        }

        /// <summary>
        /// AES Initialization Vectors must be of a fixed byte length equal to half the AES Key-length
        /// </summary>
        /// <returns></returns>
        public static byte[] CreateRandomIV()
        {
            byte[] IV = new byte[16];
            string RandomIVString = RandomString(16);
            Console.WriteLine("IV Seed String: " + RandomIVString);
            IV = Encoding.UTF8.GetBytes(RandomIVString);
            return IV;
        }

        /// <summary>
        /// Encrpyts the sourceString, returns this result as an Aes encrpyted, BASE64 encoded string
        /// </summary>
        /// <param name="plainSourceStringToEncrypt">a plain, Framework string (ASCII, null terminated)</param>
        /// <param name="passPhrase">The pass phrase.</param>
        /// <returns>
        /// returns an Aes encrypted, BASE64 encoded string
        /// </returns>
        public static string EncryptString(string plainSourceStringToEncrypt, string passPhrase, string IV)
        {
            //Set up the encryption objects
            using (AesCryptoServiceProvider acsp = GetProvider(passPhrase, IV))
            {
                byte[] sourceBytes = Encoding.UTF8.GetBytes(plainSourceStringToEncrypt);
                ICryptoTransform ictE = acsp.CreateEncryptor();

                //Set up stream to contain the encryption
                MemoryStream msS = new MemoryStream();

                //Perform the encrpytion, storing output into the stream
                CryptoStream csS = new CryptoStream(msS, ictE, CryptoStreamMode.Write);
                csS.Write(sourceBytes, 0, sourceBytes.Length);
                csS.FlushFinalBlock();

                //sourceBytes are now encrypted as an array of secure bytes
                byte[] encryptedBytes = msS.ToArray(); //.ToArray() is important, don't mess with the buffer

                //return the encrypted bytes as a BASE64 encoded string
                return Convert.ToBase64String(encryptedBytes);
            }
        }

        /// <summary>
        /// Decrypts a BASE64 encoded string of encrypted data, returns a plain string
        /// </summary>
        /// <param name="base64StringToDecrypt">an Aes encrypted AND base64 encoded string</param>
        /// <param name="passphrase">The passphrase.</param>
        /// <returns>returns a plain string</returns>
        public static string DecryptString(string EncryptedString, string passphrase, string IV)
        {
            //Set up the encryption objects
            using (AesCryptoServiceProvider acsp = GetProvider(passphrase, IV))
            {
                //byte[] RawBytes = Convert.FromBase64String(base64StringToDecrypt);

                //Console.WriteLine(passphrase.Length);

                ICryptoTransform ictD = acsp.CreateDecryptor();

                //RawBytes now contains original byte array, still in Encrypted state

                //Decrypt into stream
                byte[] RawBytes = Encoding.UTF8.GetBytes(EncryptedString);
                MemoryStream msD = new MemoryStream(RawBytes, 0, RawBytes.Length);
                CryptoStream csD = new CryptoStream(msD, ictD, CryptoStreamMode.Read);
                //csD now contains original byte array, fully decrypted

                //return the content of msD as a regular string
                return (new StreamReader(csD)).ReadToEnd();
            }
        }

        //Helper Methods//

        private static AesCryptoServiceProvider GetProvider(string key)
        {
            AesCryptoServiceProvider result = new AesCryptoServiceProvider();
            result.BlockSize = 128;
            result.KeySize = 256;
            result.Mode = CipherMode.CBC;
            result.Padding = PaddingMode.PKCS7;

            result.Key = Encoding.UTF8.GetBytes(key);
            return result;
        }


        private static AesCryptoServiceProvider GetProvider(string key, string IV)
        {
            AesCryptoServiceProvider result = new AesCryptoServiceProvider();
            result.BlockSize = 128;
            result.KeySize = 256;
            result.Mode = CipherMode.CBC;
            result.Padding = PaddingMode.PKCS7;

            result.IV = Encoding.UTF8.GetBytes(IV);
            result.Key = result.IV = Encoding.UTF8.GetBytes(key);

            return result;
        }

        #endregion

    }
}
