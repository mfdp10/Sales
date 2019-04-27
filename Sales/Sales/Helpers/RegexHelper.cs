namespace Sales.Helpers
{
    using System;
    using System.Net.Mail;
    using System.Text.RegularExpressions;

    public static class RegexHelper
    {
        public static bool IsValidEmailAddress(string emailaddress)
        {
            try
            {
                var email = new MailAddress(emailaddress);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}
