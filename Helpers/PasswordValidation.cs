namespace Learningproject.Helpers
{
    public class PasswordValidation : IPasswordValidation
    {
        public bool CheckPassword(string password)
        {
            int PasswordLength = password.Length;

            if (PasswordLength < 8) return false;

            int ValidationCount = 0;

            foreach (char c in password)
            {
                if (char.IsUpper(c))
                {
                    ValidationCount++;
                    break;
                }
            }

            foreach (char c in password)
            {
                if (char.IsLower(c))
                {
                    ValidationCount++;
                    break;
                }
            }

            foreach (char c in password)
            {
                if (char.IsDigit(c))
                {
                    ValidationCount++;
                    break;
                }
            }

            if(ValidationCount<3)return false;

            char[] special = { '@', '#', '$', '%', '^', '&', '+', '=' };
            if(password.IndexOfAny(special) == -1) return false;

            return true;

        }
    }
}
