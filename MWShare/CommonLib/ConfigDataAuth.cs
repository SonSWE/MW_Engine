using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace CommonLib
{
    public static class ConfigDataAuth
    {
        public static string ReportTemplatePath { get; private set; } = Path.Combine(AppContext.BaseDirectory + "Report" + Path.DirectorySeparatorChar + "TemplateFiles" + Path.DirectorySeparatorChar);
        public static string ReportExportPath { get; private set; } = Path.Combine(AppContext.BaseDirectory + "Report" + Path.DirectorySeparatorChar + "ExportFiles" + Path.DirectorySeparatorChar);

        public static string AES_Key { get; private set; } = "";
        public static string AES_IV { get; private set; } = "";

        public static int NotifyTimeoutMs { get; private set; } = 300;

        // Cau hinh FTP server
        public static FileServerConfig FileServerConfig { get; private set; }

        // Cau hinh login
        public static IConfiguration Audience { get; private set; }
        public static IConfiguration AdminAccount { get; private set; }
        public static IConfiguration LdapInfo { get; private set; }
        public static void Init(IConfigurationRoot configuration)
        {
            if (configuration == null) return;

            try
            {
                AES_Key = configuration["AES_Key"];
                AES_IV = configuration["AES_InitVector"];

                int.TryParse(configuration["NotifyTimeoutMs"], out var notifyTimeoutMs);
                if (notifyTimeoutMs > 0)
                {
                    NotifyTimeoutMs = notifyTimeoutMs;
                }

                // Cau hinh FTP server
                var section = configuration.GetSection("FileServerConfig");

                FileServerConfig = new FileServerConfig(
                    section["Endpoint"] ?? string.Empty,
                    EncryptData.DecryptAES(section["AccessKey"] ?? string.Empty, AES_Key, AES_IV),
                    EncryptData.DecryptAES(section["AccessSecret"] ?? string.Empty, AES_Key, AES_IV),
                    section["Location"] ?? string.Empty,
                    section["Bucket"] ?? string.Empty,
                    section["UseSSL"] ?? string.Empty
                );

                // Cau hinh login
                Audience = configuration.GetSection("Audience");
                // Cau hinh tai khoan administrator
                AdminAccount = configuration.GetSection("AdminAccount");
                // Cau hinh ldap
                LdapInfo = configuration.GetSection("LdapInfo");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    public class FileServerConfig
    {
        public FileServerConfig(string endpoint, string accessKey, string accessSecret, string location, string bucket, string useSSL)
        {
            Endpoint = endpoint?.Trim();
            AccessKey = accessKey?.Trim();
            AccessSecret = accessSecret?.Trim();
            Location = location?.Trim();
            Bucket = bucket?.Trim();
            UseSSL = useSSL?.Trim();
        }

        public string Endpoint { get; private set; }
        public string AccessKey { get; private set; }
        public string AccessSecret { get; private set; }
        public string Location { get; private set; }
        public string Bucket { get; private set; }
        public string UseSSL { get; private set; }
    }
}
