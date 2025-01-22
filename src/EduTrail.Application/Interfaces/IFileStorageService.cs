namespace EduTrail.Application.Interfaces;

public interface IFileStorageService
{
    /// <summary>
    /// Uploads a file to the configured storage service
    /// </summary>
    /// <param name="fileStream"></param>
    /// <param name="fileName"></param>
    /// <param name="contentType"></param>
    /// <returns>identifier/location of stored file</returns>
    Task<string> UploadFileAsync(Stream fileStream, string fileName, string contentType);
    Task DeleteFileAsync(string path);
    Task<Stream> DownloadFileAsync(string path);
    Task<string> GetPublicUrlAsync(string path, TimeSpan? expiry = null);
}
