namespace Learningproject.Helpers
{
    public interface IPasswordEncryption
    {
        public string PasswordEncryptionSHA256(string password); 
    }
}
