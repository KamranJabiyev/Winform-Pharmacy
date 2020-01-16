using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy
{
    public static class Helpers
    {
        public static bool IsEmail(this string email)
        {
            try
            {
                MailAddress mail = new MailAddress(email);
                return true;
            }
            catch (Exception)
            {

                return false;
            } 
        }

        public static string PassHash(this string password)
        {
            byte[] encodingPass = Encoding.ASCII.GetBytes(password);
            SHA256Managed hash = new SHA256Managed();
            byte[] hashPassword=hash.ComputeHash(encodingPass);
            return Encoding.ASCII.GetString(hashPassword);
        }
    }
}
