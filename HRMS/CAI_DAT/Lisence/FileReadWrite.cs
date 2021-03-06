using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace EVSoft.HRMSLicense
{
    public class FileReadWrite
    {
        // Key for TripleDES encryption
        public static byte[] key = { 01, 100, 64, 100, 10, 40, 200, 4,
                    21, 54, 65, 246, 5, 62, 1, 54,
                    54, 6, 8, 9, 65, 4, 65, 90};

        private static byte[] iv = { 0, 0, 0, 0, 0, 0, 0, 0 };

        /// <summary>
        /// Ghi license ra file
        /// </summary>
        /// <param name="FilePath"></param>
        /// <returns></returns>
        public static string ReadFile(string FilePath)
        {
            try
            {
                FileInfo fi = new FileInfo(FilePath);
                if (fi.Exists == false)
                    return string.Empty;

                FileStream fin = new FileStream(FilePath, FileMode.Open, FileAccess.Read);
                TripleDES tdes = new TripleDESCryptoServiceProvider();
                CryptoStream cs = new CryptoStream(fin, tdes.CreateDecryptor(key, iv), CryptoStreamMode.Read);

                StringBuilder SB = new StringBuilder();
                int ch;
                for (int i = 0; i < fin.Length; i++)
                {
                    ch = cs.ReadByte();
                    if (ch == 0)
                        break;
                    SB.Append(Convert.ToChar(ch));
                }

                cs.Close();
                fin.Close();
                return SB.ToString();
            }
            catch(Exception ex)
            {
                return "";
            }
        }

        /// <summary>
        /// Đọc license từ file đã lưu
        /// </summary>
        /// <param name="FilePath"></param>
        /// <param name="Data"></param>
        public static void WriteFile(string FilePath, string Data)
        {
            FileStream fout = new FileStream(FilePath, FileMode.OpenOrCreate, FileAccess.Write);
            TripleDES tdes = new TripleDESCryptoServiceProvider();
            CryptoStream cs = new CryptoStream(fout, tdes.CreateEncryptor(key, iv), CryptoStreamMode.Write);

            byte[] d = Encoding.ASCII.GetBytes(Data);
            cs.Write(d, 0, d.Length);
            cs.WriteByte(0);

            cs.Close();
            fout.Close();
        }
    }
}
