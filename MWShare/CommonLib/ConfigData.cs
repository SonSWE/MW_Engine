using Microsoft.Extensions.Configuration;

namespace CommonLib
{
    public static class ConfigData
    {
        public const string DefaultLoggerName = "RootLogger";
        public static string ConnectionString { get; private set; } = string.Empty;
        public static int ReloadMemTimeInterval { get; private set; } = 30;


        // Cấu hình clean log folder
        public static bool CleanLogEnabled { get; set; } = true;
        public static int CleanLogMaxAge { get; set; } = 30;

        public static string AES_Key { get; private set; } = "";
        public static string AES_IV { get; private set; } = "";

        // Cấu hình kết nối tời Midleware
        public static bool MWEnabled { get; private set; } = false;
        public static string MWLogDataPath { get; private set; } = string.Empty;

        public static string MWSendIP { get; private set; } = string.Empty;
        public static string MWSendPort { get; private set; } = string.Empty;
        public static string MWSendIdentify { get; private set; } = string.Empty;

        public static string MWReceiveIP { get; private set; } = string.Empty;
        public static string MWReceivePort { get; private set; } = string.Empty;
        public static string MWReceiveIdentify { get; private set; } = string.Empty;

        public static string MWResendRequestPort { get; private set; } = string.Empty;

        // End - Cấu hình kết nối tời Midleware

        // Cau hinh ket noi Redis
        public static bool RedisEnabled { get; private set; } = false;
        public static string RedisServerIp { get; private set; } = string.Empty;
        public static int RedisDbNumber { get; private set; } = 0;
        public static string RedisAuth { get; private set; } = "";

        // End - Cau hinh ket noi Redis
        // Set Thread Sleep Value
        public static int ThreadSleep { get; private set; } = 0;
        // End Set Thread Sleep Value

        #region Cấu hình nối đến Authen server

        public static string BOAuthHost { get; private set; } = "";
        public static string NotifyHost { get; private set; } = "";

        #endregion

        // Cau hinh noi den LDAP Server
        #region Cau hinh noi den LDAP Server

        public static LdapConfig LdapConfig { get; private set; }

        #endregion

        #region Cau hinh ket noi toi Minio
        public static string MinioEndpoint { get; set; } = string.Empty;
        public static string MinioAccessKey { get; set; } = string.Empty;
        public static string MinioSecretKey { get; set; } = string.Empty;
        public static string MinioBucket { get; set; } = string.Empty;
        public static bool MinioUseSSL { get; set; }
        #endregion

        public static void InitConfig(IConfigurationRoot configuration)
        {
            if (configuration != null)
            {
                AES_Key = configuration["AES_Key"];
                AES_IV = configuration["AES_InitVector"];

                //ConnectionString = EncryptData.DecryptAES(configuration["ConnectionString"]?.Trim() ?? string.Empty, AES_Key, AES_IV);

                ConnectionString = configuration["ConnectionString"]?.Trim() ?? string.Empty;

                //
                CleanLogEnabled = configuration["CleanLogEnabled"]?.Trim()?.Equals("Y") == true;
                if (int.TryParse(configuration["CleanLogMaxAge"]?.Trim() ?? string.Empty, out int cleanLogMaxAge) && cleanLogMaxAge > 0)
                {
                    CleanLogMaxAge = cleanLogMaxAge;
                }

                //
                MWEnabled = string.Equals(configuration["MWEnabled"], "Y");
                MWLogDataPath = configuration["MWLogDataPath"]?.Trim() ?? string.Empty;

                MWSendIP = configuration["MWSendIP"]?.Trim() ?? string.Empty;
                MWSendPort = configuration["MWSendPort"]?.Trim() ?? string.Empty;
                MWSendIdentify = configuration["MWSendIdentify"]?.Trim() ?? string.Empty;

                MWReceiveIP = configuration["MWReceiveIP"]?.Trim() ?? string.Empty;
                MWReceivePort = configuration["MWReceivePort"]?.Trim() ?? string.Empty;
                MWReceiveIdentify = configuration["MWReceiveIdentify"]?.Trim() ?? string.Empty;

                MWResendRequestPort = configuration["MWResendRequestPort"]?.Trim() ?? string.Empty;

                // Cau hinh ket noi Redis
                RedisEnabled = string.Equals(configuration["RedisEnabled"], "Y");
                RedisServerIp = configuration["RedisServerIp"]?.Trim() ?? string.Empty;
                if (int.TryParse(configuration["RedisDbNumber"]?.Trim() ?? string.Empty, out int redisDbNumber) && redisDbNumber >= 0)
                {
                    RedisDbNumber = redisDbNumber;
                }
                RedisAuth = EncryptData.DecryptAES(configuration["RedisAuth"]?.Trim() ?? string.Empty, AES_Key, AES_IV);

                if (int.TryParse(configuration["ThreadSleep"]?.Trim() ?? string.Empty, out int threadSleep) && threadSleep > 0)
                {
                    ThreadSleep = threadSleep;
                }
                // End - Cau hinh ket noi Redis

                // Cau hinh noi den Authen server
                BOAuthHost = configuration["BOAuthHost"]?.Trim() ?? string.Empty;
                NotifyHost = configuration["NotifyHost"]?.Trim() ?? string.Empty;

                // Cau hinh noi den LDAP Server
                #region Cau hinh noi den LDAP Server

                var ldapSection = configuration.GetSection("LdapConfig");
                if (ldapSection != null)
                {
                    _ = int.TryParse(ldapSection["Port"]?.Trim() ?? string.Empty, out int ldapPort);

                    LdapConfig = new LdapConfig(
                        ldapSection["Domain"],
                        ldapPort,
                        ldapSection["User"],
                        EncryptData.DecryptAES(ldapSection["Password"], AES_Key, AES_IV),
                        ldapSection["SearchRegion"],
                        ldapSection["SearchAttribute"],
                        ldapSection["GetAttributes"],
                        ldapSection["UseSSL"]
                    );
                }


                MinioEndpoint = configuration["MinIOConfig:Endpoint"]?.ToString();
                MinioAccessKey = EncryptData.DecryptAES(configuration["MinIOConfig:AccessKey"]?.ToString(), AES_Key, AES_IV);
                MinioSecretKey = EncryptData.DecryptAES(configuration["MinIOConfig:SecretKey"]?.ToString(), AES_Key, AES_IV);
                MinioBucket = configuration["MinIOConfig:Bucket"]?.ToString();
                MinioUseSSL = (configuration["MinIOConfig:UseSSL"]?.ToString() != null && configuration["MinIOConfig:UseSSL"]?.ToString() == "Y");


                #endregion
            }
        }
    }
}
