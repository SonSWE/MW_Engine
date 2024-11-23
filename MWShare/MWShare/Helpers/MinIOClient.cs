using System.Net;
using CommonLib;
using Minio;
using Minio.DataModel;
using Minio.DataModel.Args;
using MWShare.Helpers.FileStorage;

namespace MWShare.Helpers
{
    public class MinIOClient : IFileStorageClient
    {
        private readonly string c_endpoint = string.Empty;
        private readonly string c_accessKey = string.Empty;
        private readonly string c_accessSecret = string.Empty;
        private readonly string c_location = string.Empty;
        private readonly string c_bucket = string.Empty;
        private readonly bool c_useSSL = false;

        public MinIOClient()
        {
            this.c_endpoint = ConfigData.MinioEndpoint;
            this.c_accessKey = ConfigData.MinioAccessKey;
            this.c_accessSecret = ConfigData.MinioSecretKey;
            this.c_location = string.Empty;
            this.c_bucket = ConfigData.MinioBucket;
            this.c_useSSL = ConfigData.MinioUseSSL;
            //
            Logger.log.Info($"MinIOHelper Init param c_endpoint={c_endpoint}, c_location={c_location}, c_bucket={c_bucket}, c_useSSL={c_useSSL} sucess");
        }

        public async Task<bool> UploadFile(string fileName, string filePath, byte[] fileBytes)
        {
            try
            {
                if (fileBytes == null || fileBytes.Length == 0)
                {
                    Logger.log.Error($"Error UploadFile when process fileBytes is null.");
                    return false;
                }
                var minioClient = GetOrCreateClient();
                if (minioClient == null)
                {
                    Logger.log.Error($"Error UploadFile when process c_minioClient is null.");
                    return false;
                }
                //
                var putObjectArgs = new PutObjectArgs();
                putObjectArgs.WithBucket(c_bucket);
                putObjectArgs.WithObject(filePath);
                putObjectArgs.WithStreamData(new MemoryStream(fileBytes));
                putObjectArgs.WithObjectSize(fileBytes.Length);
                putObjectArgs.WithContentType("application/octet-stream");

                var response = await minioClient.PutObjectAsync(putObjectArgs);
                Logger.log.Info("Upload File success. File Path : {0}", filePath);
                return true;
            }
            catch (Exception ex)
            {
                Logger.log.Error($"Error UploadFile when process fileName={fileName}, Exception: {ex?.ToString()}");
                return false;
            }
        }

        public async Task<bool> UploadFile(string fileName, string filePath, Stream fileData)
        {

            if (fileData == null || fileData.Length == 0)
            {
                Logger.log.Error($"Error UploadFile when process fileData is null.");
                return false;
            }

            using var memoryStream = new MemoryStream();
            fileData.Position = 0;
            await fileData.CopyToAsync(memoryStream);

            return await UploadFile(fileName, TrimStartSlash(filePath), memoryStream.ToArray());
        }

        public async Task<bool> DownloadFileToStream(Stream destStream, string filePath)
        {
            try
            {
                var minioClient = GetOrCreateClient();
                if (minioClient == null)
                {
                    Logger.log.Error($"Error DownloadFileToStream when process c_minioClient is null.");
                    return false;
                }
                //
                var getObjectArgs = new GetObjectArgs();
                getObjectArgs.WithBucket(c_bucket);
                getObjectArgs.WithObject(filePath);
                getObjectArgs.WithCallbackStream((stream) => stream.CopyTo(destStream));

                var objectStat = await minioClient.GetObjectAsync(getObjectArgs);

                Logger.log.Info("DownloadFileToStream success. File Path: {0}", filePath);

                return true;
            }
            catch (Exception ex)
            {
                Logger.log.Error(ex, $"Error DownloadFileToStream when process filePath={filePath}, Exception: {ex.Message}");
                return false;
            }
        }

        public async Task<ObjectStat> GetFileInfo(string filePath)
        {
            try
            {
                var minioClient = GetOrCreateClient();
                if (minioClient == null)
                {
                    Logger.log.Error($"Error GetFileInfo when process c_minioClient is null.");
                    return null;
                }

                var statArgs = new StatObjectArgs();
                statArgs.WithObject(filePath);
                statArgs.WithBucket(c_bucket);

                return await minioClient.StatObjectAsync(statArgs);
            }
            catch (Exception ex)
            {
                Logger.log.Error(ex, $"Error GetFileInfo when process filePath={filePath}, Exception: {ex.Message}");
                return null;
            }
        }

        //
        private IMinioClient? _minioClient = null;
        private readonly object _lock = new();

        private IMinioClient GetOrCreateClient()
        {
            try
            {
                lock (_lock)
                {
                    if (_minioClient == null)
                    {
                        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls13;

                        _minioClient = new MinioClient();


                        _minioClient.WithEndpoint(c_endpoint);
                        _minioClient.WithCredentials(c_accessKey, c_accessSecret);
                        if (!string.IsNullOrEmpty(c_location))
                        {
                            _minioClient.WithRegion(c_location);
                        }
                        if (c_useSSL)
                        {
                            _minioClient.WithSSL();
                        }
                        _minioClient.Build();
                        //
                        var beArgs = new BucketExistsArgs().WithBucket(c_bucket);
                        bool found = _minioClient.BucketExistsAsync(beArgs).Result;
                        if (!found)
                        {
                            var mbArgs = new MakeBucketArgs().WithBucket(c_bucket);
                            _minioClient.MakeBucketAsync(mbArgs).Wait();
                        }
                    }
                }

                return _minioClient;

            }
            catch (Exception ex)
            {
                Logger.log.Error($"Error CreateClient when Init MinIOHelper, Exception: {ex?.ToString()}");
                return null;
            }
        }

        private string TrimStartSlash(string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                return url;
            }

            return url.TrimStart('/');
        }
    }
}

