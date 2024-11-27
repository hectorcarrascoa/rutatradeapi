using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Functions
{
    /// <summary>
    /// Clase con métodos de encriptación
    /// </summary>
    public static class Encrypt
    {
        #region Declaración
        // This size of the IV (in bytes) must = (keysize / 8).  Default keysize is 256, so the IV must be
        // 32 bytes long.  Using a 16 character string here gives us 32 bytes when converted to a byte array.
        private const string initVector = "pemgail9uzpgzl88";
        // This constant is used to determine the keysize of the encryption algorithm.
        private const int keysize = 256;
        #endregion

        #region Métodos Públicos
        /// <summary>
        /// Función que encripta datos
        /// </summary>
        /// <param name="plainText">String para ser encriptado</param>
        /// <param name="passPhrase">String que se utiliza en la encriptación</param>
        /// <returns>String</returns>
        public static string EncryptString(string plainText, string passPhrase)
        {
            byte[] initVectorBytes = Encoding.UTF8.GetBytes(initVector);
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, null);
            byte[] keyBytes = password.GetBytes(keysize / 8);
            RijndaelManaged symmetricKey = new RijndaelManaged();
            symmetricKey.Mode = CipherMode.CBC;
            ICryptoTransform encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes);
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
            cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
            cryptoStream.FlushFinalBlock();
            byte[] cipherTextBytes = memoryStream.ToArray();
            memoryStream.Close();
            cryptoStream.Close();
            return Convert.ToBase64String(cipherTextBytes);
        }

        /// <summary>
        /// Función para desencriptar un string
        /// </summary>
        /// <param name="cipherText">String encriptado para ser desencriptado</param>
        /// <param name="passPhrase">String que se utiliza en la encriptación</param>
        /// <returns>String</returns>
        public static string DecryptString(string cipherText, string passPhrase)
        {
            byte[] initVectorBytes = Encoding.ASCII.GetBytes(initVector);
            byte[] cipherTextBytes = Convert.FromBase64String(cipherText);
            PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, null);
            byte[] keyBytes = password.GetBytes(keysize / 8);
            RijndaelManaged symmetricKey = new RijndaelManaged();
            symmetricKey.Mode = CipherMode.CBC;
            ICryptoTransform decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes);
            MemoryStream memoryStream = new MemoryStream(cipherTextBytes);
            CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
            byte[] plainTextBytes = new byte[cipherTextBytes.Length];
            int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
            memoryStream.Close();
            cryptoStream.Close();
            return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
        }

        /// <summary>
        /// Función para realizar el encode de la password del usuario
        /// </summary>
        /// <param name="originalPassword">String con la password sin encodear</param>
        /// <returns>String con la password encriptada</returns>
        public static string EncodePassword(string originalPassword)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(originalPassword);

            var sha1 = SHA1.Create();
            byte[] hashBytes = sha1.ComputeHash(bytes);

            return HexStringFromBytes(hashBytes);
        }

        /// <summary>
        /// Método que reemplaza carácteres hexadecimales en cadena de bytes
        /// </summary>
        /// <param name="bytes">cadena de bytes</param>
        /// <returns>cadena de texto</returns>
        public static string HexStringFromBytes(byte[] bytes)
        {
            var sb = new StringBuilder();
            foreach (byte b in bytes)
            {
                var hex = b.ToString("x2");
                sb.Append(hex);
            }

            return sb.ToString().ToUpperInvariant();
        }

        /// <summary>
        /// Función para encodear un string a 64 bits
        /// </summary>
        /// <param name="value">String que va ha ser encodeado</param>
        /// <returns>String encodeado</returns>
        public static string EncodeToBase64(string value)
        {
            var toEncodeAsBytes = Encoding.UTF8.GetBytes(value);
            return Convert.ToBase64String(toEncodeAsBytes);
        }

        /// <summary>
        /// Función que descifrar cadena codificada en Base64
        /// </summary>
        /// <param name="base64EncodedData">Cadena codificada en Base64</param>
        /// <returns>Cadena descifrada</returns>
        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = Convert.FromBase64String(base64EncodedData);
            return Encoding.UTF8.GetString(base64EncodedBytes);
        }
        #endregion
    }
}
