using System.Threading.Tasks;

namespace CloudST.Services.StorageS3
{
    public interface IS3Service
    {
        Task UploadFileAsync(string filePath, string keyName);
        Task DownloadFileAsync(string keyName, string destinationPath);
        Task DeleteFileAsync(string keyName);
        Task ListFilesAsync();
    }
}