using System.Security.Cryptography;
using System.Text;

namespace SistemaCompraVentaDeCriptomonedas.Helpers
{
    public class PasswordEncryptHelper
    {
        public static string EncryptPassword(string Password, string Email)
        {
            var salt = CreateSalt(Email);
            string saltAndPwd = String.Concat(Password, salt);
            var sha256 = SHA256.Create();
            var encoding = new ASCIIEncoding();
            var stream = Array.Empty<byte>();
            var sb = new StringBuilder();
            stream = sha256.ComputeHash(encoding.GetBytes(saltAndPwd));
            for (int i = 0; i < stream.Length; i++)
            {
                sb.AppendFormat("{0:x2}", stream[i]);
            }
            return sb.ToString();
        }


        private static string CreateSalt(string Email)
        {
            var salt = Email;
            byte[] saltBytes;
            string saltStr;
            saltBytes = ASCIIEncoding.ASCII.GetBytes(salt);
            long XORED = 0x00;

            foreach (int x in saltBytes)
            {
                XORED = XORED ^ x;
            }

            Random rand = new Random(Convert.ToInt32(XORED));
            saltStr = rand.Next().ToString();
            saltStr += rand.Next().ToString();
            saltStr += rand.Next().ToString();
            saltStr += rand.Next().ToString();
            return saltStr;
        }
    }
}
