using Materia.Seguridad.Recursos;
using System.Security.Cryptography;
using System.Text;

namespace Materia.Seguridad
{
    public class EncripcionAES
    {
        private static readonly byte[] Key = Encoding.UTF8.GetBytes(Base64Decode(Llaves.KeyEncryipt));
        /// <summary>
        /// Metodo Para Cifrar Cadenas con AES128
        /// </summary>
        /// <param name="encryptString"></param>
        /// <returns></returns>
        public string Encrypt(string encryptString)
        {
            {
                using (Aes aesAlg = Aes.Create())
                {
                    aesAlg.Key = Key;
                    aesAlg.Mode = CipherMode.CBC;
                    aesAlg.Padding = PaddingMode.PKCS7;
                    aesAlg.GenerateIV();
                    byte[] iv = aesAlg.IV;

                    ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, iv);

                    using (MemoryStream msEncrypt = new MemoryStream())
                    {
                        // Escribir el IV al principio del stream
                        msEncrypt.Write(iv, 0, iv.Length);
                        using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                        {
                            using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                            {
                                swEncrypt.Write(encryptString);
                            }
                        }
                        // Devuelve IV + Texto Cifrado como Base64
                        return Convert.ToBase64String(msEncrypt.ToArray());
                    }
                }
            }
        }

        /// <summary>
        /// Metodo Para Descifrar Cadenas con AES128
        /// </summary>
        /// <param name="cipherText"></param>
        /// <returns></returns>
        public string Decrypt(string cipherTextBase64)
        {
            byte[] fullCipher = Convert.FromBase64String(cipherTextBase64);

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.Mode = CipherMode.CBC;
                aesAlg.Padding = PaddingMode.PKCS7;

                // Extraer el IV del principio
                byte[] iv = new byte[aesAlg.BlockSize / 8];
                if (fullCipher.Length < iv.Length) throw new ArgumentException("Texto cifrado inválido o incompleto.");
                Array.Copy(fullCipher, 0, iv, 0, iv.Length);
                aesAlg.IV = iv;

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msDecrypt = new(fullCipher, iv.Length, fullCipher.Length - iv.Length)) // Leer desde DESPUÉS del IV
                {
                    using (CryptoStream csDecrypt = new(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new(csDecrypt))
                        {
                            return srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Codifica en Base 64
        /// </summary>
        /// <param name="base64EncodedData"></param>
        /// <returns></returns>
        public static string Base64Decode(string base64EncodedData)
        {
            byte[] base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }
    }
}
