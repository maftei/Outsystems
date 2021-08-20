using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;


namespace OutSystems.NssExtension {

	public class CssExtension: IssExtension {


        // set password
       // public const string strPassword = "LetMeIn99$";

        // set permutations
        public const String strPermutation = "ouiveyxaqtd";
        public const Int32 bytePermutation1 = 0x19;
        public const Int32 bytePermutation2 = 0x59;
        public const Int32 bytePermutation3 = 0x17;
        public const Int32 bytePermutation4 = 0x41;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ssInputPassword"></param>
        /// 
        public static string Encrypt(string ssInputPassword)
        {

            return Convert.ToBase64String(Encrypt(Encoding.UTF8.GetBytes(ssInputPassword)));
            // reference https://msdn.microsoft.com/en-us/library/ds4kkd55(v=vs.110).aspx

        }

        public static byte[] Encrypt(byte[] strData)
        {
            PasswordDeriveBytes passbytes =
            new PasswordDeriveBytes(CssExtension.strPermutation,
            new byte[] { CssExtension.bytePermutation1,
                         CssExtension.bytePermutation2,
                         CssExtension.bytePermutation3,
                         CssExtension.bytePermutation4
            });

            MemoryStream memstream = new MemoryStream();
            Aes aes = new AesManaged();
            aes.Key = passbytes.GetBytes(aes.KeySize / 8);
            aes.IV = passbytes.GetBytes(aes.BlockSize / 8);

            CryptoStream cryptostream = new CryptoStream(memstream,
            aes.CreateEncryptor(), CryptoStreamMode.Write);
            cryptostream.Write(strData, 0, strData.Length);
            cryptostream.Close();
            return memstream.ToArray();
        }

        public void MssEncryptPassword(string ssInputPassword, out string ssOutputPassword) {
			ssOutputPassword = Encrypt(ssInputPassword);
			// TODO: Write implementation for action
		} // MssEncryptPassword

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ssInputPassword"></param>
		/// <param name="ssOutputPassword"></param>
		public void MssAction1(string ssInputPassword, out string ssOutputPassword) {
			ssOutputPassword = "";
			// TODO: Write implementation for action
		} // MssAction1

	} // CssExtension

} // OutSystems.NssExtension

