using Blog.Core.Common.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Blog.Core.Common.DB
{
    public class AppSecretConfig
    {
        private static string Audience_Secret = AppSettings.app(new string[] { "Audience", "Secret" });
        private static string Audience_Secret_File = AppSettings.app(new string[] { "Audience","SecretFile"});
        public static string Audience_Secret_String => IniAudience_Secret();
        private static string IniAudience_Secret()
        {
            var securityString = DifDBConnOfSecurity(Audience_Secret_File);
            if (!string.IsNullOrWhiteSpace(Audience_Secret_File) && !string.IsNullOrWhiteSpace(securityString))
            {
                return securityString;
            }
            else
            {
                return Audience_Secret;
            }
        }
        private static string DifDBConnOfSecurity(params string[] conn)
        {
            foreach (var item in conn)
            {
                try
                {
                    if (File.Exists(item))
                    {
                        return File.ReadAllText(item).Trim();
                    }
                }
                catch (Exception)
                {
                }
            }
            return "";
        }
    }
}
