using Minio.DataModel;

namespace MWShare.Helpers.FileStorage
{
    public interface IFileStorageClient
    {
        Task<bool> UploadFile(string fileName, string filePath, byte[] fileBytes);
        Task<bool> UploadFile(string fileName, string filePath, Stream fileData);
        Task<bool> DownloadFileToStream(Stream destStream, string filePath);
        Task<ObjectStat> GetFileInfo(string filePath);
    }
}
