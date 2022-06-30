using System.Security.Cryptography;
using System.Text;

namespace Learningproject.Helpers
{
    public class PasswordEncryption : IPasswordEncryption
    {
        public string PasswordEncryptionSHA256(string password)
        {
            SHA256 sha256 = SHA256.Create();
            byte[] hashValue;
            UTF8Encoding objUtf8 = new UTF8Encoding();
            hashValue = sha256.ComputeHash(objUtf8.GetBytes(password));
            string EncrypResult = Convert.ToBase64String(hashValue);
            return EncrypResult;
        }
    }
}
