namespace EduTrail.Application.Interfaces;

public interface IFileStorageService
{
    Task<string> UploadFileAsync(Stream fileStream, string fileName, string contentType);
    Task DeleteFileAsync(string path);
    Task<Stream> DownloadFileAsync(string path);
    Task<string> GetPublicUrlAsync(string path, TimeSpan? expiry = null);
}
