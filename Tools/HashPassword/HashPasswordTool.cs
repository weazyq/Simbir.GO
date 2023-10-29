using System.Security.Cryptography;
using System.Text;

namespace Tools.Encryption
{
    public static class HashPasswordTool
    {
        public static String HashPassword(this String password)
        {
            using (var sha256 = SHA256.Create())
            {
                Byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                String hash = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();

                return hash;
            }
        }
    }
}
